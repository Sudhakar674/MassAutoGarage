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
        public List<HRMSLoanModel> DropdownList()
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

        public HRMSLoanModel AddUpdate(HRMSLoanModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@LoanDate", obj.LoanDate);
                Parameters.Add("@LoanAmount", obj.LoanAmount);
                Parameters.Add("@FromDate", obj.FromDate);
                Parameters.Add("@ToDate", obj.ToDate);
                Parameters.Add("@DeductionPerMonth", obj.DeductionPerMonth);
                Parameters.Add("@TotalAmount", obj.TotalAmount);
                Parameters.Add("@Remarks", obj.Remarks);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSLoanModel>("USP_HRMS_Loan", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<HRMSLoanModel> GetLoanList()
        {
            List<HRMSLoanModel> obj = new List<HRMSLoanModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLoanModel>("USP_HRMS_Loan", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSLoanModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSLoanModel> obj = new List<HRMSLoanModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLoanModel>("USP_HRMS_Loan", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<HRMSLoanModel> GetLoanDetailsById(HRMSLoanModel objmodel)
        {
            List<HRMSLoanModel> obj = new List<HRMSLoanModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idencrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLoanModel>("USP_HRMS_Loan", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSLoanModel DeleteLoanDetails(HRMSLoanModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idencrept);
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