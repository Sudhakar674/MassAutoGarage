using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Loan;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace MassAutoGarage.Data.HR_GeneralRequest
{
    public class HR_GeneralRequestDL
    {

        public List<HR_GeneralRequestModel> ddlEmployee()
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_GeneralRequestModel> ddlDesignation()
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_GeneralRequestModel> ddlBranch()
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_GeneralRequestModel> ddlDepartment()
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_GeneralRequestModel> SalaryCertificatelst()
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "36");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<HR_GeneralRequestModel> Certificatelst()
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "420");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public HR_GeneralRequestModel AddUpdate(HR_GeneralRequestModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNumber", obj.VoucherNumber);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@Date", obj.Date);
                Parameters.Add("@DesignationId", obj.DesignationId);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@DepartmentId", obj.DepartmentId);
                Parameters.Add("@EmpId", obj.EmpId);
                Parameters.Add("@SalaryCertificate", obj.SalaryCertificate);
                Parameters.Add("@SalaryTransferLetter", obj.SalaryTransferLetter);
                Parameters.Add("@NOC", obj.NOC);
                Parameters.Add("@ExperienceCertificate", obj.ExperienceCertificate);
                Parameters.Add("@BankEstablishment", obj.BankEstablishment);
                Parameters.Add("@AcctNoIBANNo", obj.AcctNoIBANNo);
                Parameters.Add("@OpneNewBankAcct", obj.OpneNewBankAcct);
                Parameters.Add("@TransferLoanToOtherBank", obj.TransferLoanToOtherBank);
                Parameters.Add("@PersonalLoan", obj.PersonalLoan);
                Parameters.Add("@NOCToEmbassy", obj.NOCToEmbassy); 
                Parameters.Add("@ConfirmationLettrToBank", obj.ConfirmationLettrToBank);
                Parameters.Add("@LoanTopUp", obj.LoanTopUp);
                Parameters.Add("@Others", obj.Others);
                Parameters.Add("@CashAdvance", obj.CashAdvance);
                Parameters.Add("@InitialNewEmp", obj.InitialNewEmp);
                Parameters.Add("@Against", obj.Against);
                Parameters.Add("@BehalfAgainst", obj.BehalfAgainst); 
                Parameters.Add("@Reason", obj.Reason);
                Parameters.Add("@MonthlyDeduction", obj.MonthlyDeduction);
                Parameters.Add("@SalarySlips3Months", obj.SalarySlips3Months);
                Parameters.Add("@SalarySlips6Months", obj.SalarySlips6Months);
                Parameters.Add("@TrafficFineDeductionAmt", obj.TrafficFineDeductionAmt);
                Parameters.Add("@SalaryCard", obj.SalaryCard);
                Parameters.Add("@EmpSignature", obj.EmpSignature);
                Parameters.Add("@MobileNumber", obj.MobileNumber);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_GeneralRequestModel>("USP_HR_GeneralRequest", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public HR_GeneralRequestModel AddUpdateBulk(HR_GeneralRequestModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.GeneralRequestId);
                Parameters.Add("@EmployeeId", obj.CertificateDetails);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_GeneralRequestModel>("USP_HR_GeneralRequest", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



        







        public List<HR_GeneralRequestModel> GetEmployeeDocumentsList()
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_GeneralRequestModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<HR_GeneralRequestModel> GetEmployeeDocumentsDetaildById(HR_GeneralRequestModel objmodel)
        {
            List<HR_GeneralRequestModel> obj = new List<HR_GeneralRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@EmpDocId", objmodel.EmpId);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_GeneralRequestModel>("USP_HR_GeneralRequest", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_GeneralRequestModel DeleteEmployeeDocuments(HR_GeneralRequestModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@EmpDocId", obj.EmpId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_GeneralRequestModel>("USP_HR_GeneralRequest", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}