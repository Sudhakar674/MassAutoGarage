using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace MassAutoGarage.Models.HRMS_Employee
{
    public class HRMSEmployeeModel
    {
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string DeptID { get; set; }
        public string DepartmentName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string NationalityId { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatusId { get; set; }
        public string MaritalStatus { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string ReportingManager { get; set; }
        public string DepartmentId { get; set; }
        public string JoiningDate { get; set; }
        public string BranchLocationId { get; set; }
        public string DateOfBirth { get; set; }
        public string TypeId { get; set; }
        public string GenderBloodGroup { get; set; }
        public string PassportNo { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportExpiryDate { get; set; }
        public string HomeCountryAirport { get; set; }
        public string HomeCountryContactNumber1 { get; set; }
        public string HomeCountryContactNumber2 { get; set; }
        public string EmergencyContactNo { get; set; }
        public string Email { get; set; }
        public string AccountNo { get; set; }
        public string WPSDebitCardNumber { get; set; }
        public string WPSExpiry { get; set; }
        public string TotalLeavePerYear { get; set; }
        public string NoOfWorkingHours { get; set; }
        public string NoOfDays { get; set; }
        public string LabourCardNo { get; set; }
        public string LabourCardExpiry { get; set; }
        public string PersonCode { get; set; }
        public string UAEContactNo1 { get; set; }
        public string UAEContactNo2 { get; set; }
        public string UAEAddress { get; set; }
        public string BasicSalary { get; set; }
        public string Transportation { get; set; }
        public string Accommodation { get; set; }
        public string AdditionalAllowance { get; set; }
        public string Standard { get; set; }
        public string Skill { get; set; }
        public string AccommodationAllowance { get; set; }
        public string Cola { get; set; }
        public string Education { get; set; }
        public string CarAllowance { get; set; }
        public string Telephone { get; set; }
        public string Others { get; set; }
        public string TotalSalary { get; set; }
        public string EmiratesID { get; set; }
        public string EmiratesIDExpiry { get; set; }
        public string VisaUIDNo { get; set; }
        public string VisaFileNo { get; set; }
        public string VisaPlaceOfIssue { get; set; }
        public string VisaIssueDate { get; set; }
        public string VisaExpiry { get; set; }
        public string InsuranceProvider { get; set; }
        public string InsuranceNumber { get; set; }
        public string InsuranceExpiry { get; set; }
        public string ResignationTerminationDate { get; set; }
        public string Remarks { get; set; }
        public string Organization { get; set; }
        public string TicketIssuedPerYear { get; set; }
        public string Photo { get; set; }

        public string EmployeeId { get; set; }

        public List<HRMSEmployeeModel> EmployeeList { get; set; }



    }
}