using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.CylinderMaster;
using MassAutoGarage.Models.JobCategoryMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.JobCategoryMaster
{
    public class JobCategoryMaster_DL
    {
        public JobCategoryMasterModel AddUpdate(JobCategoryMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@JobCategory", obj.JobCategory);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<JobCategoryMasterModel>("USP_JobCategoryMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<JobCategoryMasterModel> ToList()
        {
            List<JobCategoryMasterModel> obj = new List<JobCategoryMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<JobCategoryMasterModel>("USP_JobCategoryMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<JobCategoryMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<JobCategoryMasterModel> obj = new List<JobCategoryMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<JobCategoryMasterModel>("USP_JobCategoryMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JobCategoryMasterModel Delete(Int64 DeptId)
        {
            JobCategoryMasterModel objmodel = new JobCategoryMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<JobCategoryMasterModel>("USP_JobCategoryMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<JobCategoryMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<JobCategoryMasterModel> obj = new List<JobCategoryMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<JobCategoryMasterModel>("USP_JobCategoryMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<JobCategoryMasterModel> GetCode(string Querytype, string PageName)
        {
            List<JobCategoryMasterModel> obj = new List<JobCategoryMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<JobCategoryMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}