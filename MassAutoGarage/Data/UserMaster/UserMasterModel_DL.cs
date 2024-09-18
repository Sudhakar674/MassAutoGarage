using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.UserMaster
{
    public class UserMasterModel_DL
    {
        public UserMasterModel AddUpd(UserMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Id", Convert.ToInt64(obj.Id));
                queryParameters.Add("@UserName", obj.UserName);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@UserTypeId", obj.UserTypeId);
                queryParameters.Add("@LoginId", obj.LoginId);
                queryParameters.Add("@Password", obj.Password);
                queryParameters.Add("@CompanyId", obj.CompanyId);
                queryParameters.Add("@StartDate", obj.SDate);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);               
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<UserMasterModel>("USP_UserMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<UserMasterModel> ToList()
        {
            List<UserMasterModel> obj = new List<UserMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<UserMasterModel>("USP_UserMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserMasterModel> GetUserMasterIdWise(string Querytype, Int64 UserId)
        {
            List<UserMasterModel> obj = new List<UserMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", UserId);

                obj = DBHelperDapper.DAAddAndReturnModelList<UserMasterModel>("USP_UserMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserMasterModel Delete(Int64 UserID)
        {
            UserMasterModel obj = new UserMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", UserID);
                obj = DBHelperDapper.DAAddAndReturnModel<UserMasterModel>("USP_UserMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserMasterModel> SearchUserMaster(string Querytype, string SearchKey)
        {
            List<UserMasterModel> obj = new List<UserMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<UserMasterModel>("USP_UserMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserMasterModel> GetCode(string Querytype, string PageName)
        {
            List<UserMasterModel> obj = new List<UserMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<UserMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}