using MassAutoGarage.Models.HRMS_Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_AirTicketIssue
{
    public class HRMSAirTicketIssueModel
    {
        public string Idencrept { get; set; }
        public string BranchId { get; set; }
        public string EmployeeId { get; set; }
        public string VoucherNo { get; set; }
        public string Date { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ID { get; set; }
        public string TicketCount { get; set; }
        public string BranchName { get; set; }
        public string EmployeeName { get; set; }
        public string TicketFrom { get; set; }
        public string TicketTo { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public string AirlineName { get; set; }
        public string PNRNumber { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureAirport { get; set; }


        public string MaxID { get; set; }
        public List<HRMSAirTicketIssueModel> AirTicketIssueModelList { get; set; }

    }
}