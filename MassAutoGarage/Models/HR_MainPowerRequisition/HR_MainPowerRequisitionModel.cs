using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_MainPowerRequisition
{
    public class HR_MainPowerRequisitionModel
    {
        public string Idincrept { get; set; }
        public string ManPowerID { get; set; }
        public string ManpowerDetID { get; set; }
        public string PreferredID { get; set; }
        public string Id { get; set; }
        public string VoucherNo { get; set; }
        public string hdfVoucherNo { get; set; }
        public string DesignationId { get; set; }
        public string Designation { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string RequestedDate { get; set; }
        public string RequiredDate { get; set; }
        public bool FullTime { get; set; }
        public bool ProjectHire { get; set; }
        public bool Temporary { get; set; }
        public string JobDescription { get; set; }
        public bool AdditionNew { get; set; }
        public bool Budgeted { get; set; }
        public bool Replacement { get; set; }
        public string AgeRange { get; set; }
        public decimal SalaryRange { get; set; }
        public string StatusID { get; set; }
        public string GenderID { get; set; }
        public string Qualification { get; set; }
        public string PassingYear { get; set; }
        public string Board { get; set; }
        public string Percentage { get; set; }
        public string PreferredQualification { get; set; }
        public string PreferredExperience { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_MainPowerRequisitionModel> lst { get; set; }
    }
}