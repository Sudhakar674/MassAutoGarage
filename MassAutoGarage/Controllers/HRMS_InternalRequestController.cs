using MassAutoGarage.Data.HRMS_AirTicketIssue;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_AirTicketIssue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models;
using MassAutoGarage.Models.HRMS_InternalRequest;
using MassAutoGarage.Data.HRMS_InternalRequest;
using MassAutoGarage.Models.HRMS_Attendance;
using DocumentFormat.OpenXml.Bibliography;

namespace MassAutoGarage.Controllers
{
    public class HRMS_InternalRequestController : Controller
    {
        // GET: HRMS_InternalRequest
        HRMSInternalRequestModel model = new HRMSInternalRequestModel();
        HRMSInternalRequestDL DL = new HRMSInternalRequestDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSInternalRequestModel> InternalRequestList = new List<HRMSInternalRequestModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("36", Key);
                foreach (var i in GroupList)
                {
                    InternalRequestList.Add(new HRMSInternalRequestModel
                    {
                        Idencrept = objcls.Encrypt(i.ID),
                        CompanyName = i.CompanyName,
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        DepartmentName = i.DepartmentName,
                        RequestFor = i.RequestFor,
                        Purpose = i.Purpose,
                        Remarks = i.Remarks,
                    });
                }
            }
            else
            {
                var GroupList = DL.GetInternalRequestList();
                foreach (var i in GroupList)
                {
                    InternalRequestList.Add(new HRMSInternalRequestModel
                    {
                        Idencrept = objcls.Encrypt(i.ID),
                        CompanyName = i.CompanyName,
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        DepartmentName = i.DepartmentName,
                        RequestFor = i.RequestFor,
                        Purpose = i.Purpose,
                        Remarks = i.Remarks,
                    });
                }
            }
            return View(InternalRequestList);
        }
        public ActionResult InternalRequest(HRMSInternalRequestModel model, string Id)
        {
            ViewBag.CompanyList = DL.DropDownCompanyList();
            ViewBag.EmployeeList = DL.DropDownEmployeeList();
            ViewBag.DepartmentList = DL.DropDownDepartmentList();

            if (Id != null)
            {
                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "35";
                var lst = DL.GetInternalRequesDetailsById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.CompanyId = lst.CompanyId;
                    model.VoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.DepartmentId = lst.DepartmentId;
                    model.RequestFor = lst.RequestFor;
                    model.Purpose = lst.Purpose;
                    model.Remarks = lst.Remarks;
                }
            }
            return View(model);
        }




        public ActionResult GetMaxVoucher()
        {
            List<HRMSInternalRequestModel> GetMaxVoucher = new List<HRMSInternalRequestModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HRMSInternalRequestModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult SaveInternalRequest(HRMSInternalRequestModel model)
        {
            try
            {
                if (model.ID == null || model.ID == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model = DL.AddUpdate(model);
                    if (model.Message == "1")
                    {
                        model.Result = "yes";
                    }
                    else
                    {
                        model.Result = "";
                    }
            }
                else
            {
                model.CreatedBy = Session["userId"].ToString();
                model.Idencrept = objcls.Decrypt(model.ID);
                model.QueryType = "21";
                model = DL.AddUpdate(model);
                if (model.Message == "1")
                {
                    model.Result = "yes1";
                }
                else
                {
                    model.Result = "";
                }
            }
        }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteInternalRequest(HRMSInternalRequestModel model, string Id)
        {
            try
            {

                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteInternalRequest(model);
                if (model.Message == "1")
                {
                    model.Result = "yes";
                }
                else
                {
                    model.Result = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }


    }
}