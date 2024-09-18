using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.ChargerTypeMaster;
using MassAutoGarage.Models.JobCategoryMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.ChargerTypeMaster
{
    public class ChargerTypeMaster_DL
    {
        public ChargerTypeMasterModel AddUpdate(ChargerTypeMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@ChargerType", obj.ChargerType);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<ChargerTypeMasterModel>("USP_ChargerTypeMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ChargerTypeMasterModel> ToList()
        {
            List<ChargerTypeMasterModel> obj = new List<ChargerTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<ChargerTypeMasterModel>("USP_ChargerTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChargerTypeMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<ChargerTypeMasterModel> obj = new List<ChargerTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<ChargerTypeMasterModel>("USP_ChargerTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ChargerTypeMasterModel Delete(Int64 DeptId)
        {
            ChargerTypeMasterModel objmodel = new ChargerTypeMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<ChargerTypeMasterModel>("USP_ChargerTypeMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChargerTypeMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<ChargerTypeMasterModel> obj = new List<ChargerTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<ChargerTypeMasterModel>("USP_ChargerTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChargerTypeMasterModel> GetCode(string Querytype, string PageName)
        {
            List<ChargerTypeMasterModel> obj = new List<ChargerTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<ChargerTypeMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}