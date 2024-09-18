using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.CustomerMaster;
using MassAutoGarage.Models.SupplierMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.CustomerMaster
{
    public class CustomerOpeningBalance_DL
    {
        public CustomerOpeningBalanceModel AddUpdate(CustomerOpeningBalanceModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", obj.ID);               
                queryParameters.Add("@CompanyID", obj.CompanyID);
                queryParameters.Add("@JobCardDate", obj.JobCardDate);
                queryParameters.Add("@JobCardNumber", obj.JobCardNumber);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);               

                var _iresult = DBHelperDapper.DAAddAndReturnModel<CustomerOpeningBalanceModel>("USP_CustomerOpeningBalance", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public CustomerOpeningBalanceModel AddUpdateBulk(CustomerOpeningBalanceModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@OpeningBalanceDetID", obj.ID);
                queryParameters.Add("@ToAccountID", obj.ToAccountID);
                queryParameters.Add("@InvoiceDate", Convert.ToDateTime(obj.InvoiceDate));
                queryParameters.Add("@InvoiceNumber", obj.InvoiceNumber);
                queryParameters.Add("@LPONO", obj.LPONO);
                queryParameters.Add("@EstNo", obj.EstNo);
                queryParameters.Add("@TotalAmount", obj.TotalAmount);
                queryParameters.Add("@PaidAmount", obj.PaidAmount);
                queryParameters.Add("@BalanceAmount", obj.BalanceAmount);
                queryParameters.Add("@IsAction", obj.IsAction);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<CustomerOpeningBalanceModel>("USP_CustomerOpeningBalanceDetails", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<CustomerOpeningBalanceModel> ToList()
        {
            List<CustomerOpeningBalanceModel> obj = new List<CustomerOpeningBalanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerOpeningBalanceModel>("USP_CustomerOpneningBalance_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerOpeningBalanceModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<CustomerOpeningBalanceModel> obj = new List<CustomerOpeningBalanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerOpeningBalanceModel>("USP_CustomerOpneningBalance_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomerOpeningBalanceModel DeleteTable(string QueryType, Int64 DeptId)
        {
            CustomerOpeningBalanceModel objmodel = new CustomerOpeningBalanceModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", QueryType);
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<CustomerOpeningBalanceModel>("USP_CustomerOpeningBalance", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerOpeningBalanceModel> SearchCustomer(string Querytype, string SearchKey)
        {
            List<CustomerOpeningBalanceModel> obj = new List<CustomerOpeningBalanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerOpeningBalanceModel>("USP_CustomerOpneningBalance_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}