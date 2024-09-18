using ClosedXML.Excel;
using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.DBRepository;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MassAutoGarage.Controllers
{
    public class MasterController : Controller
    {

        // GET: Master
        ClsGeneral objcls = new ClsGeneral();
        GroupMaster objdb = new GroupMaster();
        ImportExcelFileRepo fileexcel = new ImportExcelFileRepo();
        private void CreateResponse(string Action, string Controller, string Message)
        {
            ViewBag.ResponseURL = Url.Action(Action, Controller);
            ViewBag.ResponseMessage = Message;
            ViewBag.ResponseType = ResponseType.Success;
        }
        public ActionResult GroupMasterIndex(string Key)
        {
            List<GroupMasterModel> model = new List<GroupMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objdb.SearchGroupMaster("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new GroupMasterModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        Code = i.Code,
                        GroupName = i.GroupName,
                        GroupID = i.Id,
                        IsActive = i.IsActive,
                        PageCount = 10,
                        page = 10,
                        PageNumber = 15,

                    });
                }

            }
            else
            {
                var GroupList = objdb.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new GroupMasterModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        Code = i.Code,
                        GroupName = i.GroupName,
                        GroupID = i.Id,
                        IsActive = i.IsActive,
                        PageCount = 10,
                        page = 10,
                        PageNumber = 15,

                    });
                }

            }
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                Int64 userID = Convert.ToInt64(Session["userId"]);
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
        public ActionResult GroupMaster(string ID = "")
        {
            GroupMasterModel model = new GroupMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.GroupMasterList = objdb.GetGroupMasterIdWise("42", id);
                var lst = model.GroupMasterList.FirstOrDefault();
                if (lst != null)
                {
                    model.Id = lst.Id;
                    model.Code = lst.Code;
                    model.GroupName = lst.GroupName;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.GroupMasterList = objdb.GetCode("41", "Company Group");
                var promotioncode = model.GroupMasterList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult GroupMaster(GroupMasterModel model)
        {
            string result = string.Empty;
            try
            {
                model = objdb.Add(model);
                if (model.Flag == 1)
                {
                    CreateResponse("GroupMasterIndex", "Master", model.Message == null || model.Message == "" ? "Course Insert Successfully" : model.Message, ResponseType.Green);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }

        public JsonResult SaveGroupMaster(GroupMasterModel model)
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
                    model.Id = objcls.Decrypt(model.Id);
                    model = objdb.Add(model);
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
                    model = objdb.Add(model);
                    if (model.Flag == 1)
                    {
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

        private void CreateResponse(string Action, string Controller, string Message, string ResponseType_success_warning_error_OR_info, bool UseTempData = false, string ResponseTitle = "")
        {
            if (!string.IsNullOrEmpty(Action))
            {
                ViewBag.ResponseURL = Url.Action(Action, Controller);
                if (UseTempData)
                    TempData["ResponseURL"] = Url.Action(Action, Controller);
            }

            ViewBag.ResponseMessage = Message;
            ViewBag.ResponseType = ResponseType_success_warning_error_OR_info;

            if (!string.IsNullOrEmpty(ResponseTitle)) ViewBag.ResponseTitle = ResponseTitle;
            if (UseTempData)
            {
                TempData["ResponseMessage"] = Message;
                TempData["ResponseType"] = ResponseType_success_warning_error_OR_info;
            }
        }

        public JsonResult DeleteGroup(Int64 GroupId)
        {

            var res = objdb.Delete(GroupId);
            return Json(res.Flag, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DonwloadExcel()
        {
            DataTable result = new DataTable();
            result = fileexcel.GetExcelList("41", "USP_GetGroupMasterDetails");

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