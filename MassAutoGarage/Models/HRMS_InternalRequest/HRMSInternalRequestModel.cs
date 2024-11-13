using MassAutoGarage.Models.HRMS_AirTicketIssue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_InternalRequest
{
    public class HRMSInternalRequestModel
    {
        public string Idencrept { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ID { get; set; }

        public string CompanyId { get; set; }
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public string VoucherNo { get; set; }
        public string RequestFor { get; set; }
        public string CompanyName { get; set; }     
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string MaxID { get; set; }
        public string Purpose { get; set; }
        public string Remarks { get; set; }
        public List<HRMSInternalRequestModel> InternalRequestModelList { get; set; }


    }
}