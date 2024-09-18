using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.PriorityMaster;
using MassAutoGarage.Models.SalesmanMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.PriorityMaster
{
    public class PriorityMaster_DL
    {
        public PriorityMasterModel AddUpdate(PriorityMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@Priority", obj.Priority);              
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<PriorityMasterModel>("USP_PriorityMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<PriorityMasterModel> ToList()
        {
            List<PriorityMasterModel> obj = new List<PriorityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<PriorityMasterModel>("USP_PriorityMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PriorityMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<PriorityMasterModel> obj = new List<PriorityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<PriorityMasterModel>("USP_PriorityMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PriorityMasterModel Delete(Int64 DeptId)
        {
            PriorityMasterModel objmodel = new PriorityMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<PriorityMasterModel>("USP_PriorityMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PriorityMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<PriorityMasterModel> obj = new List<PriorityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<PriorityMasterModel>("USP_PriorityMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PriorityMasterModel> GetCode(string Querytype, string PageName)
        {
            List<PriorityMasterModel> obj = new List<PriorityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<PriorityMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}