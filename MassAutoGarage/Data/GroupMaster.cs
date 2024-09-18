using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.PramotionMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Dapper.SqlMapper;

namespace MassAutoGarage.Data
{
    public class GroupMaster
    {

        public GroupMasterModel Add(GroupMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType",obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@GroupName", obj.GroupName);
                queryParameters.Add("@Id",Convert.ToInt64(obj.Id));
                queryParameters.Add("@CreatedBy",obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<GroupMasterModel>("USP_GroupCompanyMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }
            


        }

        public List<GroupMasterModel> ToList()
        {
            List<GroupMasterModel> obj = new List<GroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<GroupMasterModel>("USP_GetGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GroupMasterModel> GetGroupMasterIdWise(string Querytype, Int64 GroupID)
        {
            List<GroupMasterModel> obj = new List<GroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@GroupId", GroupID);
           
                obj = DBHelperDapper.DAAddAndReturnModelList<GroupMasterModel>("USP_GetGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GroupMasterModel Delete(Int64 BranchId)
        {
            GroupMasterModel obj = new GroupMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", BranchId);
                obj = DBHelperDapper.DAAddAndReturnModel<GroupMasterModel>("USP_GroupCompanyMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GroupMasterModel> SearchGroupMaster(string Querytype, string SearchKey)
        {
            List<GroupMasterModel> obj = new List<GroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<GroupMasterModel>("USP_GetGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GroupMasterModel> GetCode(string Querytype, string PageName)
        {
            List<GroupMasterModel> obj = new List<GroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<GroupMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}