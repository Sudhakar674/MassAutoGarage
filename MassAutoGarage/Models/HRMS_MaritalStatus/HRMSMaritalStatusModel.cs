using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_MaritalStatus
{
    public class HRMSMaritalStatusModel
    {
        public string MaritalSId { get; set; }
        public string MaritalStatus { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string IsActive { get; set; }
        public string QueryType { get; set; }
        public string Flag { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public List<HRMSMaritalStatusModel> HRMSMaritalStatusModelList {  get; set; }
    }
}