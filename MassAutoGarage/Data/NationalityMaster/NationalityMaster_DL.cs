using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DepartmentMaster;
using MassAutoGarage.Models.NationalityMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.NationalityMaster
{
    public class NationalityMaster_DL
    {
        public NationalityMasterModel AddUpdate(NationalityMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@Nationality", obj.Nationality);              
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<NationalityMasterModel>("USP_NationalityMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<NationalityMasterModel> ToList()
        {
            List<NationalityMasterModel> obj = new List<NationalityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<NationalityMasterModel>("USP_NationalityMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NationalityMasterModel> GetNationalitylstIdWise(string Querytype, Int64 GroupID)
        {
            List<NationalityMasterModel> obj = new List<NationalityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<NationalityMasterModel>("USP_NationalityMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NationalityMasterModel Delete(Int64 DeptId)
        {
            NationalityMasterModel objmodel = new NationalityMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<NationalityMasterModel>("USP_NationalityMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NationalityMasterModel> SearchNationalityMaster(string Querytype, string SearchKey)
        {
            List<NationalityMasterModel> obj = new List<NationalityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<NationalityMasterModel>("USP_NationalityMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NationalityMasterModel> GetCode(string Querytype, string PageName)
        {
            List<NationalityMasterModel> obj = new List<NationalityMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<NationalityMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}