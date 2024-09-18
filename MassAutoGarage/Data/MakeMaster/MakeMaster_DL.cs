using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.MakeMaster;
using MassAutoGarage.Models.OrderTypeMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.MakeMaster
{
    public class MakeMaster_DL
    {
        public MakeMasterModel AddUpdate(MakeMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@Make", obj.Make);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<MakeMasterModel>("USP_MakeMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<MakeMasterModel> ToList()
        {
            List<MakeMasterModel> obj = new List<MakeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<MakeMasterModel>("USP_MakeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MakeMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<MakeMasterModel> obj = new List<MakeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<MakeMasterModel>("USP_MakeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MakeMasterModel Delete(Int64 DeptId)
        {
            MakeMasterModel objmodel = new MakeMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<MakeMasterModel>("USP_MakeMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MakeMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<MakeMasterModel> obj = new List<MakeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<MakeMasterModel>("USP_MakeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MakeMasterModel> GetCode(string Querytype, string PageName)
        {
            List<MakeMasterModel> obj = new List<MakeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<MakeMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}