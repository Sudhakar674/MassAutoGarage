using MassAutoGarage.Data.HR_LeaveRequest;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.HR_ResumingDuty;
using MassAutoGarage.Models.HR_ResumingDuty;
using MassAutoGarage.Models.HR_PassportRelease;
using MassAutoGarage.Models;
using DocumentFormat.OpenXml.Bibliography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Controllers
{
    public class HR_ResumingDutyController : Controller
    {
        // GET: HR_ResumingDuty
        HR_ResumingDutyModel model = new HR_ResumingDutyModel();
        HR_ResumingDutyDL DL = new HR_ResumingDutyDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult ResumingDuty(HR_ResumingDutyModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlCompany = DL.ddlCompany();
            ViewBag.ddlDepartment = DL.ddlDepartment();
            ViewBag.ddlBranch = DL.ddlBranch();


            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "39";
                var lst = DL.GetResumingDutyDetaildById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.Date = lst.Date;
                    model.DesignationId = lst.DesignationId;
                    model.EmpNo = lst.EmpNo;
                    model.CompanyId = lst.CompanyId;
                    model.DepartmentId = lst.DepartmentId;
                    model.BranchId = lst.BranchId;
                    model.DateofJoining = lst.DateofJoining;
                    model.DateofResumingDuty = lst.DateofResumingDuty;
                    model.Time = lst.Time;
                    model.PeriodofFromLeave = lst.PeriodofFromLeave;
                    model.PeriodofToLeave = lst.PeriodofToLeave;
                    model.OtherReasons = lst.OtherReasons;
                }
            }
            return View(model);
        }



        public ActionResult GetMaxVoucher()
        {
            List<HR_ResumingDutyModel> GetMaxVoucher = new List<HR_ResumingDutyModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_ResumingDutyModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveResumingDuty(HR_ResumingDutyModel model)
        {
            try
            {

                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
                model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                model.DateofJoining = string.IsNullOrEmpty(model.DateofJoining) ? null : Common.ConvertToSystemDate(model.DateofJoining, "dd/MM/yyyy");
                model.DateofResumingDuty = string.IsNullOrEmpty(model.DateofResumingDuty) ? null : Common.ConvertToSystemDate(model.DateofResumingDuty, "dd/MM/yyyy");
                model.PeriodofFromLeave = string.IsNullOrEmpty(model.PeriodofFromLeave) ? null : Common.ConvertToSystemDate(model.PeriodofFromLeave, "dd/MM/yyyy");
                model.PeriodofToLeave = string.IsNullOrEmpty(model.PeriodofToLeave) ? null : Common.ConvertToSystemDate(model.PeriodofToLeave, "dd/MM/yyyy");
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
                    model.QueryType = "21";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.DateofJoining = string.IsNullOrEmpty(model.DateofJoining) ? null : Common.ConvertToSystemDate(model.DateofJoining, "dd/MM/yyyy");
                    model.DateofResumingDuty = string.IsNullOrEmpty(model.DateofResumingDuty) ? null : Common.ConvertToSystemDate(model.DateofResumingDuty, "dd/MM/yyyy");
                    model.PeriodofFromLeave = string.IsNullOrEmpty(model.PeriodofFromLeave) ? null : Common.ConvertToSystemDate(model.PeriodofFromLeave, "dd/MM/yyyy");
                    model.PeriodofToLeave = string.IsNullOrEmpty(model.PeriodofToLeave) ? null : Common.ConvertToSystemDate(model.PeriodofToLeave, "dd/MM/yyyy");
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

        public ActionResult ResumingDutyList(string Key)
        {
            List<HR_ResumingDutyModel> ResumingDutyList = new List<HR_ResumingDutyModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("38", Key);
                foreach (var i in GroupList)
                {
                    ResumingDutyList.Add(new HR_ResumingDutyModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        CompanyName = i.CompanyName,
                        BranchName = i.BranchName,
                        DepartmentName = i.DepartmentName,
                        DateofJoining = i.DateofJoining,
                        DateofResumingDuty = i.DateofResumingDuty,
                        Time = i.Time,
                        PeriodofFromLeave = i.PeriodofFromLeave,
                        PeriodofToLeave = i.PeriodofToLeave,
                        OtherReasons = i.OtherReasons
                    });
                }
            }
            else
            {
                var GroupList = DL.GetResumingDutyList();
            foreach (var i in GroupList)
            {
                ResumingDutyList.Add(new HR_ResumingDutyModel
                {
                    Idincrept = objcls.Encrypt(i.Id),
                    VoucherNo = i.VoucherNo,
                    EmployeeName = i.EmployeeName,
                    Date = i.Date,
                    Designation = i.Designation,
                    EmpNo = i.EmpNo,
                    CompanyName = i.CompanyName,
                    BranchName = i.BranchName,
                    DepartmentName = i.DepartmentName,
                    DateofJoining = i.DateofJoining,
                    DateofResumingDuty = i.DateofResumingDuty,
                    Time = i.Time,
                    PeriodofFromLeave = i.PeriodofFromLeave,
                    PeriodofToLeave = i.PeriodofToLeave,
                    OtherReasons = i.OtherReasons
                });
            }
            }
            return View(ResumingDutyList);
        }

        [HttpPost]
        public ActionResult DeleteResumingDuty(HR_ResumingDutyModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteResumingDuty(model);
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