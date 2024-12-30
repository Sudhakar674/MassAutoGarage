using MassAutoGarage.Data.HR_ResumingDuty;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_ResumingDuty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_StaffTransferReport;
using MassAutoGarage.Data.HR_StaffTransferReport;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HR_StaffTransferReportController : Controller
    {
        // GET: HR_StaffTransferReport
        HR_StaffTransferReportModel model = new HR_StaffTransferReportModel();
        HR_StaffTransferReportDL DL = new HR_StaffTransferReportDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult StaffTransferReport(HR_StaffTransferReportModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlBranch = DL.ddlBranch();

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "37";
                var lst = DL.GetStaffTransferReportDetaildById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.Date = lst.Date;
                    model.DesignationId = lst.DesignationId;
                    model.EmpNo = lst.EmpNo;
                    model.DateofJoining = lst.DateofJoining;
                    model.BranchDeptFrom = lst.BranchDeptFrom;
                    model.BranchDeptTo = lst.BranchDeptTo;
                    model.TimeofJoining = lst.TimeofJoining;                  
                }
            }
            return View(model);
        }


        public ActionResult GetMaxVoucher()
        {
            List<HR_StaffTransferReportModel> GetMaxVoucher = new List<HR_StaffTransferReportModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_StaffTransferReportModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveStaffTransferReport(HR_StaffTransferReportModel model)
        {
            try
            {

                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.DateofJoining = string.IsNullOrEmpty(model.DateofJoining) ? null : Common.ConvertToSystemDate(model.DateofJoining, "dd/MM/yyyy");     
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

        public ActionResult StaffTransferReportList(string Key)
        {
            List<HR_StaffTransferReportModel> StaffTransferReportList = new List<HR_StaffTransferReportModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("36", Key);
                foreach (var i in GroupList)
                {
                    StaffTransferReportList.Add(new HR_StaffTransferReportModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        DateofJoining = i.DateofJoining,
                        BranchDeptFrom = i.BranchDeptFrom,
                        BranchDeptTo = i.BranchDeptTo,
                        TimeofJoining = i.TimeofJoining,

                    });
                }
            }
            else
            {
                var GroupList = DL.GetStaffTransferReportList();
                foreach (var i in GroupList)
                {
                    StaffTransferReportList.Add(new HR_StaffTransferReportModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        DateofJoining = i.DateofJoining,
                        BranchDeptFrom = i.BranchDeptFrom,
                        BranchDeptTo = i.BranchDeptTo,
                        TimeofJoining = i.TimeofJoining,
                    });
                }
            }
            return View(StaffTransferReportList);
        }


        [HttpPost]
        public ActionResult DeleteStaffTransferReport(HR_StaffTransferReportModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteStaffTransferReport(model);
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