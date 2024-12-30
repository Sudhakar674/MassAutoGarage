using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HR_NewStaffJoining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HR_NewStaffJoining
{
    public class HR_NewStaffJoiningDL
    {

        public List<HR_NewStaffJoiningModel> ddlDesignation()
        {
            List<HR_NewStaffJoiningModel> obj = new List<HR_NewStaffJoiningModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
        public List<HR_NewStaffJoiningModel> ddlDepartment()
        {
            List<HR_NewStaffJoiningModel> obj = new List<HR_NewStaffJoiningModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_NewStaffJoiningModel> GetMaxVoucher()
        {
            List<HR_NewStaffJoiningModel> obj = new List<HR_NewStaffJoiningModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_NewStaffJoiningModel AddUpdate(HR_NewStaffJoiningModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNumber", obj.VoucherNumber);
                Parameters.Add("@EmployeeName", obj.EmployeeName);
                Parameters.Add("@Date", obj.Date);
                Parameters.Add("@DesignationID", obj.DesignationId);
                Parameters.Add("@EmpNo", obj.EmpNo);
                Parameters.Add("@DepartmentID", obj.DepartmentId);
                Parameters.Add("@JoiningDate", obj.JoiningDate);
                Parameters.Add("@JoiningTime", obj.JoiningTime);
                Parameters.Add("@FilledByEmployee", obj.FilledByEmployee);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_NewStaffJoiningModel> GetNewStopJoiningList()
        {
            List<HR_NewStaffJoiningModel> obj = new List<HR_NewStaffJoiningModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_NewStaffJoiningModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_NewStaffJoiningModel> obj = new List<HR_NewStaffJoiningModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_NewStaffJoiningModel> GetNewStaffJoiningDetaildById(HR_NewStaffJoiningModel objmodel)
        {
            List<HR_NewStaffJoiningModel> obj = new List<HR_NewStaffJoiningModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_NewStaffJoiningModel DeleteNewStaffJoining(HR_NewStaffJoiningModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_NewStaffJoiningModel>("USP_HR_NewStaffJoining", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}