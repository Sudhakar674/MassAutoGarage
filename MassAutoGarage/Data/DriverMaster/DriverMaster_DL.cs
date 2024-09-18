using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DriverMaster;
using MassAutoGarage.Models.UnitMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.DriverMaster
{
    public class DriverMaster_DL
    {
        public DriverMasterModel AddUpdate(DriverMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@DriverName", obj.DriverName);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<DriverMasterModel>("USP_DriverMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<DriverMasterModel> ToList()
        {
            List<DriverMasterModel> obj = new List<DriverMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<DriverMasterModel>("USP_DriverMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DriverMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<DriverMasterModel> obj = new List<DriverMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<DriverMasterModel>("USP_DriverMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DriverMasterModel Delete(Int64 DeptId)
        {
            DriverMasterModel objmodel = new DriverMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<DriverMasterModel>("USP_DriverMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DriverMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<DriverMasterModel> obj = new List<DriverMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<DriverMasterModel>("USP_DriverMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DriverMasterModel> GetCode(string Querytype, string PageName)
        {
            List<DriverMasterModel> obj = new List<DriverMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<DriverMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}