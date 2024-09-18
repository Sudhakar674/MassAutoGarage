using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.SalesmanMaster;
using MassAutoGarage.Models.SourceMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.SalemanMaster
{
    public class SalesmanMaster_DL
    {
        public SalesmanMasterModel AddUpdate(SalesmanMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@SalesMan", obj.SalesMan);
                queryParameters.Add("@Mobile", obj.Mobile);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<SalesmanMasterModel>("USP_SalesManMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<SalesmanMasterModel> ToList()
        {
            List<SalesmanMasterModel> obj = new List<SalesmanMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<SalesmanMasterModel>("USP_SalesManMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesmanMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<SalesmanMasterModel> obj = new List<SalesmanMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<SalesmanMasterModel>("USP_SalesManMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SalesmanMasterModel Delete(Int64 DeptId)
        {
            SalesmanMasterModel objmodel = new SalesmanMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<SalesmanMasterModel>("USP_SalesManMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesmanMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<SalesmanMasterModel> obj = new List<SalesmanMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<SalesmanMasterModel>("USP_SalesManMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesmanMasterModel> GetCode(string Querytype, string PageName)
        {
            List<SalesmanMasterModel> obj = new List<SalesmanMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<SalesmanMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}