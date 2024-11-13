using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Models.HRMS_EmployeeBankDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_OverTime
{
    public class HRMSOverTimeModel
    {
        public string IdEncrypte { get; set; }
        public string BranchId { get; set; }
        public string EmployeeId { get; set; }
        public string VoucherNo { get; set; }
        public string EmployeeName { get; set; }
        public string OTDate { get; set; }
        public string OTTime { get; set; }
        public string OTRate { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ID { get; set; }
        public string MaxID { get; set; }
        public string BranchName { get; set; }
        public List<HRMSOverTimeModel> OverTimeModellst { get; set; }

    }
}