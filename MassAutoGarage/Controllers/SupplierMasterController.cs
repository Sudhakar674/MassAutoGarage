using DocumentFormat.OpenXml.EMMA;
using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.SupplierMaster;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DriverMaster;
using MassAutoGarage.Models.SupplierMaster;
using Microsoft.VisualStudio.Services.Organization.Client;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Web.UI;

namespace MassAutoGarage.Controllers
{
    public class SupplierMasterController : Controller
    {
        // GET: SupplierMaster
        public decimal filesize { get; set; }
        public decimal Pdffilesize { get; set; }
        SupplierMaster_DL objDL = new SupplierMaster_DL();
        SupplierOpeningBalance_DL objOpeningBalanceDL = new SupplierOpeningBalance_DL();
        ClsGeneral objcls = new ClsGeneral();

        #region Supplier Master
        public ActionResult SupplierDetails(string Key)
        {
            Int64 userID = 0;
            List<SupplierMasterModel> model = new List<SupplierMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchSupplier("47", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new SupplierMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            SupplierName = i.SupplierName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            SupplierID = Convert.ToInt64(i.ID),
                            IsActive = i.IsActive,
                            CompanyName = i.CompanyName,
                            Mobile = i.Mobile
                        });
                    }

                }
                else
                {

                    var GroupList = objDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new SupplierMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            SupplierName = i.SupplierName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            SupplierID = Convert.ToInt64(i.ID),
                            IsActive = i.IsActive,
                            CompanyName = i.CompanyName,
                            Mobile = i.Mobile
                        });

                    }
                }



                var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();
                if (logo != null)
                {
                    ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                    ViewBag.compnyAddress = logo.Address;
                }
            }
            else
            {
                ViewBag.compnylgo = null;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateSupplier(string ID = "")
        {
            SupplierMasterModel model = new SupplierMasterModel();

            Int64 userID = 0;
            if (Session["userId"] != null)
            {
                Dropdown();

                userID = Convert.ToInt64(Session["userId"]);

                if (ID != "")
                {
                    Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                    model.SupplierMasterModelList = objDL.GetlstIdWise("42", id);
                    var lst = model.SupplierMasterModelList.FirstOrDefault();
                    if (lst != null)
                    {
                        model.ID = lst.ID;
                        model.Code = lst.Code;
                        model.SupplierName = lst.SupplierName;
                        model.CompanyID = lst.CompanyID;
                        model.AccountName = lst.AccountName;
                        model.LandlineNumber = lst.LandlineNumber;
                        model.Mobile = lst.Mobile;
                        model.Address = lst.Address;
                        model.Email = lst.Email;
                        model.TRN = lst.TRN;
                        model.IsActive = lst.IsActive;
                        model.CreationDate = lst.CreationDate;
                        model.CreditDays = lst.CreditDays;
                        model.CreditLimit = lst.CreditLimit;

                        model.Block = lst.Block;
                        model.Reason = lst.Reason;
                        model.VATSupplierID = lst.VATSupplierID;
                        model.TradeLicenceExpiry = lst.TradeLicenceExpiry;
                        model.InternationalID = lst.InternationalID;
                        model.UAEID = lst.UAEID;
                        model.GCCID = lst.GCCID;
                        model.ContactPerson = lst.ContactPerson;
                        model.ContactNumber = lst.ContactNumber;
                        model.ContactEmail = lst.ContactEmail;
                        model.Desination = lst.Desination;
                        model.Photourl = lst.Photourl;
                        model.Signatureurl = lst.Signatureurl;
                        ViewBag.VATID = lst.VATSupplierID;
                        ViewBag.photo = "/PhotoSign/" + lst.Photourl;
                        ViewBag.Sign = "/PhotoSign/" + lst.Signatureurl;
                    }




                    ViewBag.AttachmentList = objDL.GetlstIdWise("43", id);
                    ViewBag.ContactDetails = objDL.GetlstIdWise("44", id);
                }
                else
                {
                    model.SupplierMasterModelList = objDL.GetCode("41", "Supplier Master");
                    var promotioncode = model.SupplierMasterModelList.FirstOrDefault();
                    if (promotioncode != null)
                    {

                        model.Code = promotioncode.Code;
                        model.CurrentCount = promotioncode.CurrentCount;


                    }
                }

                var companyId = objDL.GetlstIdWise("45", userID).FirstOrDefault();
                model.CompanyID = companyId.CompanyID;



            }
            return View(model);
        }

        public JsonResult InsertUpdateSupplier(List<SupplierMasterModel> PatientArr)
        {
            string result = string.Empty;
            SupplierMasterModel model = new SupplierMasterModel();
            string ToEmail = string.Empty;
            try
            {
                if (PatientArr[0].ID != null && PatientArr[0].ID != "")
                {
                    model.QueryType = "21";
                    model.ID = objcls.Decrypt(PatientArr[0].ID);
                    model.Code = PatientArr[0].Code;
                    model.SupplierName = PatientArr[0].SupplierName;
                    model.CompanyID = PatientArr[0].CompanyID;
                    model.AccountName = PatientArr[0].AccountName;
                    model.LandlineNumber = PatientArr[0].LandlineNumber;
                    model.Mobile = PatientArr[0].Mobile;
                    model.Address = PatientArr[0].Address;
                    model.Email = PatientArr[0].Email;
                    ToEmail = PatientArr[0].Email;
                    model.TRN = PatientArr[0].TRN;
                    model.IsActive = PatientArr[0].IsActive;
                    model.CreationDate = PatientArr[0].CreationDate;
                    model.CreditDays = PatientArr[0].CreditDays;
                    model.CreditLimit = PatientArr[0].CreditLimit;
                    model.Block = PatientArr[0].Block;
                    model.Reason = PatientArr[0].Reason;
                    model.VATSupplierID = PatientArr[0].VATSupplierID;

                    model.TradeLicenceExpiry = PatientArr[0].TradeLicenceExpiry;
                    model.InternationalID = PatientArr[0].InternationalID;
                    model.UAEID = PatientArr[0].UAEID;
                    model.GCCID = PatientArr[0].GCCID;
                    model.CurrentCount = PatientArr[0].CurrentCount;
                    model.CreatedBy = Convert.ToInt32(Session["userId"]);
                    model.Photourl = PatientArr[0].Photourl;
                    model.Signatureurl = PatientArr[0].Signatureurl;


                    var MXID = objcls.Decrypt(PatientArr[0].ID);
                    model = objDL.AddUpdate(model);

                    if (model.Flag == "1")
                    {
                        Int64 SuppId = Convert.ToInt64(MXID);
                        var Flag = objDL.DeleteTable("31", SuppId);


                        foreach (var Attch in PatientArr)
                        {
                            if (Attch.Type1 == "1")
                            {
                                model.QueryType = "11";
                                model.SupplierID = Convert.ToInt64(MXID);
                                model.Description = Attch.Description.Trim();
                                model.ExpiryDate = Attch.ExpiryDate;
                                model.AttachmentFile = Attch.AttachmentFile.Trim();
                                model.IsUpdated = 1;
                                model = objDL.AddUpdateBulk(model);
                            }
                        }


                        var Flag2 = objDL.DeleteTable("32", SuppId);

                        foreach (var CT in PatientArr)
                        {
                            if (CT.Type2 == "2")
                            {
                                model.QueryType = "11";
                                model.SupplierID = Convert.ToInt64(MXID);
                                model.ContactPerson = CT.ContactPerson.Trim();
                                model.ContactNumber = CT.ContactNumber.Trim();
                                model.ContactEmail = CT.ContactEmail.Trim();
                                model.Desination = CT.Desination.Trim();
                                model.IsUpdated = 1;
                                model = objDL.AddUpdateBulkForContact(model);
                            }
                        }

                    }

                    result = model.Flag;
                }
                else
                {
                    model.QueryType = "11";
                    model.ID = PatientArr[0].ID;
                    model.Code = PatientArr[0].Code;
                    model.SupplierName = PatientArr[0].SupplierName;
                    model.CompanyID = PatientArr[0].CompanyID;
                    model.AccountName = PatientArr[0].AccountName;
                    model.LandlineNumber = PatientArr[0].LandlineNumber;
                    model.Mobile = PatientArr[0].Mobile;
                    model.Address = PatientArr[0].Address;
                    model.Email = PatientArr[0].Email;
                    ToEmail = PatientArr[0].Email;
                    model.TRN = PatientArr[0].TRN;
                    model.IsActive = PatientArr[0].IsActive;
                    model.CreationDate = PatientArr[0].CreationDate;
                    model.CreditDays = PatientArr[0].CreditDays;
                    model.CreditLimit = PatientArr[0].CreditLimit;
                    model.Block = PatientArr[0].Block;
                    model.Reason = PatientArr[0].Reason;
                    model.VATSupplierID = PatientArr[0].VATSupplierID;

                    model.TradeLicenceExpiry = PatientArr[0].TradeLicenceExpiry;
                    model.InternationalID = PatientArr[0].InternationalID;
                    model.UAEID = PatientArr[0].UAEID;
                    model.GCCID = PatientArr[0].GCCID;
                    model.CurrentCount = PatientArr[0].CurrentCount;
                    model.CreatedBy = Convert.ToInt32(Session["userId"]);
                    model.Photourl = PatientArr[0].Photourl;
                    model.Signatureurl = PatientArr[0].Signatureurl;

                    model = objDL.AddUpdate(model);
                    if (model.MaxID > 0)
                    {
                        var MXID = model.MaxID;
                        foreach (var Attch in PatientArr)
                        {
                            if (Attch.Type1 == "1")
                            {
                                model.QueryType = "11";
                                model.SupplierID = MXID;
                                model.Description = Attch.Description;
                                model.ExpiryDate = Attch.ExpiryDate;
                                model.AttachmentFile = Attch.AttachmentFile;
                                model.IsUpdated = 0;
                                model = objDL.AddUpdateBulk(model);
                            }
                        }

                        foreach (var CT in PatientArr)
                        {
                            if (CT.Type2 == "2")
                            {
                                model.QueryType = "11";
                                model.SupplierID = MXID;
                                model.ContactPerson = CT.ContactPerson;
                                model.ContactNumber = CT.ContactNumber;
                                model.ContactEmail = CT.ContactEmail;
                                model.Desination = CT.Desination;
                                model.IsUpdated = 0;
                                model = objDL.AddUpdateBulkForContact(model);
                            }
                        }

                    }

                    result = model.Flag;
                }

                if (model.Flag == "1")
                {

                    EmailHelper objmail = new EmailHelper();

                    string toEmail = ToEmail;
                    string subject = "Test Email";
                    string body = "This is a test email sent from ASP.NET MVC using Webmail.";
                    objmail.SendEmail(toEmail, subject, body);

                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }



        }


        [HttpPost]
        public ActionResult UploadLogo()
        {
            string fname = "";
            string _fileName = "";

            filesize = 7;
            Pdffilesize = 5;

            if (Request.Files.Count > 0)
            {
                try
                {

                    string logoname = Guid.NewGuid().ToString("N").Substring(0, 5);

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        var supportedTypes = new[] { "jpg", "png", "jpeg", "pdf" };
                        HttpPostedFileBase file = files[i];
                        var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

                        if (fileExt != "pdf")
                        {
                            if (!supportedTypes.Contains(fileExt))
                            {
                                return Json("File Extension Is InValid - Only Upload JPG/PNG/JPEG");
                            }
                            else if (file.ContentLength > (filesize * 8000))
                            {

                                return Json("File size Should Be UpTo " + filesize + " KB !");

                            }
                            else
                            {


                                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                {
                                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                    fname = testfiles[testfiles.Length - 1];
                                    //Session["companylgo"] = fname;
                                    _fileName = fname;
                                }
                                else
                                {
                                    fname = logoname + file.FileName;

                                    _fileName = fname;
                                }
                                fname = Path.Combine(Server.MapPath("~/AttachmentFile/"), fname);

                                file.SaveAs(fname);
                            }
                        }
                        else
                        {
                            if (!supportedTypes.Contains(fileExt))
                            {
                                return Json("File Extension Is InValid - Only Upload JPG/PNG/JPEG/PDF");
                            }
                            else if (file.ContentLength > (Pdffilesize * 5269767))
                            {

                                return Json("PDF File size Should Be UpTo " + Pdffilesize + " MB !");

                            }
                            else
                            {


                                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                {
                                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                    fname = testfiles[testfiles.Length - 1];

                                    _fileName = fname;
                                }
                                else
                                {
                                    fname = logoname + file.FileName;

                                    _fileName = fname;
                                }
                                fname = Path.Combine(Server.MapPath("~/AttachmentFile/"), fname);

                                file.SaveAs(fname);
                            }

                        }
                    }

                    return Json(_fileName, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public ActionResult UploadPhoto()
        {
            string fname = "";
            string _fileName = "";

            filesize = 7;

            if (Request.Files.Count > 0)
            {
                try
                {

                    string logoname = Guid.NewGuid().ToString("N").Substring(0, 5);

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        var supportedTypes = new[] { "jpg", "png", "jpeg" };
                        HttpPostedFileBase file = files[i];
                        var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);


                        if (!supportedTypes.Contains(fileExt))
                        {
                            return Json("File Extension Is InValid - Only Upload JPG/PNG/JPEG");
                        }
                        else if (file.ContentLength > (filesize * 8000))
                        {

                            return Json("File size Should Be UpTo " + filesize + " KB !");

                        }
                        else
                        {


                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                                _fileName = fname;
                            }
                            else
                            {
                                fname = logoname + file.FileName;
                                _fileName = fname;
                            }
                            fname = Path.Combine(Server.MapPath("~/PhotoSign/"), fname);

                            file.SaveAs(fname);
                        }


                    }

                    return Json(_fileName, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public ActionResult UploadSign()
        {
            string fname = "";
            string _fileName = "";

            filesize = 7;

            if (Request.Files.Count > 0)
            {
                try
                {

                    string logoname = Guid.NewGuid().ToString("N").Substring(0, 5);

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        var supportedTypes = new[] { "jpg", "png", "jpeg" };
                        HttpPostedFileBase file = files[i];
                        var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);


                        if (!supportedTypes.Contains(fileExt))
                        {
                            return Json("File Extension Is InValid - Only Upload JPG/PNG/JPEG");
                        }
                        else if (file.ContentLength > (filesize * 8000))
                        {

                            return Json("File size Should Be UpTo " + filesize + " KB !");

                        }
                        else
                        {


                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                                _fileName = fname;
                            }
                            else
                            {
                                fname = logoname + file.FileName;
                                _fileName = fname;
                            }
                            fname = Path.Combine(Server.MapPath("~/PhotoSign/"), fname);

                            file.SaveAs(fname);
                        }


                    }

                    return Json(_fileName, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        public JsonResult GetContactList(Int64 SupplierID)
        {
            var lst = objDL.GetlstIdWise("44", SupplierID);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAttachmentList(Int64 SupplierID)
        {
            var attlst = objDL.GetlstIdWise("43", SupplierID);
            return Json(attlst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSupplierDetails(Int64 SupplierID)
        {
            var supplrlist = objDL.GetlstIdWise("46", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(Int64 SupplID)
        {
            DriverMasterModel model = new DriverMasterModel();
            var lst = objDL.DeleteTable("33", SupplID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintSupplierMaster(Int64 SupplierID)
        {
            return View();
        }

        public JsonResult SendWhatsappMessage( string Mobile, string whatsAppMessage)
        {
            string job = Mobile;
            string AppURL = WebConfigurationManager.AppSettings["AppURL"];
          //  AppURL = AppURL + "ShowFile.aspx?FileName=";
           // string FileName = job.Trim() + DateTime.Now.ToString("ddMMyyyyHHMMss");
           // string Exten = "pdf";
            whatsAppMessage = whatsAppMessage.Replace("\n", String.Empty);
           // string WhatsappMessage = whatsAppMessage + " " + AppURL + FileName + "." + Exten;
            string WhatsappMessage = whatsAppMessage;
            string url = "https://api.whatsapp.com/send?phone=" + Mobile + "&text=" + WhatsappMessage; //+"&document=" + attach;

           
            return Json(url,JsonRequestBehavior.AllowGet); 
        }


       
        #endregion

        #region Supplier Opening Balance
        public ActionResult OpeningBalanceDetails(string Key)
        {
            Int64 userID = 0;
            List<OpeningBalanceModel> model = new List<OpeningBalanceModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = objOpeningBalanceDL.SearchSupplier("47", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new OpeningBalanceModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            SupplierName = i.SupplierName,
                            CompanyName = i.CompanyName,
                            BalanceID = Convert.ToInt64(i.ID),

                        });
                    }

                }
                else
                {

                    var GroupList = objOpeningBalanceDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new OpeningBalanceModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            SupplierName = i.SupplierName,
                            CompanyName = i.CompanyName,
                            BalanceID = Convert.ToInt64(i.ID),

                        });

                    }
                }



                var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();
                if (logo != null)
                {
                    ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                    ViewBag.compnyAddress = logo.Address;
                }
            }
            else
            {
                ViewBag.compnylgo = null;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult OpeningBalance(string ID = "")
        {
            OpeningBalanceModel model = new OpeningBalanceModel();
            Int64 userID = 0;
            if (Session["userId"] != null)
            {
                Dropdown();

                userID = Convert.ToInt64(Session["userId"]);
                if (ID != "")
                {

                    Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                    model.OpeningBalanceModelList = objOpeningBalanceDL.GetlstIdWise("45", id);
                    var lst = model.OpeningBalanceModelList.FirstOrDefault();
                    if (lst != null)
                    {
                        model.ID = lst.ID;
                        model.Code = lst.Code;
                        model.CompanyID = lst.CompanyID;
                        model.SupplierID = lst.SupplierID;
                    }

                    ViewBag.OpeningBalanceDetails = objOpeningBalanceDL.GetlstIdWise("46", id);

                }
                else
                {
                    model.OpeningBalanceModelList = objOpeningBalanceDL.GetCode("41", "Supplier Opening Balance");
                    var promotioncode = model.OpeningBalanceModelList.FirstOrDefault();
                    if (promotioncode != null)
                    {

                        model.Code = promotioncode.Code;
                        model.CurrentCount = promotioncode.CurrentCount;

                    }

                    var companyId = objDL.GetlstIdWise("45", userID).FirstOrDefault();
                    model.CompanyID = companyId.CompanyID;

                    //var SupplierName = objDL.GetlstIdWise("48", model.CompanyID).FirstOrDefault();
                    //model.SupplierID = SupplierName.SupplierID;
                }
            }

            return View(model);
        }

        public JsonResult InsertUpdateOpeningBalance(List<OpeningBalanceModel> PatientArr)
        {
            string result = string.Empty;
            OpeningBalanceModel model = new OpeningBalanceModel();


            if (PatientArr[0].ID != null && PatientArr[0].ID != "")
            {
                model.QueryType = "21";
                model.ID = objcls.Decrypt(PatientArr[0].ID);
                model.Code = PatientArr[0].Code;
                model.SupplierID = PatientArr[0].SupplierID;
                model.CompanyID = PatientArr[0].CompanyID;
                model.CurrentCount = PatientArr[0].CurrentCount;
                model.CreatedBy = Convert.ToInt32(Session["userId"]);


                var MXID = objcls.Decrypt(PatientArr[0].ID);

                model = objOpeningBalanceDL.AddUpdate(model);

                if (model.Flag == "1")
                {
                    Int64 SuppId = Convert.ToInt64(MXID);
                    var Flag = objOpeningBalanceDL.DeleteTable("31", SuppId);

                    if (Flag != null)
                    {
                        foreach (var det in PatientArr)
                        {

                            model.QueryType = "11";
                            model.ID = MXID;
                            model.InvoiceDate = det.InvoiceDate.Trim();
                            model.InvoiceNumber = det.InvoiceNumber.Trim();
                            model.ToAccountID = det.ToAccountID;
                            model.LPONO = det.LPONO.Trim();
                            model.TotalAmount = det.TotalAmount;
                            model.PaidAmount = det.PaidAmount;
                            model.BalanceAmount = det.BalanceAmount;
                            model.IsAction = 2;
                            model = objOpeningBalanceDL.AddUpdateBulk(model);

                        }
                    }

                }

                result = model.Flag;
            }
            else
            {
                model.QueryType = "11";
                model.Code = PatientArr[0].Code;
                model.SupplierID = PatientArr[0].SupplierID;
                model.CompanyID = PatientArr[0].CompanyID;
                model.CurrentCount = PatientArr[0].CurrentCount;
                model.CreatedBy = Convert.ToInt32(Session["userId"]);

                model = objOpeningBalanceDL.AddUpdate(model);

                if (model.MaxID > 0)
                {
                    var MXID = model.MaxID;
                    foreach (var det in PatientArr)
                    {
                        model.QueryType = "11";
                        model.ID = MXID.ToString();
                        model.InvoiceDate = det.InvoiceDate.Trim();
                        model.InvoiceNumber = det.InvoiceNumber.Trim();
                        model.ToAccountID = det.ToAccountID;
                        model.LPONO = det.LPONO.Trim();
                        model.TotalAmount = det.TotalAmount;
                        model.PaidAmount = det.PaidAmount;
                        model.BalanceAmount = det.BalanceAmount;
                        model.IsAction = 1;
                        model = objOpeningBalanceDL.AddUpdateBulk(model);
                    }

                }

                result = model.Flag;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCode_ByID(string Supp_ID, string comp_ID)
        {

            string result = string.Empty;

            var lst = objDL.GetCodeByID("41", Supp_ID, comp_ID);
            var promotioncode = lst.FirstOrDefault();
            if (promotioncode != null)
            {

                result = promotioncode.Code;

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanySupplierDetails(Int64 ID)
        {
            var lst = objOpeningBalanceDL.GetlstIdWise("43", ID);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSupplierOpeningBalanceDetails(Int64 ID)
        {
            var lst = objOpeningBalanceDL.GetlstIdWise("44", ID);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOpeningBalance(Int64 SupplID)
        {
            DriverMasterModel model = new DriverMasterModel();
            var lst = objOpeningBalanceDL.DeleteTable("32", SupplID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
        #endregion


        private void Dropdown()
        {
            ViewBag.Company = DbMaster.DropdownList("41", 4);
            ViewBag.International = DbMaster.DropdownList("41", 10);
            ViewBag.GCC = DbMaster.DropdownList("41", 11);
            ViewBag.UAE = DbMaster.DropdownList("41", 12);
            ViewBag.SupplierList = DbMaster.DropdownList("41", 13);
            ViewBag.ToAccountNameList = DbMaster.DropdownList("41", 20);
        }
    }
}