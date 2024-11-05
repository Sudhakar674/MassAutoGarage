using MassAutoGarage.Models.HRMS_SalesTarget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_Attendance
{
    public class HRMSAttendanceModel
    {
        public string Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string AttendanceId { get; set; }
        public string VoucherNumber { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        public string txtEmpName { get; set; }
        public string MaxID { get; set; }     
        public string NumberOfWorkingHours { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string BreakTimeStart { get; set; }
        public string BreakTimeEnd { get; set; }
        public string StartTime1 { get; set; }
        public string EndTime1 { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public List<HRMSAttendanceModel> HRMSAttendanceModelList { get; set; }

    }
}