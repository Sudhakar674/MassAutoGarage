using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DepartmentMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.DepartmentMaster
{
    public class DepartmentMaster_DL
    {
        public DepartmentMasterModel AddUpdate(DepartmentMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@DepartmentName", obj.DepartmentName);
                queryParameters.Add("@RevenueAccountID", obj.RevenueAccountID);
                queryParameters.Add("@ExpenseAccountID", obj.ExpenseAccountID);
                queryParameters.Add("@InventoryAccountID", obj.InventoryAccountID);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<DepartmentMasterModel>("USP_DepartmentMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<DepartmentMasterModel> ToList()
        {
            List<DepartmentMasterModel> obj = new List<DepartmentMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<DepartmentMasterModel>("USP_DepartmentMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DepartmentMasterModel> GetDepartmentlstIdWise(string Querytype, Int64 GroupID)
        {
            List<DepartmentMasterModel> obj = new List<DepartmentMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<DepartmentMasterModel>("USP_DepartmentMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DepartmentMasterModel Delete(Int64 DeptId)
        {
            DepartmentMasterModel objmodel = new DepartmentMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<DepartmentMasterModel>("USP_DepartmentMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DepartmentMasterModel> SearchDepartmentMaster(string Querytype, string SearchKey)
        {
            List<DepartmentMasterModel> obj = new List<DepartmentMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<DepartmentMasterModel>("USP_DepartmentMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DepartmentMasterModel> GetCode(string Querytype, string PageName)
        {
            List<DepartmentMasterModel> obj = new List<DepartmentMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<DepartmentMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}