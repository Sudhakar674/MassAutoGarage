using MassAutoGarage.Models.HR_PassportRelease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_ResumingDuty
{
    public class HR_ResumingDutyModel
    {
        public string Idincrept { get; set; }
        public string Id { get; set; }
        public string VoucherNo { get; set; }
        public string hdfVoucherNo { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Date { get; set; }
        public string DesignationId { get; set; }
        public string Designation { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string EmpNo { get; set; }
        public string DateofJoining { get; set; }
        public string DateofResumingDuty { get; set; }
        public string Time { get; set; }
        public string PeriodofFromLeave { get; set; }
        public string PeriodofToLeave { get; set; }
        public string OtherReasons { get; set; }
        public string SignDate { get; set; }

        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_ResumingDutyModel> lst { get; set; }
    }
}