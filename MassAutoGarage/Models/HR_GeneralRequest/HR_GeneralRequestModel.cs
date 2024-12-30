using DocumentFormat.OpenXml.Bibliography;
using MassAutoGarage.Models.HRMS_Loan;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_GeneralRequest
{
    public class HR_GeneralRequestModel
    {
        public string Idincrept { get; set; }
        public string Id { get; set; }
        public string VoucherNumber { get; set; }
        public string hdfVoucherNumber { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Date { get; set; }
        public string DesignationId { get; set; }
        public string Designation { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string EmpId { get; set; }
        //public string SalaryCertificate { get; set; }
        public bool SalaryCertificate { get; set; }
        public bool SalaryCertificate1 { get; set; }
        public bool SalaryTransferLetter { get; set; }
        public bool NOC { get; set; }
        public bool ExperienceCertificate { get; set; }
        public string BankEstablishment { get; set; }
        public string AcctNoIBANNo { get; set; }
        public bool OpneNewBankAcct { get; set; }
        public bool TransferLoanToOtherBank { get; set; }
        public bool PersonalLoan { get; set; }
        public bool NOCToEmbassy { get; set; }
        public bool ConfirmationLettrToBank { get; set; }
        public bool LoanTopUp { get; set; }
        public bool Others { get; set; }
        public string CashAdvance { get; set; }
        public bool InitialNewEmp { get; set; }
        public bool Against { get; set; }
        public string BehalfAgainst { get; set; }
        public string Reason { get; set; }
        public string MonthlyDeduction { get; set; }
        public bool SalarySlips3Months { get; set; }
        public bool SalarySlips6Months { get; set; }
        public string TrafficFineDeductionAmt { get; set; }
        public bool SalaryCard { get; set; }
        public string EmpSignature { get; set; }
        public string MobileNumber { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public string MarriageLeave { get; set; }
        public List<HR_GeneralRequestModel> lst { get; set; }


    }
}