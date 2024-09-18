using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.ColorMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.ColorMaster
{
    public class ColorMaster_DL
    {
        public ColorMasterModel AddUpdate(ColorMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@ColorCode", obj.ColorCode);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@ColorId", obj.ColorId);              
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<ColorMasterModel>("USP_ColorDetailsMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<ColorMasterModel> ToList()
        {
            List<ColorMasterModel> obj = new List<ColorMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<ColorMasterModel>("USP_ColorDetailsMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorMasterModel> LoadColorToList()
        {
            List<ColorMasterModel> obj = new List<ColorMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<ColorMasterModel>("USP_GetColor", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ColorMasterModel> GetlstIdWise(string Querytype, Int64 UserId)
        {
            List<ColorMasterModel> obj = new List<ColorMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", UserId);

                obj = DBHelperDapper.DAAddAndReturnModelList<ColorMasterModel>("USP_ColorDetailsMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ColorMasterModel Delete(Int64 UserID)
        {
            ColorMasterModel obj = new ColorMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", UserID);
                obj = DBHelperDapper.DAAddAndReturnModel<ColorMasterModel>("USP_ColorDetailsMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<ColorMasterModel> obj = new List<ColorMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<ColorMasterModel>("USP_ColorDetailsMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorMasterModel> getValue(string QueryType, int value)
        {
            List<ColorMasterModel> obj = new List<ColorMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", QueryType);
                perm.Add("@Value", value);
                
                obj = DBHelperDapper.DAAddAndReturnModelList<ColorMasterModel>("USP_GetColor", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ColorMasterModel> GetCode(string Querytype, string PageName)
        {
            List<ColorMasterModel> obj = new List<ColorMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<ColorMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}