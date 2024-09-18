using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.ChargerTypeMaster;
using MassAutoGarage.Models.PlateCodeMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.PlateCodeMaster
{
    public class PlateCodeMaster_DL
    {
        public PlateCodeMasterModel AddUpdate(PlateCodeMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@PlateCode", obj.PlateCode);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<PlateCodeMasterModel>("USP_PlateCodeMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<PlateCodeMasterModel> ToList()
        {
            List<PlateCodeMasterModel> obj = new List<PlateCodeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<PlateCodeMasterModel>("USP_PlateCodeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PlateCodeMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<PlateCodeMasterModel> obj = new List<PlateCodeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<PlateCodeMasterModel>("USP_PlateCodeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PlateCodeMasterModel Delete(Int64 DeptId)
        {
            PlateCodeMasterModel objmodel = new PlateCodeMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<PlateCodeMasterModel>("USP_PlateCodeMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PlateCodeMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<PlateCodeMasterModel> obj = new List<PlateCodeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<PlateCodeMasterModel>("USP_PlateCodeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PlateCodeMasterModel> GetCode(string Querytype, string PageName)
        {
            List<PlateCodeMasterModel> obj = new List<PlateCodeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<PlateCodeMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}