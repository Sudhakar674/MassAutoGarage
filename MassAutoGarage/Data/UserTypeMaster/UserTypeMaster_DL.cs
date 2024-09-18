using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.UserTypeMaster
{
    public class UserTypeMaster_DL
    {
        public UserTypeMasterModel AddUpd(UserTypeMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@UserType", obj.UserType);
                queryParameters.Add("@Id", Convert.ToInt64(obj.Id));
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<UserTypeMasterModel>("USP_UserTypeMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<UserTypeMasterModel> ToList()
        {
            List<UserTypeMasterModel> obj = new List<UserTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<UserTypeMasterModel>("USP_UserTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserTypeMasterModel> GetUserTypeMasterIdWise(string Querytype, Int64 UserId)
        {
            List<UserTypeMasterModel> obj = new List<UserTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@UserId", UserId);

                obj = DBHelperDapper.DAAddAndReturnModelList<UserTypeMasterModel>("USP_UserTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserTypeMasterModel Delete(Int64 UserID)
        {
            UserTypeMasterModel obj = new UserTypeMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", UserID);
                obj = DBHelperDapper.DAAddAndReturnModel<UserTypeMasterModel>("USP_UserTypeMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserTypeMasterModel> SearchUserType(string Querytype, string SearchKey)
        {
            List<UserTypeMasterModel> obj = new List<UserTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<UserTypeMasterModel>("USP_UserTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserTypeMasterModel> GetCode(string Querytype, string PageName)
        {
            List<UserTypeMasterModel> obj = new List<UserTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<UserTypeMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}