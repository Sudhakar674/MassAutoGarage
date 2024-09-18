using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.LeadSourceMaster;
using MassAutoGarage.Models.PriorityMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.LeadSourceMaster
{
    public class LeadSourceMaster_DL
    {
        public LeadSourceMasterModel AddUpdate(LeadSourceMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@LeadSource", obj.LeadSource);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<LeadSourceMasterModel>("USP_LeadSourceMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<LeadSourceMasterModel> ToList()
        {
            List<LeadSourceMasterModel> obj = new List<LeadSourceMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<LeadSourceMasterModel>("USP_LeadSourceMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LeadSourceMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<LeadSourceMasterModel> obj = new List<LeadSourceMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<LeadSourceMasterModel>("USP_LeadSourceMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LeadSourceMasterModel Delete(Int64 DeptId)
        {
            LeadSourceMasterModel objmodel = new LeadSourceMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<LeadSourceMasterModel>("USP_LeadSourceMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LeadSourceMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<LeadSourceMasterModel> obj = new List<LeadSourceMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<LeadSourceMasterModel>("USP_LeadSourceMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LeadSourceMasterModel> GetCode(string Querytype, string PageName)
        {
            List<LeadSourceMasterModel> obj = new List<LeadSourceMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<LeadSourceMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}