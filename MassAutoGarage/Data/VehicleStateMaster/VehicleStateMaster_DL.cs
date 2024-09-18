using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.PlateCodeMaster;
using MassAutoGarage.Models.VehicleStateMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.VehicleStateMaster
{
    public class VehicleStateMaster_DL
    {
        public VehicleStateMasterModel AddUpdate(VehicleStateMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@VehicleState", obj.VehicleState);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<VehicleStateMasterModel>("USP_VehicleStateMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<VehicleStateMasterModel> ToList()
        {
            List<VehicleStateMasterModel> obj = new List<VehicleStateMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleStateMasterModel>("USP_VehicleStateMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VehicleStateMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<VehicleStateMasterModel> obj = new List<VehicleStateMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleStateMasterModel>("USP_VehicleStateMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VehicleStateMasterModel Delete(Int64 DeptId)
        {
            VehicleStateMasterModel objmodel = new VehicleStateMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<VehicleStateMasterModel>("USP_VehicleStateMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VehicleStateMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<VehicleStateMasterModel> obj = new List<VehicleStateMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleStateMasterModel>("USP_VehicleStateMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VehicleStateMasterModel> GetCode(string Querytype, string PageName)
        {
            List<VehicleStateMasterModel> obj = new List<VehicleStateMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<VehicleStateMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}