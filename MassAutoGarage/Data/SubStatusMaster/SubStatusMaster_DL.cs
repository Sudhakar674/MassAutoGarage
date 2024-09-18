using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.SalesmanMaster;
using MassAutoGarage.Models.SubStatusMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.SubStatusMaster
{
    public class SubStatusMaster_DL
    {
        public SubStatusMasterModel AddUpdate(SubStatusMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@SubStatus", obj.SubStatus);               
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<SubStatusMasterModel>("USP_SubStatusMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<SubStatusMasterModel> ToList()
        {
            List<SubStatusMasterModel> obj = new List<SubStatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<SubStatusMasterModel>("USP_SubStatusMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SubStatusMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<SubStatusMasterModel> obj = new List<SubStatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<SubStatusMasterModel>("USP_SubStatusMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SubStatusMasterModel Delete(Int64 DeptId)
        {
            SubStatusMasterModel objmodel = new SubStatusMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<SubStatusMasterModel>("USP_SubStatusMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SubStatusMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<SubStatusMasterModel> obj = new List<SubStatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<SubStatusMasterModel>("USP_SubStatusMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SubStatusMasterModel> GetCode(string Querytype, string PageName)
        {
            List<SubStatusMasterModel> obj = new List<SubStatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<SubStatusMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}