using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.ColorMaster;
using MassAutoGarage.Models.LoyaltyPointMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.LoyaltyPointMaster
{
    public class LoyaltyPointsMaster_DL
    {
        public LoyaltyPointMasterModel AddUpdate(LoyaltyPointMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@SaleValue", obj.SalesValue);
                queryParameters.Add("@ToSaleValue", obj.ToSalesValue);
                queryParameters.Add("@LoyaltyPoints", obj.LoyaltyPoints);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<LoyaltyPointMasterModel>("USP_LoyaltyPointAddUpdate", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<LoyaltyPointMasterModel> ToList()
        {
            List<LoyaltyPointMasterModel> obj = new List<LoyaltyPointMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<LoyaltyPointMasterModel>("USP_LoyaltyPoint_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LoyaltyPointMasterModel> LoadColorToList()
        {
            List<LoyaltyPointMasterModel> obj = new List<LoyaltyPointMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<LoyaltyPointMasterModel>("USP_GetColor", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LoyaltyPointMasterModel> GetlstIdWise(string Querytype, Int64 UserId)
        {
            List<LoyaltyPointMasterModel> obj = new List<LoyaltyPointMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", UserId);

                obj = DBHelperDapper.DAAddAndReturnModelList<LoyaltyPointMasterModel>("USP_LoyaltyPoint_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoyaltyPointMasterModel Delete(Int64 UserID)
        {
            LoyaltyPointMasterModel obj = new LoyaltyPointMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", UserID);
                obj = DBHelperDapper.DAAddAndReturnModel<LoyaltyPointMasterModel>("USP_LoyaltyPointAddUpdate", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LoyaltyPointMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<LoyaltyPointMasterModel> obj = new List<LoyaltyPointMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<LoyaltyPointMasterModel>("USP_LoyaltyPoint_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LoyaltyPointMasterModel> GetCode(string Querytype, string PageName)
        {
            List<LoyaltyPointMasterModel> obj = new List<LoyaltyPointMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<LoyaltyPointMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}