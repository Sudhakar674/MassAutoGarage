using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Models.HRMS_Bonus;
using MassAutoGarage.Models.HRMS_EmployeeDeduction;
using MassAutoGarage.Models.HRMS_EmployeeFamilyDetails;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HRMS_Bonus
{
    public class HRMSBonusDL
    {


        public List<HRMSBonusModel> DropdownBranchList()
        {
            List<HRMSBonusModel> obj = new List<HRMSBonusModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSBonusModel>("USP_HRMS_Bonus", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSBonusModel> DropDownEmployeeList()
        {
            List<HRMSBonusModel> obj = new List<HRMSBonusModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSBonusModel>("USP_HRMS_Bonus", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSBonusModel> DropDeductionTypeTypeList()
        {
            List<HRMSBonusModel> obj = new List<HRMSBonusModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSBonusModel>("USP_HRMS_Bonus", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSBonusModel AddUpdate(HRMSBonusModel obj)
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
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSBonusModel>("USP_HRMS_Bonus", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HRMSBonusModel AddUpdateBulk(HRMSBonusModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BonusId1", obj.BonusId);
                Parameters.Add("@MonthYear", obj.MonthYear);
                Parameters.Add("@Amount1", obj.Amount1);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSBonusModel>("USP_HRMS_Bonus", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }








    }
}