using MassAutoGarage.Data.HRMS_SalesTarget;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_SalesTarget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Data.HRMS_Attendance;
using DocumentFormat.OpenXml.Drawing;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;

namespace MassAutoGarage.Controllers
{
    public class HRMS_AttendanceController : Controller
    {
        // GET: HRMS_Attendance
        HRMSAttendanceModel model = new HRMSAttendanceModel();
        HRMSAttendanceDL DL = new HRMSAttendanceDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Attendance()
        {
            ViewBag.EmployeeList = DL.DropdownList();
            return View();
        }



        public JsonResult SaveAttendance(List<HRMSAttendanceModel> PatientArr)
        {
            HRMSAttendanceModel model = new HRMSAttendanceModel();

            try
            {
                //model.CreatedBy = Session["userId"].ToString();
                //model.QueryType = "11";
                //model.AttendanceDate = Convert.ToDateTime(PatientArr[0].AttendanceDate);

                var AttendanceDate = Convert.ToDateTime(PatientArr[0].AttendanceDate);
                //model = DL.AddUpdate(model);

                //var AttendanceId = model.AttendanceId; //(Return AttendanceId from procedure)

                foreach (var Attch in PatientArr)
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.AttendanceDate = Attch.AttendanceDate;
                    model.VoucherNumber = Attch.VoucherNumber;
                    model.EmployeeId = Attch.EmployeeId;
                    model.NumberOfWorkingHours = Attch.NumberOfWorkingHours;
                    model.StartTime = Attch.StartTime;
                    model.EndTime = Attch.EndTime;
                    model.BreakTimeStart = Attch.BreakTimeStart;
                    model.BreakTimeEnd = Attch.BreakTimeEnd;
                    model.StartTime1 = Attch.StartTime1;
                    model.EndTime1 = Attch.EndTime1;
                    model = DL.AddUpdateBulk(model);
                }
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

        public ActionResult GetMaxVoucher()
        {
            List<HRMSAttendanceModel> GetMaxVoucher = new List<HRMSAttendanceModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HRMSAttendanceModel
                {                 
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }







    }
}