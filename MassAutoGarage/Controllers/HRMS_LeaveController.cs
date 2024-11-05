using MassAutoGarage.Data.HRMS_Loan;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_Leave;
using MassAutoGarage.Data.HRMS_Leave;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HRMS_LeaveController : Controller
    {
        // GET: HRMS_Leave
        HRMSLeaveModel model = new HRMSLeaveModel();
        HRMSLeaveDL DL = new HRMSLeaveDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSLeaveModel> LeaveList = new List<HRMSLeaveModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("36", Key);
                foreach (var i in GroupList)
                {
                    LeaveList.Add(new HRMSLeaveModel
                    {
                        Idencrept = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        EmployeeName = i.EmployeeName,
                        LeaveType = i.LeaveType,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
                        LeaveCount = i.LeaveCount,
                        BalanceLeave = i.BalanceLeave,
                        Description = i.Description
                    });
                }
            }
            else
            {
                var GroupList = DL.GetLeaveList();
                foreach (var i in GroupList)
                {
                LeaveList.Add(new HRMSLeaveModel
                {
                        Idencrept = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        EmployeeName = i.EmployeeName,
                        LeaveType = i.LeaveType,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
                        LeaveCount = i.LeaveCount,
                        BalanceLeave = i.BalanceLeave,
                        Description = i.Description
                });
                }
            }
            return View(LeaveList);
        }
        public ActionResult Leave(HRMSLeaveModel model, string Id)
        {
            ViewBag.BranchList = DL.DropdownList();
            ViewBag.EmployeeList = DL.DropDownEmployeeList();
            ViewBag.LeavTypeList = DL.DropDownLeavTypeList();

            if (Id != null)
            {
                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "35";
                var lst = DL.GetLeaveDetailsById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.BranchId = lst.BranchId;
                    model.EmployeeId = lst.EmployeeId;
                    model.LeaveTypeId = lst.LeaveTypeId;
                    model.FromDate = lst.FromDate;
                    model.ToDate = lst.ToDate;
                    model.LeaveCount = lst.LeaveCount;
                    model.BalanceLeave = lst.BalanceLeave;
                    model.Description = lst.Description;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveLeave(HRMSLeaveModel model)
        {
            try
            {
                if (model.ID == null || model.ID == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                    model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
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
                    model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                    model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");

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

        public ActionResult DeleteLeave(HRMSLeaveModel model, string Id)
        {
            try
            {

                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteLeaveDetails(model);
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