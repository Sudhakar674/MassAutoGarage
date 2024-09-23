using MassAutoGarage.Models.HRMS_MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_DeductionType
{
    public class HRMS_DeductionTypeModel
    {

        public string DeductionID { get; set; }
        public string DeductionType { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public List<HRMS_DeductionTypeModel> HRMSDeductionTypeModelList { get; set; }
    }
}
