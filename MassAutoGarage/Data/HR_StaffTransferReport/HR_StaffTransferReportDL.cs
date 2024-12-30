using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_ResumingDuty;
using MassAutoGarage.Models.HR_StaffTransferReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HR_StaffTransferReport
{
    public class HR_StaffTransferReportDL
    {
        public List<HR_StaffTransferReportModel> ddlEmployee()
        {
            List<HR_StaffTransferReportModel> obj = new List<HR_StaffTransferReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_StaffTransferReportModel> ddlDesignation()
        {
            List<HR_StaffTransferReportModel> obj = new List<HR_StaffTransferReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_StaffTransferReportModel> ddlBranch()
        {
            List<HR_StaffTransferReportModel> obj = new List<HR_StaffTransferReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public List<HR_StaffTransferReportModel> GetMaxVoucher()
        {
            List<HR_StaffTransferReportModel> obj = new List<HR_StaffTransferReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_StaffTransferReportModel AddUpdate(HR_StaffTransferReportModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@EmployeeID", obj.EmployeeId);
                Parameters.Add("@Date", obj.Date);
                Parameters.Add("@DesignationID", obj.DesignationId);
                Parameters.Add("@EmpNo", obj.EmpNo);
                Parameters.Add("@DateofJoining", obj.DateofJoining);
                Parameters.Add("@BranchDeptFrom", obj.BranchDeptFrom);
                Parameters.Add("@BranchDeptTo", obj.BranchDeptTo);
                Parameters.Add("@TimeofJoining", obj.TimeofJoining);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_StaffTransferReportModel> GetStaffTransferReportList()
        {
            List<HR_StaffTransferReportModel> obj = new List<HR_StaffTransferReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_StaffTransferReportModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_StaffTransferReportModel> obj = new List<HR_StaffTransferReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_StaffTransferReportModel> GetStaffTransferReportDetaildById(HR_StaffTransferReportModel objmodel)
        {
            List<HR_StaffTransferReportModel> obj = new List<HR_StaffTransferReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_StaffTransferReportModel DeleteStaffTransferReport(HR_StaffTransferReportModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_StaffTransferReportModel>("USP_HR_StaffTransferReport", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}