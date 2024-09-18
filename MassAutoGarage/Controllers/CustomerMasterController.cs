using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.CustomerMaster;
using MassAutoGarage.Data.SupplierMaster;
using MassAutoGarage.Models.CustomerMaster;
using MassAutoGarage.Models.DriverMaster;
using MassAutoGarage.Models.SupplierMaster;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class CustomerMasterController : Controller
    {
        // GET: CustomerMaster
        public decimal filesize { get; set; }
        public decimal Pdffilesize { get; set; }
        CustomerMaster_DL objDL = new CustomerMaster_DL();
        CustomerOpeningBalance_DL objOpeningBalanceDL= new CustomerOpeningBalance_DL();
        ClsGeneral objcls = new ClsGeneral();

        #region Customer Master
        public ActionResult CustomerDetails(string Key)
        {
            Int64 userID = 0;
            List<CustomerMasterModel> model = new List<CustomerMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchSupplier("47", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            CustomerName = i.CustomerName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            CustomerID = Convert.ToInt64(i.ID),
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
                        model.Add(new CustomerMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            CustomerName = i.CustomerName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            CustomerID = Convert.ToInt64(i.ID),
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
        public ActionResult AddCustomer(string ID = "")
        {
            CustomerMasterModel model = new CustomerMasterModel();

            Int64 userID = 0;
            if (Session["userId"] != null)
            {
                Dropdown();

                userID = Convert.ToInt64(Session["userId"]);

                if (ID != "")
                {
                    Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                    model.CustomerMasterModelList = objDL.GetlstIdWise("42", id);
                    var lst = model.CustomerMasterModelList.FirstOrDefault();
                    if (lst != null)
                    {


                        model.ID = lst.ID;
                        model.Code = lst.Code;
                        model.CompanyID = lst.CompanyID;
                        model.CustomerName = lst.CustomerName;
                        model.AccountName = lst.AccountName;
                        model.ContactPersonName = lst.ContactPersonName;
                        model.Mobile = lst.Mobile;
                        model.Address = lst.Address;
                        model.Email = lst.Email;
                        model.TRN = lst.TRN;
                        model.CreationDate = lst.CreationDate;
                        model.CreditDays = lst.CreditDays;
                        model.CreditLimit = lst.CreditLimit;
                        model.Block = lst.Block;
                        model.Reason = lst.Reason;
                        model.VATCustomerID = lst.VATCustomerID;
                        model.TradeLicenceExpiry = lst.TradeLicenceExpiry;
                        model.LoyaltyPoints = lst.LoyaltyPoints;
                        model.InternationalID = lst.InternationalID;
                        model.UAEID = lst.UAEID;
                        model.GCCID = lst.GCCID;

                        model.Group = lst.Group;
                        model.AdvisorName = lst.AdvisorName;
                        model.DiscountAllowedAmt = lst.DiscountAllowedAmt;
                        model.Source = lst.Source;
                        model.Gender = lst.Gender;
                        model.DiscountAllowedPercentage = lst.DiscountAllowedPercentage;
                        model.Salesman = lst.Salesman;
                        model.Nationality = lst.Nationality;
                        model.Individualorcompany = lst.Individualorcompany;
                        model.IsActive = lst.IsActive;




                        ViewBag.VATID = lst.VATCustomerID;
                    }
                   



                    ViewBag.AttachmentList = objDL.GetlstIdWise("43", id);
                    ViewBag.ContactDetails = objDL.GetlstIdWise("44", id);
                }
                else
                {
                    model.CustomerMasterModelList = objDL.GetCode("41", "Customer Master");
                    var promotioncode = model.CustomerMasterModelList.FirstOrDefault();
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
                                return Json("File Extension Is InValid - Only Upload JPG/PNG/JPEG/PDF");
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
                                    Session["companylgo"] = fname;
                                    _fileName = fname;
                                }
                                else
                                {
                                    fname = logoname + file.FileName;
                                    Session["companylgo"] = fname;
                                    _fileName = fname;
                                }
                                fname = Path.Combine(Server.MapPath("~/CustomerAttachment/"), fname);

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
                                    Session["companylgo"] = fname;
                                    _fileName = fname;
                                }
                                else
                                {
                                    fname = logoname + file.FileName;
                                    Session["companylgo"] = fname;
                                    _fileName = fname;
                                }
                                fname = Path.Combine(Server.MapPath("~/CustomerAttachment/"), fname);

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
        public JsonResult InsertUpdateCustomer(List<CustomerMasterModel> PatientArr)
        {
            string result = string.Empty;
            CustomerMasterModel model = new CustomerMasterModel();


            if (PatientArr[0].ID != null && PatientArr[0].ID != "")
            {
                model.QueryType = "21";
                model.ID = objcls.Decrypt(PatientArr[0].ID);
                model.Code = PatientArr[0].Code;
                model.CompanyID = PatientArr[0].CompanyID;
                model.CustomerName = PatientArr[0].CustomerName;
                model.AccountName = PatientArr[0].AccountName;
                model.ContactPersonName = PatientArr[0].ContactPersonName;

                model.Mobile = PatientArr[0].Mobile;
                model.Address = PatientArr[0].Address;
                model.Email = PatientArr[0].Email;
                model.TRN = PatientArr[0].TRN;
                model.CreationDate = PatientArr[0].CreationDate;
                model.CreditDays = PatientArr[0].CreditDays;
                model.CreditLimit = PatientArr[0].CreditLimit;
                model.Block = PatientArr[0].Block;
                model.Reason = PatientArr[0].Reason;
                model.VATCustomerID = PatientArr[0].VATCustomerID;
                model.TradeLicenceExpiry = PatientArr[0].TradeLicenceExpiry;
                model.LoyaltyPoints = PatientArr[0].LoyaltyPoints;
                model.InternationalID = PatientArr[0].InternationalID;
                model.UAEID = PatientArr[0].UAEID;
                model.GCCID = PatientArr[0].GCCID;


                model.Group = PatientArr[0].Group;
                model.AdvisorName = PatientArr[0].AdvisorName;
                model.DiscountAllowedAmt = PatientArr[0].DiscountAllowedAmt;
                model.Source = PatientArr[0].Source;
                model.Gender = PatientArr[0].Gender;
                model.DiscountAllowedPercentage = PatientArr[0].DiscountAllowedPercentage;
                model.Salesman = PatientArr[0].Salesman;
                model.Nationality = PatientArr[0].Nationality;
                model.Individualorcompany = PatientArr[0].Individualorcompany;

                model.IsActive = PatientArr[0].IsActive;
                model.CurrentCount = PatientArr[0].CurrentCount;
                model.CreatedBy = Convert.ToInt32(Session["userId"]);

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
                            model.CustomerID = Convert.ToInt64(MXID);
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
                            model.CustomerID = Convert.ToInt64(MXID);
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
                model.Code = PatientArr[0].Code;
                model.CompanyID = PatientArr[0].CompanyID;
                model.CustomerName = PatientArr[0].CustomerName;
                model.AccountName = PatientArr[0].AccountName;
                model.ContactPersonName = PatientArr[0].ContactPersonName;

                model.Mobile = PatientArr[0].Mobile;
                model.Address = PatientArr[0].Address;
                model.Email = PatientArr[0].Email;
                model.TRN = PatientArr[0].TRN;
                model.CreationDate = PatientArr[0].CreationDate;
                model.CreditDays = PatientArr[0].CreditDays;
                model.CreditLimit = PatientArr[0].CreditLimit;
                model.Block = PatientArr[0].Block;
                model.Reason = PatientArr[0].Reason;
                model.VATCustomerID = PatientArr[0].VATCustomerID;
                model.TradeLicenceExpiry = PatientArr[0].TradeLicenceExpiry;
                model.LoyaltyPoints = PatientArr[0].LoyaltyPoints;
                model.InternationalID = PatientArr[0].InternationalID;
                model.UAEID = PatientArr[0].UAEID;
                model.GCCID = PatientArr[0].GCCID;


                model.Group = PatientArr[0].Group;
                model.AdvisorName = PatientArr[0].AdvisorName;
                model.DiscountAllowedAmt = PatientArr[0].DiscountAllowedAmt;
                model.Source = PatientArr[0].Source;
                model.Gender = PatientArr[0].Gender;
                model.DiscountAllowedPercentage = PatientArr[0].DiscountAllowedPercentage;
                model.Salesman = PatientArr[0].Salesman;
                model.Nationality = PatientArr[0].Nationality;
                model.Individualorcompany = PatientArr[0].Individualorcompany;

                model.IsActive = PatientArr[0].IsActive;
                model.CreatedBy = Convert.ToInt32(Session["userId"]);
                model.CurrentCount = PatientArr[0].CurrentCount;

                model = objDL.AddUpdate(model);
                if (model.MaxID > 0)
                {
                    var MXID = model.MaxID;
                    foreach (var Attch in PatientArr)
                    {
                        if (Attch.Type1 == "1")
                        {
                            model.QueryType = "11";
                            model.CustomerID = MXID;
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
                            model.CustomerID = MXID;
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

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Delete(Int64 SupplID)
        {
            DriverMasterModel model = new DriverMasterModel();
            var lst = objDL.DeleteTable("33", SupplID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetCustomerDetails(Int64 SupplierID)
        {
            var supplrlist = objDL.GetlstIdWise("46", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Customer Opening Balance
        public ActionResult CustomerOpeningBalance(string Key)
        {
            Int64 userID = 0;
            List<CustomerOpeningBalanceModel> model = new List<CustomerOpeningBalanceModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = objOpeningBalanceDL.SearchCustomer("47", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerOpeningBalanceModel
                        {
                            ID = objcls.Encrypt(i.ID),

                            CompanyName = i.CompanyName,
                            JobCardDate = i.JobCardDate,
                            JobCardNumber = i.JobCardNumber,                          
                            BalanceID = Convert.ToInt64(i.ID),
                         
                        });
                    }

                }
                else
                {

                    var GroupList = objOpeningBalanceDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerOpeningBalanceModel
                        {
                            ID = objcls.Encrypt(i.ID),

                            CompanyName = i.CompanyName,
                            JobCardDate = i.JobCardDate,
                            JobCardNumber = i.JobCardNumber,
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
        public ActionResult ADDCustomerOpeningBalance(string ID = "")
        {
            Dropdown();
            CustomerOpeningBalanceModel model = new CustomerOpeningBalanceModel();

            Int64 userID = 0;
            if (Session["userId"] != null)
            {
               

                userID = Convert.ToInt64(Session["userId"]);

                if (ID != "")
                {
                    Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                    model.CustomerOpeningBalanceModelList = objOpeningBalanceDL.GetlstIdWise("45", id);
                    var lst = model.CustomerOpeningBalanceModelList.FirstOrDefault();
                    if (lst != null)
                    {
                        model.ID = lst.ID;                       
                        model.CompanyID = lst.CompanyID;
                        model.JobCardDate = lst.JobCardDate;
                        model.JobCardNumber = lst.JobCardNumber;
                       
                    }

                    
                    ViewBag.OpeningBalanceDetails = objOpeningBalanceDL.GetlstIdWise("46", id);
                }
                else
                {
                    
                }

                //var companyId = objDL.GetlstIdWise("45", userID).FirstOrDefault();
                //model.CompanyID = companyId.CompanyID;
            }
            return View(model);
        }

        public JsonResult InsertUpdateCustomerOpeningBalance(List<CustomerOpeningBalanceModel> PatientArr)
        {
            string result = string.Empty;
            CustomerOpeningBalanceModel model = new CustomerOpeningBalanceModel();


            if (PatientArr[0].ID != null && PatientArr[0].ID != "")
            {
                model.QueryType = "21";
                model.ID = objcls.Decrypt(PatientArr[0].ID);      
                model.CompanyID = PatientArr[0].CompanyID;
                model.JobCardDate = PatientArr[0].JobCardDate;
                model.JobCardNumber = PatientArr[0].JobCardNumber;
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
                            model.ToAccountID = det.ToAccountID;
                            model.InvoiceDate = det.InvoiceDate.Trim();
                            model.InvoiceNumber = det.InvoiceNumber.Trim();                           
                            model.LPONO = det.LPONO.Trim();
                            model.EstNo = det.EstNo.Trim();
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
                model.CompanyID = PatientArr[0].CompanyID;
                model.JobCardDate = PatientArr[0].JobCardDate;
                model.JobCardNumber = PatientArr[0].JobCardNumber;
                model.CreatedBy = Convert.ToInt32(Session["userId"]);
                model = objOpeningBalanceDL.AddUpdate(model);

                if (model.MaxID > 0)
                {
                    var MXID = model.MaxID;
                    foreach (var det in PatientArr)
                    {
                        model.QueryType = "11";
                        model.ID = MXID.ToString();
                        model.ToAccountID = det.ToAccountID;
                        model.InvoiceDate = det.InvoiceDate.Trim();
                        model.InvoiceNumber = det.InvoiceNumber.Trim();
                        model.LPONO = det.LPONO.Trim();
                        model.EstNo = det.EstNo.Trim();
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

        public JsonResult GetOpeningBalanceList(Int64 BalanceID)
        {
            var lst = objOpeningBalanceDL.GetlstIdWise("42", BalanceID);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOpeningBalanceDetailsList(Int64 BalanceID)
        {
            var lst = objOpeningBalanceDL.GetlstIdWise("43", BalanceID);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOpeningBalace(int BalanceID)
        {

            var lst = objOpeningBalanceDL.DeleteTable("32", BalanceID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);

        }
        #endregion

        private void Dropdown()
        {
            ViewBag.Company = DbMaster.DropdownList("41", 4);
            ViewBag.International = DbMaster.DropdownList("41", 10);
            ViewBag.GCC = DbMaster.DropdownList("41", 11);
            ViewBag.UAE = DbMaster.DropdownList("41", 12);


            ViewBag.LoyaltyPoint = DbMaster.DropdownList("41", 14);
            ViewBag.CustomerGroup = DbMaster.DropdownList("41", 15);
            ViewBag.SourceList = DbMaster.DropdownList("41", 16);
            ViewBag.SalesManList = DbMaster.DropdownList("41", 17);
            ViewBag.NationalityList = DbMaster.DropdownList("41", 18);
            ViewBag.ToAccountNameList = DbMaster.DropdownList("41", 20);
        }
    }
}