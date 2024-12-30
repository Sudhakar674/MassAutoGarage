using MassAutoGarage.Models.HR_ResumingDuty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_StaffTransferReport
{
    public class HR_StaffTransferReportModel
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
        public string BranchDeptFrom { get; set; }
        public string BranchDeptTo { get; set; }
        public string BranchName { get; set; }
        public string EmpNo { get; set; }
        public string DateofJoining { get; set; }
        public string TimeofJoining { get; set; }      
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_StaffTransferReportModel> lst { get; set; }

    }
}