using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.CompanyMaster
{
    public class CompanyMaster_DL
    {
        public CompanyMasterModel AddUpdate(CompanyMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@GroupID", obj.GroupID);
                queryParameters.Add("@CompanyName", obj.CompanyName);
                queryParameters.Add("@Address", obj.Address);
                queryParameters.Add("@TRN", obj.TRN);
                queryParameters.Add("@Email", obj.Email);
                queryParameters.Add("@LocationMapUrl", obj.LocationMapUrl);
                queryParameters.Add("@CompanyLogo", obj.CompanyLogo);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@Id", Convert.ToInt64(obj.Id));
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<CompanyMasterModel>("USP_AddUpdateCompanyMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<CompanyMasterModel> ToList()
        {
            List<CompanyMasterModel> obj = new List<CompanyMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "42");              
                obj = DBHelperDapper.DAAddAndReturnModelList<CompanyMasterModel>("USP_CompanyMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CompanyMasterModel> GetCompanyMasterdtlsIdWise(string Querytype, Int64 GroupID)
        {
            List<CompanyMasterModel> obj = new List<CompanyMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@Id", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<CompanyMasterModel>("USP_CompanyMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CompanyMasterModel Delete(Int64 CompanyId)
        {
            CompanyMasterModel objmodel = new CompanyMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", CompanyId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<CompanyMasterModel>("USP_AddUpdateCompanyMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CompanyMasterModel> SearchCompanyMaster(string Querytype, string SearchKey)
        {
            List<CompanyMasterModel> obj = new List<CompanyMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<CompanyMasterModel>("USP_CompanyMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CompanyMasterModel> GetCode(string Querytype, string PageName)
        {
            List<CompanyMasterModel> obj = new List<CompanyMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<CompanyMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}