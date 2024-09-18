using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Data.CompanyMaster
{
    public class DbMaster
    {
        public static List<SelectListItem> Dropdown(string QueryType, int value)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@QueryType", QueryType);
                queryParameters.Add("@Id", value);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("USP_CompanyMaster", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> DropdownList(string QueryType, int value)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@QueryType", QueryType);
                queryParameters.Add("@Value", value);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("USP_BindDropdownList", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserMasterModel> getValue(string QueryType, int value, int Id)
        {
            List<UserMasterModel> obj = new List<UserMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", QueryType);
                perm.Add("@Value", value);
                perm.Add("@Id", Id);
                obj = DBHelperDapper.DAAddAndReturnModelList<UserMasterModel>("USP_BindDropdownList", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CompanyMasterModel> GetCompanyLogo(Int64 UserId)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserID", UserId);
                List<CompanyMasterModel> _Iresult = DBHelperDapper.DAAddAndReturnModelList<CompanyMasterModel>("USP_GetCompanyLogo", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}