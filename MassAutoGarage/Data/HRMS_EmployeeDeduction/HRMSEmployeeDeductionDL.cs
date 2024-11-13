using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_EmployeeDeduction;
using MassAutoGarage.Models.HRMS_Leave;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HRMS_EmployeeDeduction
{
    public class HRMSEmployeeDeductionDL
    {


        public List<HRMSEmployeeDeductionModel> DropdownBranchList()
        {
            List<HRMSEmployeeDeductionModel> obj = new List<HRMSEmployeeDeductionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDeductionModel>("USP_HRMS_EmployeeDeduction", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeDeductionModel> DropDownEmployeeList()
        {
            List<HRMSEmployeeDeductionModel> obj = new List<HRMSEmployeeDeductionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDeductionModel>("USP_HRMS_EmployeeDeduction", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeDeductionModel> DropDeductionTypeTypeList()
        {
            List<HRMSEmployeeDeductionModel> obj = new List<HRMSEmployeeDeductionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDeductionModel>("USP_HRMS_EmployeeDeduction", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSEmployeeDeductionModel AddUpdate(HRMSEmployeeDeductionModel obj)
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
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeDeductionModel>("USP_HRMS_EmployeeDeduction", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HRMSEmployeeDeductionModel AddUpdateBulk(HRMSEmployeeDeductionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@EmployeeDeductionId1", obj.EmployeeDeductionId);
                Parameters.Add("@MonthYear", obj.MonthYear);
                Parameters.Add("@Amount1", obj.Amount1);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeDeductionModel>("USP_HRMS_EmployeeDeduction", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }







    }
}