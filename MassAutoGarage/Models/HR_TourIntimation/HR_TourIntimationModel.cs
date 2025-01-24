using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_TourIntimation
{
    public class HR_TourIntimationModel
    {
        public string Idincrept { get; set; }
        public string Id { get; set; }
        public string VoucherNo { get; set; }
        public string hdfVoucherNo { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DesignationId { get; set; }
        public string Designation { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string TourDestination { get; set; }
        public string TravelModeID { get; set; }
        public string StartDate { get; set; }
        public string ReturnDate { get; set; }
        public string PurposeOfTour { get; set; }
        public string Details { get; set; }
        public string SuggestReplacement { get; set; }
        public string Acknowledgement { get; set; }
        public bool VisaSingleEntry { get; set; }
        public bool VisaMultipleEntry { get; set; }
        public bool HotelEconomic { get; set; }
        public bool PassportRelease { get; set; }
        public bool TravelInsuranceYes { get; set; }
        public bool TravelInsuranceNo { get; set; }
        public string CashAdvanceAmt { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_TourIntimationModel> lst { get; set; }
    }
}