using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.CustomerGroupMaster;
using MassAutoGarage.Models.StatusMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.CustomerGroupMaster
{
    public class CustomerGroupMaster_DL
    {
        public CustomerGroupMasterModel AddUpdate(CustomerGroupMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@CustomerGroupName", obj.CustomerGroupName);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<CustomerGroupMasterModel>("USP_CustomerGroupMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<CustomerGroupMasterModel> ToList()
        {
            List<CustomerGroupMasterModel> obj = new List<CustomerGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerGroupMasterModel>("USP_CustomerGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerGroupMasterModel> GetStatusstIdWise(string Querytype, Int64 GroupID)
        {
            List<CustomerGroupMasterModel> obj = new List<CustomerGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerGroupMasterModel>("USP_CustomerGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomerGroupMasterModel Delete(Int64 DeptId)
        {
            CustomerGroupMasterModel objmodel = new CustomerGroupMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<CustomerGroupMasterModel>("USP_CustomerGroupMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerGroupMasterModel> SearchCustomerGroupMaster(string Querytype, string SearchKey)
        {
            List<CustomerGroupMasterModel> obj = new List<CustomerGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerGroupMasterModel>("USP_CustomerGroupMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CustomerGroupMasterModel> GetCode(string Querytype, string PageName)
        {
            List<CustomerGroupMasterModel> obj = new List<CustomerGroupMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerGroupMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}