using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_LeaveRequest;
using MassAutoGarage.Models.HR_PassportRelease;
using MassAutoGarage.Models.HR_ResumingDuty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HR_ResumingDuty
{
    public class HR_ResumingDutyDL
    {

        public List<HR_ResumingDutyModel> ddlEmployee()
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_ResumingDutyModel> ddlDesignation()
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_ResumingDutyModel> ddlBranch()
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ResumingDutyModel> ddlDepartment()
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ResumingDutyModel> ddlCompany()
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "36");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ResumingDutyModel> GetMaxVoucher()
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "37");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_ResumingDutyModel AddUpdate(HR_ResumingDutyModel obj)
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
                Parameters.Add("@CompanyID", obj.CompanyId);
                Parameters.Add("@DepartmentID", obj.DepartmentId);
                Parameters.Add("@BranchID", obj.BranchId);
                Parameters.Add("@DateofJoining", obj.DateofJoining);
                Parameters.Add("@DateofResumingDuty", obj.DateofResumingDuty);
                Parameters.Add("@Time", obj.Time);
                Parameters.Add("@PeriodofFromLeave", obj.PeriodofFromLeave);
                Parameters.Add("@PeriodofToLeave", obj.PeriodofToLeave);
                Parameters.Add("@OtherReasons", obj.OtherReasons);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_ResumingDutyModel>("USP_HR_ResumingDuty", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_ResumingDutyModel> GetResumingDutyList()
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ResumingDutyModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ResumingDutyModel> GetResumingDutyDetaildById(HR_ResumingDutyModel objmodel)
        {
            List<HR_ResumingDutyModel> obj = new List<HR_ResumingDutyModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ResumingDutyModel>("USP_HR_ResumingDuty", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_ResumingDutyModel DeleteResumingDuty(HR_ResumingDutyModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_ResumingDutyModel>("USP_HR_ResumingDuty", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}