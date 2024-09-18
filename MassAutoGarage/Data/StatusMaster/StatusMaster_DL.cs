using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DepartmentMaster;
using MassAutoGarage.Models.StatusMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.StatusMaster
{
    public class StatusMaster_DL
    {
        public StatusMasterModel AddUpdate(StatusMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@StatusName", obj.Status);              
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);               
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<StatusMasterModel>("USP_StatusMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<StatusMasterModel> ToList()
        {
            List<StatusMasterModel> obj = new List<StatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<StatusMasterModel>("USP_StatusMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StatusMasterModel> GetStatusstIdWise(string Querytype, Int64 GroupID)
        {
            List<StatusMasterModel> obj = new List<StatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<StatusMasterModel>("USP_StatusMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StatusMasterModel Delete(Int64 DeptId)
        {
            StatusMasterModel objmodel = new StatusMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<StatusMasterModel>("USP_StatusMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StatusMasterModel> SearchDepartmentMaster(string Querytype, string SearchKey)
        {
            List<StatusMasterModel> obj = new List<StatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<StatusMasterModel>("USP_StatusMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StatusMasterModel> GetCode(string Querytype, string PageName)
        {
            List<StatusMasterModel> obj = new List<StatusMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<StatusMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}