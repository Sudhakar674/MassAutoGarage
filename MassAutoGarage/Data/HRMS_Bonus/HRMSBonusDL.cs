using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Models.HRMS_Bonus;
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

        public List<HRMSBonusModel> DropdownList()
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



        public HRMSBonusModel AddUpdate(HRMSBonusModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@BonusAmount", obj.BonusAmount);
                Parameters.Add("@BonusDate", obj.BonusDate);
                Parameters.Add("@Remarks", obj.Remarks);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSBonusModel>("USP_HRMS_Bonus", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<HRMSBonusModel> GetBonusList()
        {
            List<HRMSBonusModel> obj = new List<HRMSBonusModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSBonusModel>("USP_HRMS_Bonus", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSBonusModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSBonusModel> obj = new List<HRMSBonusModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSBonusModel>("USP_HRMS_Bonus", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<HRMSBonusModel> GetBonusDetailsById(HRMSBonusModel objmodel)
        {
            List<HRMSBonusModel> obj = new List<HRMSBonusModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idencrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSBonusModel>("USP_HRMS_Bonus", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSBonusModel DeleteBonusDetails(HRMSBonusModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idencrept);
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