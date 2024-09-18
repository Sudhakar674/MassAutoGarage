using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.LeadSourceMaster;
using MassAutoGarage.Models.OrderTypeMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.OrderTypeMaster
{
    public class OrderTypeMaster_DL
    {
        public OrderTypeMasterModel AddUpdate(OrderTypeMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@OrderType", obj.OrderType);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<OrderTypeMasterModel>("USP_OrderTypeMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<OrderTypeMasterModel> ToList()
        {
            List<OrderTypeMasterModel> obj = new List<OrderTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<OrderTypeMasterModel>("USP_OrderTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderTypeMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<OrderTypeMasterModel> obj = new List<OrderTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<OrderTypeMasterModel>("USP_OrderTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderTypeMasterModel Delete(Int64 DeptId)
        {
            OrderTypeMasterModel objmodel = new OrderTypeMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<OrderTypeMasterModel>("USP_OrderTypeMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderTypeMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<OrderTypeMasterModel> obj = new List<OrderTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<OrderTypeMasterModel>("USP_OrderTypeMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OrderTypeMasterModel> GetCode(string Querytype, string PageName)
        {
            List<OrderTypeMasterModel> obj = new List<OrderTypeMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<OrderTypeMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}