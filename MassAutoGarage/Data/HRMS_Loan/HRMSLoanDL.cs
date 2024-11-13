using Dapper;
using DocumentFormat.OpenXml.VariantTypes;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Bonus;
using MassAutoGarage.Models.HRMS_Loan;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HRMS_Loan
{
    public class HRMSLoanDL
    {
        public List<HRMSLoanModel> DropdownBranchList()
        {
            List<HRMSLoanModel> obj = new List<HRMSLoanModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLoanModel>("USP_HRMS_Loan", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSLoanModel> DropDownEmployeeList()
        {
            List<HRMSLoanModel> obj = new List<HRMSLoanModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLoanModel>("USP_HRMS_Loan", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSLoanModel> DropDeductionTypeTypeList()
        {
            List<HRMSLoanModel> obj = new List<HRMSLoanModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLoanModel>("USP_HRMS_Loan", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSLoanModel AddUpdate(HRMSLoanModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@Amount", obj.Amount);
                Parameters.Add("@FromDate", obj.FromDate);
                Parameters.Add("@ToDate", obj.ToDate);
                Parameters.Add("@DeductionTypeId", obj.DeductionTypeId);
                Parameters.Add("@Remarks", obj.Remarks);
                Parameters.Add("@TotalAmount", obj.TotalAmount);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSLoanModel>("USP_HRMS_Loan", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HRMSLoanModel AddUpdateBulk(HRMSLoanModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@LoanId1", obj.LoanId);
                Parameters.Add("@MonthYear", obj.MonthYear);
                Parameters.Add("@Amount1", obj.Amount1);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSLoanModel>("USP_HRMS_Loan", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}