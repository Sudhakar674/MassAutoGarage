using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DiscountGroupMaster;
using MassAutoGarage.Models.VehicleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.DiscountGroupMaster
{
    public class DiscountGroupMaster_DL
    {
        public DiscountGroupMasterModel AddUpdate(DiscountGroupMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@DiscountGroup", obj.DiscountGroup);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<DiscountGroupMasterModel>("USP_DiscountGroupMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<DiscountGroupMasterModel> ToList()
        {
            List<DiscountGroupMasterModel> obj = new List<DiscountGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<DiscountGroupMasterModel>("USP_DiscountGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiscountGroupMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<DiscountGroupMasterModel> obj = new List<DiscountGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<DiscountGroupMasterModel>("USP_DiscountGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DiscountGroupMasterModel Delete(Int64 DeptId)
        {
            DiscountGroupMasterModel objmodel = new DiscountGroupMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<DiscountGroupMasterModel>("USP_DiscountGroupMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiscountGroupMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<DiscountGroupMasterModel> obj = new List<DiscountGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<DiscountGroupMasterModel>("USP_DiscountGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiscountGroupMasterModel> GetCode(string Querytype, string PageName)
        {
            List<DiscountGroupMasterModel> obj = new List<DiscountGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<DiscountGroupMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}