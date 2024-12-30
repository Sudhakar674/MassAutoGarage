using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_PassportRelease
{
    public class HR_PassportReleaseModel
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
        public string EmpNo { get; set; }
        public string ReasonForReleasePassReq { get; set; }
        public string ExpectedReturnDate { get; set; }
        public string EmployeeUndertaking { get; set; }
        public string SignDate { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_PassportReleaseModel> lst { get; set; }
    }
}