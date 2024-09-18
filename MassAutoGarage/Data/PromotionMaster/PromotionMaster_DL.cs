using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.ColorMaster;
using MassAutoGarage.Models.PramotionMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.PromotionMaster
{
    public class PromotionMaster_DL
    {
        public PramotionMasterModel AddUpdate(PramotionMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));                
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@PromotionName", obj.PromotionName);
                queryParameters.Add("@PeriodFromDate",Convert.ToDateTime(obj.PeriodFromDate));
                queryParameters.Add("@ToDate", Convert.ToDateTime(obj.ToDate));
                queryParameters.Add("@ServiceID", obj.ServiceID);
                queryParameters.Add("@Discount", obj.Discount);
                queryParameters.Add("@DiscountAmount", obj.DiscountAmount);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<PramotionMasterModel>("USP_PromotionMaster_ADDUpdate", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<PramotionMasterModel> ToList()
        {
            List<PramotionMasterModel> obj = new List<PramotionMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<PramotionMasterModel>("USP_PromotionMaster_Details", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PramotionMasterModel> LoadPromotionList()
        {
            List<PramotionMasterModel> obj = new List<PramotionMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<PramotionMasterModel>("USP_PromotionMaster_Details", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PramotionMasterModel> GetlstIdWise(string Querytype, Int64 UserId)
        {
            List<PramotionMasterModel> obj = new List<PramotionMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", UserId);

                obj = DBHelperDapper.DAAddAndReturnModelList<PramotionMasterModel>("USP_PromotionMaster_Details", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PramotionMasterModel Delete(Int64 UserID)
        {
            PramotionMasterModel obj = new PramotionMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", UserID);
                obj = DBHelperDapper.DAAddAndReturnModel<PramotionMasterModel>("USP_PromotionMaster_ADDUpdate", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PramotionMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<PramotionMasterModel> obj = new List<PramotionMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<PramotionMasterModel>("USP_PromotionMaster_Details", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PramotionMasterModel> GetCode(string Querytype, string PageName)
        {
            List<PramotionMasterModel> obj = new List<PramotionMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<PramotionMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}