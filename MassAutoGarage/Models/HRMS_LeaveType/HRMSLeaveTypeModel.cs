using MassAutoGarage.Models.HRMS_DeductionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_LeaveType
{
    public class HRMSLeaveTypeModel
    {
        public string LeaveID { get; set; }
        public string LeaveType { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        //public List<HRMSLeaveTypeModel> HRMSLeaveTypeModelList { get; set; }
    }
}