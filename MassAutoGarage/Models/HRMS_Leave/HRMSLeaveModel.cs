using MassAutoGarage.Models.HRMS_Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_Leave
{
    public class HRMSLeaveModel
    {
        public string Idencrept { get; set; }
        public string BranchId { get; set; }
        public string EmployeeId { get; set; }
        public string LeaveTypeId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ID { get; set; }
        public string LeaveID { get; set; }
        public string BranchName { get; set; }
        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }
        public string LeaveCount { get; set; }
        public string BalanceLeave { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string DeductionPerMonth { get; set; }
        public string TotalAmount { get; set; }
        public List<HRMSLeaveModel> HRMSLeaveModelList { get; set; }


    }
}