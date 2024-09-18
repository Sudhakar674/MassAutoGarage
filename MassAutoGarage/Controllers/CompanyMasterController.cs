using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.DBRepository;
using MassAutoGarage.Models;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class CompanyMasterController : Controller
    {
        // GET: CompanyMaster

        public decimal filesize { get; set; }

        ClsGeneral objcls = new ClsGeneral();
        CompanyMaster_DL objDL = new CompanyMaster_DL();
        ImportExcelFileRepo fileexcel = new ImportExcelFileRepo();
        public ActionResult Index(string Key)
        {
            Int64 userID = 0;
            List<CompanyMasterModel> model = new List<CompanyMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {

                userID = Convert.ToInt64(Session["userId"]);
                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchCompanyMaster("44", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new CompanyMasterModel
                        {
                            Id = objcls.Encrypt(i.Id),
                            Code = i.Code,
                            GroupID = i.GroupID,
                            GroupName = i.GroupName,
                            CompanyName = i.CompanyName,
                            Address = i.Address,
                            TRN = i.TRN,
                            Email = i.Email,
                            LocationMapUrl = i.LocationMapUrl,
                            CompanyId = i.Id,
                            IsActive = i.IsActive,
                            CompanyLogo = i.CompanyLogo

                        });
                    }

                }
                else
                {

                    var GroupList = objDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new CompanyMasterModel
                        {
                            Id = objcls.Encrypt(i.Id),
                            Code = i.Code,
                            GroupID = i.GroupID,
                            GroupName = i.GroupName,
                            CompanyName = i.CompanyName,
                            Address = i.Address,
                            TRN = i.TRN,
                            Email = i.Email,
                            LocationMapUrl = i.LocationMapUrl,
                            CompanyId = i.Id,
                            IsActive = i.IsActive,
                            CompanyLogo = i.CompanyLogo
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
        public ActionResult Company(string ID = "")
        {
            Dropdown();
            CompanyMasterModel model = new CompanyMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.CompanyMasterModelList = objDL.GetCompanyMasterdtlsIdWise("43", id);
                var lst = model.CompanyMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.Id = lst.Id;
                    model.Code = lst.Code;
                    model.GroupID = lst.GroupID;
                    model.CompanyName = lst.CompanyName;
                    model.Address = lst.Address;
                    model.TRN = lst.TRN;
                    model.Email = lst.Email;
                    model.LocationMapUrl = lst.LocationMapUrl;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.CompanyMasterModelList = objDL.GetCode("41", "Company");
                var promotioncode = model.CompanyMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult UploadLogo()
        {
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
                            string fname;

                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                                Session["companylgo"] = fname;
                            }
                            else
                            {
                                fname = logoname + file.FileName;
                                Session["companylgo"] = fname;
                            }
                            fname = Path.Combine(Server.MapPath("~/CompanyLogo/"), fname);

                            file.SaveAs(fname);
                        }
                    }

                    return Json("File Uploaded Successfully!");
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

        public JsonResult SaveCompanyMaster(CompanyMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.Id != "" && model.Id != null)
                {

                    model.QueryType = "21";

                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    if (Session["companylgo"] != null)
                    {
                        model.CompanyLogo = Session["companylgo"].ToString();
                    }
                    else
                    {
                        model.CompanyLogo = model.CompanyLogo;
                    }
                    model.Id = objcls.Decrypt(model.Id);
                    model = objDL.AddUpdate(model);
                    if (model.Flag == 2)
                    {
                        result = "2";
                    }
                    else
                    {
                        result = "";
                    }
                }
                else
                {
                    model.QueryType = "11";

                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    if (Session["companylgo"] != null)
                    {
                        model.CompanyLogo = Session["companylgo"].ToString();
                    }
                    else
                    {

                    }
                    model = objDL.AddUpdate(model);
                    if (model.Flag == 1)
                    {
                        Session["companylgo"] = null;
                        result = "1";
                    }
                    else if (model.Flag == 4)
                    {
                        result = "4";
                    }
                    else
                    {
                        result = "";
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private void Dropdown()
        {
            ViewBag.Group = DbMaster.Dropdown("41", 0);


        }

        public JsonResult DeleteCompany(Int64 CompanyId)
        {

            var res = objDL.Delete(CompanyId);
            return Json(res.Flag, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DonwloadExcel()
        {
            DataTable result = new DataTable();
            result = fileexcel.GetExcelList("42", "USP_CompanyMaster");

            result.TableName = "Company";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(result);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= ReferralReport.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    return Json(Convert.ToBase64String(MyMemoryStream.ToArray(), 0, MyMemoryStream.ToArray().Length), JsonRequestBehavior.AllowGet);
                    //MyMemoryStream.WriteTo(Response.OutputStream);
                    //Response.Flush();
                    //Response.End();
                }
            }

        }

    }
}