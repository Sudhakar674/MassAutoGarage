using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.CylinderMaster;
using MassAutoGarage.Models.VehicleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.CylinderMaster
{
    public class CylinderMaster_DL
    {
        public CylinderMasterModel AddUpdate(CylinderMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@Cylinder", obj.Cylinder);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<CylinderMasterModel>("USP_CylinderMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<CylinderMasterModel> ToList()
        {
            List<CylinderMasterModel> obj = new List<CylinderMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<CylinderMasterModel>("USP_CylinderMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CylinderMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<CylinderMasterModel> obj = new List<CylinderMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<CylinderMasterModel>("USP_CylinderMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CylinderMasterModel Delete(Int64 DeptId)
        {
            CylinderMasterModel objmodel = new CylinderMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<CylinderMasterModel>("USP_CylinderMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CylinderMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<CylinderMasterModel> obj = new List<CylinderMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<CylinderMasterModel>("USP_CylinderMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CylinderMasterModel> GetCode(string Querytype, string PageName)
        {
            List<CylinderMasterModel> obj = new List<CylinderMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<CylinderMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}