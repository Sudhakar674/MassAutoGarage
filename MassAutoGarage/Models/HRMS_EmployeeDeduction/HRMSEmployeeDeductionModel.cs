using MassAutoGarage.Models.HRMS_Attendance;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Models.HRMS_EmployeeDeduction
{
    public class HRMSEmployeeDeductionModel
    {

        public string Id { get; set; }
        public string FromDate { get; set; }
        public string CalculatedDate { get; set; }
        public string ToDate { get; set; }
        public double Amount { get; set; }
        public double TotalAmount { get; set; }
        public string BranchId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        public string BranchName { get; set; }
        public string DeductionTypeId { get; set; }

        public string EmployeeDeductionId { get; set; }
        
        public string Remarks { get; set; }
        public string DeductionType { get; set; }


        public string MonthYear { get; set; }
        public string Amount1 { get; set; }
  
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }


        public List<HRMSEmployeeDeductionModel> HRMSEmployeeDeductionModelList { get; set; }
    }
}