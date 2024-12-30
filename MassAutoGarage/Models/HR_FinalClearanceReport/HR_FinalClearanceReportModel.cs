using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace MassAutoGarage.Models.HR_FinalClearanceReport
{
    public class HR_FinalClearanceReportModel
    {
        public string Idincrept { get; set; }
        public string Id { get; set; }
        public string VoucherNo { get; set; }
        public string hdfVoucherNo { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Date { get; set; }
        public string DesignationId { get; set; }
        public string Designation { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string EmpNo { get; set; }     
        public string LastWorkingDay { get; set; }
        public bool Vehichle { get; set; }
        public bool Laptop { get; set; }
        public bool CompanySim { get; set; }
        public bool MedicalInsurance { get; set; }
        public bool C3Card { get; set; }
        public string Replacement { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_FinalClearanceReportModel> lst { get; set; }
    }
}