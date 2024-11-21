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
        public string SalaryCertificate { get; set; }
        public string SalaryTransferLetter { get; set; }
        public string NOC { get; set; }
        public string ExperienceCertificate { get; set; }
        public string BankEstablishment { get; set; }
        public string AcctNoIBANNo { get; set; }
        public string OpneNewBankAcct { get; set; }
        public string TransferLoanToOtherBank { get; set; }
        public string PersonalLoan { get; set; }
        public string NOCToEmbassy { get; set; }
        public string ConfirmationLettrToBank { get; set; }
        public string LoanTopUp { get; set; }
        public string Others { get; set; }
        public string CashAdvance { get; set; }
        public string InitialNewEmp { get; set; }
        public string Against { get; set; }
        public string BehalfAgainst { get; set; }
        public string Reason { get; set; }
        public string MonthlyDeduction { get; set; }
        public string SalarySlips3Months { get; set; }
        public string SalarySlips6Months { get; set; }
        public string TrafficFineDeductionAmt { get; set; }
        public string SalaryCard { get; set; }
        public string EmpSignature { get; set; }
        public string MobileNumber { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string Certificate { get; set; }
        public string GeneralRequestId { get; set; }
        public string CertificateDetails { get; set; }
        public List<HR_GeneralRequestModel> HR_GeneralRequestModelList { get; set; }
        public List<HR_GeneralRequestModel> lst { get; set; }


    }
}