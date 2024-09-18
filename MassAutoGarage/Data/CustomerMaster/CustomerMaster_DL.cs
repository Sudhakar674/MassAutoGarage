using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.AuditMaster;
using MassAutoGarage.Models.CustomerMaster;
using MassAutoGarage.Models.SupplierAuditDetails;
using MassAutoGarage.Models.SupplierMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.CustomerMaster
{
    public class CustomerMaster_DL
    {
        public CustomerMasterModel AddUpdate(CustomerMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", obj.ID);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@CompanyID", obj.CompanyID);
                queryParameters.Add("@CustomerName", obj.CustomerName);

                queryParameters.Add("@AccountName", obj.AccountName);               
                queryParameters.Add("@ContactPersonName", obj.ContactPersonName);
                queryParameters.Add("@Mobile", obj.Mobile);
                queryParameters.Add("@Address", obj.Address);
                queryParameters.Add("@Email", obj.Email);
                queryParameters.Add("@TRN", obj.TRN);
                queryParameters.Add("@CreationDate",Convert.ToDateTime(obj.CreationDate));

                queryParameters.Add("@CreditDays", obj.CreditDays);
                queryParameters.Add("@CreditLimit", obj.CreditLimit);
                queryParameters.Add("@Block", obj.Block);
                queryParameters.Add("@Reason", obj.Reason);
                queryParameters.Add("@VATCustomerID", obj.VATCustomerID);
                queryParameters.Add("@TradeLicenceExpiry",Convert.ToDateTime(obj.TradeLicenceExpiry));
                queryParameters.Add("@LoyaltyPoints", obj.LoyaltyPoints);
                queryParameters.Add("@InternationalID", obj.InternationalID);
                queryParameters.Add("@UAEID", obj.UAEID);              
                queryParameters.Add("@GCCID", obj.GCCID);
                queryParameters.Add("@GroupName", obj.Group);

                queryParameters.Add("@AdvisorName", obj.AdvisorName);
                queryParameters.Add("@DiscountAllowedAmt", obj.DiscountAllowedAmt);
                queryParameters.Add("@Source", obj.Source);
                queryParameters.Add("@Gender", obj.Gender);
                queryParameters.Add("@DiscountAllowedPercentage", obj.DiscountAllowedPercentage);
                queryParameters.Add("@Salesman", obj.Salesman);
                queryParameters.Add("@Nationality", obj.Nationality);
                queryParameters.Add("@Individualorcompany", obj.Individualorcompany);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);



                var _iresult = DBHelperDapper.DAAddAndReturnModel<CustomerMasterModel>("USP_CustomerMasterAddUpdate_Details", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public CustomerMasterModel AddUpdateBulk(CustomerMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@CustomerDetID", obj.CustomerID);
                queryParameters.Add("@ExpiryDate", Convert.ToDateTime(obj.ExpiryDate));
                queryParameters.Add("@AttachmentFile", obj.AttachmentFile);
                queryParameters.Add("@Description", obj.Description);
                queryParameters.Add("@IsUpdated", obj.IsUpdated);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<CustomerMasterModel>("USP_CustomerAttachmentDetailsAddUppdate", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public CustomerMasterModel AddUpdateBulkForContact(CustomerMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@CustomerDetID", obj.CustomerID);
                queryParameters.Add("@ContactPerson", obj.ContactPerson);
                queryParameters.Add("@ContactNumber", obj.ContactNumber);
                queryParameters.Add("@ContactEmail", obj.ContactEmail);
                queryParameters.Add("@Desination", obj.Desination);
                queryParameters.Add("@IsUpdated", obj.IsUpdated);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<CustomerMasterModel>("USP_CustomerContactDetailsAddUpdate", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public List<CustomerMasterModel> ToList()
        {
            List<CustomerMasterModel> obj = new List<CustomerMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerMasterModel>("USP_GetCustomerDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<CustomerMasterModel> obj = new List<CustomerMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerMasterModel>("USP_GetCustomerDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomerMasterModel DeleteTable(string QueryType, Int64 DeptId)
        {
            CustomerMasterModel objmodel = new CustomerMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", QueryType);
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<CustomerMasterModel>("USP_CustomerMasterAddUpdate_Details", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerMasterModel> SearchSupplier(string Querytype, string SearchKey)
        {
            List<CustomerMasterModel> obj = new List<CustomerMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerMasterModel>("USP_GetCustomerDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerAuditMasterModel> Get_CustomerAuditlst(string Querytype, Int64 GroupID)
        {
            List<CustomerAuditMasterModel> obj = new List<CustomerAuditMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@CustomerID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerAuditMasterModel>("USP_CustomerAuditReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerMasterModel> GetCode(string Querytype, string PageName)
        {
            List<CustomerMasterModel> obj = new List<CustomerMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}