using dotless.Core.Parser.Tree;
using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_LeaveRequest
{
    public class HR_LeaveRequestModel
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
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string DateOfJoining { get; set; }
        public bool MarriageLeave { get; set; }
        public bool AnnualLeave { get; set; }
        public bool AuthorizedUnpaidLeave { get; set; }
        public bool EmergencyLeave { get; set; }
        public bool SickLeave { get; set; }
        public bool MaternityLeave { get; set; }
        public bool Others { get; set; }
        public string PleaseSpecifyOtherLeave { get; set; }
        public bool LocalLeave { get; set; }
        public string LeaveFromDate { get; set; }   
        public string LeaveToDate { get; set; }
        public string AirportName { get; set; }
        public string FromAirportName { get; set; }     
        public string ToAirportName { get; set; }
        public string ReasonforSickLeave { get; set; }
        public int MedicalCertificate { get; set; }
        public string MedicalCertificateFile { get; set; }
        public string HDF_MedicalCertificateFile { get; set; }

        


        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_LeaveRequestModel> lst { get; set; }

    }
}