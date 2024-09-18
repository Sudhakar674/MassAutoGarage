using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DriverMaster;
using MassAutoGarage.Models.VehicleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.VehicleMaster
{
    public class VehicleEngineMaster_DL
    {
        public VehicleEngineMasterModel AddUpdate(VehicleEngineMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@VehicleEngine", obj.VehicleEngine);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<VehicleEngineMasterModel>("USP_VehicleEngineMasterMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<VehicleEngineMasterModel> ToList()
        {
            List<VehicleEngineMasterModel> obj = new List<VehicleEngineMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleEngineMasterModel>("USP_VehicleEngineMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VehicleEngineMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<VehicleEngineMasterModel> obj = new List<VehicleEngineMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleEngineMasterModel>("USP_VehicleEngineMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VehicleEngineMasterModel Delete(Int64 DeptId)
        {
            VehicleEngineMasterModel objmodel = new VehicleEngineMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<VehicleEngineMasterModel>("USP_VehicleEngineMasterMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VehicleEngineMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<VehicleEngineMasterModel> obj = new List<VehicleEngineMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleEngineMasterModel>("USP_VehicleEngineMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VehicleEngineMasterModel> GetCode(string Querytype, string PageName)
        {
            List<VehicleEngineMasterModel> obj = new List<VehicleEngineMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleEngineMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}