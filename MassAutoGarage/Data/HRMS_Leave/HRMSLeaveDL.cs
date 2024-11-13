using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Leave;
using MassAutoGarage.Models.HRMS_Loan;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HRMS_Leave
{
    public class HRMSLeaveDL
    {

        public List<HRMSLeaveModel> DropdownList()
        {
            List<HRMSLeaveModel> obj = new List<HRMSLeaveModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLeaveModel>("USP_HRMS_Leave", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSLeaveModel> DropDownEmployeeList()
        {
            List<HRMSLeaveModel> obj = new List<HRMSLeaveModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLeaveModel>("USP_HRMS_Leave", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSLeaveModel> DropDownLeavTypeList()
        {
            List<HRMSLeaveModel> obj = new List<HRMSLeaveModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLeaveModel>("USP_HRMS_Leave", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSLeaveModel AddUpdate(HRMSLeaveModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@LeaveTypeId", obj.LeaveTypeId);
                Parameters.Add("@FromDate", obj.FromDate);
                Parameters.Add("@ToDate", obj.ToDate);
                Parameters.Add("@LeaveCount", obj.LeaveCount);
                Parameters.Add("@BalanceLeave", obj.BalanceLeave);
                Parameters.Add("@Description", obj.Description);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSLeaveModel>("USP_HRMS_Leave", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMSLeaveModel> GetLeaveList()
        {
            List<HRMSLeaveModel> obj = new List<HRMSLeaveModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLeaveModel>("USP_HRMS_Leave", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSLeaveModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSLeaveModel> obj = new List<HRMSLeaveModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLeaveModel>("USP_HRMS_Leave", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSLeaveModel> GetLeaveDetailsById(HRMSLeaveModel objmodel)
        {
            List<HRMSLeaveModel> obj = new List<HRMSLeaveModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idencrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLeaveModel>("USP_HRMS_Leave", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSLeaveModel DeleteLeaveDetails(HRMSLeaveModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSLeaveModel>("USP_HRMS_Leave", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}