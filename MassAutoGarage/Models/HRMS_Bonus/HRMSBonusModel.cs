using MassAutoGarage.Models.HRMS_EmployeeFamilyDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_Bonus
{
    public class HRMSBonusModel
    {
        public string Idencrept { get; set; }
        public string BranchId { get; set; } 
        public string EmployeeId { get; set; }      
        public string BonusAmount { get; set; }
        public string BonusDate { get; set; }
        public string Remarks { get; set; }        
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ID { get; set; }
        public string BranchName { get; set; }
        public string EmployeeName { get; set; }
        public List<HRMSBonusModel> HRMSBonusModelList { get; set; }
    }
}