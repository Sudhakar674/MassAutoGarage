using MassAutoGarage.Data.HRMS_Attendance;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.HRMS_OverTime;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HRMS_OverTimeController : Controller
    {
        // GET: HRMS_OverTime
        HRMSOverTimeModel model = new HRMSOverTimeModel();
        HRMSOverTimeDL DL = new HRMSOverTimeDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMaxVoucher()
        {
            List<HRMSOverTimeModel> GetMaxVoucher = new List<HRMSOverTimeModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HRMSOverTimeModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OverTime()
        {
            ViewBag.BranchList = DL.DropdownBranchList();
            ViewBag.EmployeeList = DL.DropdownEmployeeList();
            return View();
        }


        //public JsonResult SaveOverTime(List<HRMSOverTimeModel> PatientArr)
        //{
        //    HRMSOverTimeModel model = new HRMSOverTimeModel();

        //    try
        //    {
        //        model.VoucherNo = PatientArr[0].VoucherNo;

        //        model.AttendanceDate = string.IsNullOrEmpty(model.AttendanceDate) ? null : Common.ConvertToSystemDate(model.AttendanceDate, "dd/MM/yyyy");
        //        foreach (var Attch in PatientArr)
        //        {
        //            model.CreatedBy = Session["userId"].ToString();
        //            model.QueryType = "11";
        //            model.AttendanceDate = model.AttendanceDate;
        //            model.VoucherNumber = Attch.VoucherNumber;
        //            model.EmployeeId = Attch.EmployeeId;
        //            model.NumberOfWorkingHours = Attch.NumberOfWorkingHours;
        //            model.StartTime = Attch.StartTime;
        //            model.EndTime = Attch.EndTime;
        //            model.BreakTimeStart = Attch.BreakTimeStart;
        //            model.BreakTimeEnd = Attch.BreakTimeEnd;
        //            model.StartTime1 = Attch.StartTime1;
        //            model.EndTime1 = Attch.EndTime1;
        //            model = DL.AddUpdateBulk(model);
        //        }
        //        if (model.Message == "1")
        //        {
        //            model.Result = "yes";
        //        }
        //        else
        //        {
        //            model.Result = "";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}



    }
}