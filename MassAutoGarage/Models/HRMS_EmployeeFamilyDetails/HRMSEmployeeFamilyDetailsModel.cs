using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_EmployeeFamilyDetails
{
    public class HRMSEmployeeFamilyDetailsModel
    {

        public string Idencrept { get; set; }
        public string BranchId { get; set; }
        public string MaritalStatusId { get; set; }
        public string EmployeeBranch { get; set; }
        public string MotherName { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string Photo { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ID { get; set; }
        public string BranchName { get; set; }
        public string MaritalStatus { get; set; }
        public List<HRMSEmployeeFamilyDetailsModel>EmployeeFamilyDetailsModelList { get; set; }
    }
}