using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.SupplierMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.SupplierMaster
{
    public class SupplierOpeningBalance_DL
    {
        public List<OpeningBalanceModel> GetCode(string Querytype, string PageName)
        {
            List<OpeningBalanceModel> obj = new List<OpeningBalanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<OpeningBalanceModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OpeningBalanceModel AddUpdate(OpeningBalanceModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", obj.ID);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@CompanyID", obj.CompanyID);
                queryParameters.Add("@SupplierID", obj.SupplierID);               
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<OpeningBalanceModel>("USP_SupplierOpeningBalance", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public OpeningBalanceModel AddUpdateBulk(OpeningBalanceModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@OpeningBalanceDetID", obj.ID);
                queryParameters.Add("@InvoiceDate", Convert.ToDateTime(obj.InvoiceDate));
                queryParameters.Add("@InvoiceNumber", obj.InvoiceNumber);
                queryParameters.Add("@ToAccountID", obj.ToAccountID);
                queryParameters.Add("@LPONO", obj.LPONO);
                queryParameters.Add("@TotalAmount", obj.TotalAmount);
                queryParameters.Add("@PaidAmount", obj.PaidAmount);
                queryParameters.Add("@BalanceAmount", obj.BalanceAmount);
                queryParameters.Add("@IsAction", obj.IsAction);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<OpeningBalanceModel>("USP_SupplierOpeningBalanceDetails", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<OpeningBalanceModel> ToList()
        {
            List<OpeningBalanceModel> obj = new List<OpeningBalanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "42");
                obj = DBHelperDapper.DAAddAndReturnModelList<OpeningBalanceModel>("USP_SUpplierOpneningBalance_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OpeningBalanceModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<OpeningBalanceModel> obj = new List<OpeningBalanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<OpeningBalanceModel>("USP_SUpplierOpneningBalance_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OpeningBalanceModel DeleteTable(string QueryType, Int64 DeptId)
        {
            OpeningBalanceModel objmodel = new OpeningBalanceModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", QueryType);
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<OpeningBalanceModel>("USP_SupplierOpeningBalance", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OpeningBalanceModel> SearchSupplier(string Querytype, string SearchKey)
        {
            List<OpeningBalanceModel> obj = new List<OpeningBalanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<OpeningBalanceModel>("USP_SUpplierOpneningBalance_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}