using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.NationalityMaster;
using MassAutoGarage.Models.SupplierAuditDetails;
using MassAutoGarage.Models.SupplierMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.SupplierMaster
{
    public class SupplierMaster_DL
    {
        public SupplierMasterModel AddUpdate(SupplierMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", obj.ID);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@CompanyID", obj.CompanyID);
                queryParameters.Add("@SupplierName", obj.SupplierName);

                queryParameters.Add("@AccountName", obj.AccountName);
                queryParameters.Add("@LandlineNumber", obj.LandlineNumber);
                queryParameters.Add("@Mobile", obj.Mobile);
                queryParameters.Add("@Email", obj.Email);
                queryParameters.Add("@TRN", obj.TRN);
                queryParameters.Add("@Address", obj.Address);
                queryParameters.Add("@CreationDate", Convert.ToDateTime(obj.CreationDate));
                queryParameters.Add("@CreditDays", obj.CreditDays);

                queryParameters.Add("@CreditLimit", obj.CreditLimit);
                queryParameters.Add("@Block", obj.Block);
                queryParameters.Add("@Reason", obj.Reason);
                queryParameters.Add("@VATSupplierID", obj.VATSupplierID);
                queryParameters.Add("@TradeLicenceExpiry", Convert.ToDateTime(obj.TradeLicenceExpiry));
                queryParameters.Add("@InternationalID", obj.InternationalID);
                queryParameters.Add("@UAEID", obj.UAEID);
                queryParameters.Add("@GCCID", obj.GCCID);
                queryParameters.Add("@ContactPerson", obj.ContactPerson);
                queryParameters.Add("@ContactNumber", obj.ContactNumber);
                queryParameters.Add("@ContactEmail", obj.ContactEmail);
                queryParameters.Add("@Designation", obj.Desination);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                queryParameters.Add("@Photourl", obj.Photourl);
                queryParameters.Add("@Signatureurl", obj.Signatureurl);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<SupplierMasterModel>("USP_SupplierAddUpdate_Details", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public SupplierMasterModel AddUpdateBulk(SupplierMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@SupplierDetID", obj.SupplierID);
                queryParameters.Add("@ExpiryDate", Convert.ToDateTime(obj.ExpiryDate));
                queryParameters.Add("@AttachmentFile", obj.AttachmentFile);
                queryParameters.Add("@Description", obj.Description);
                queryParameters.Add("@IsUpdated", obj.IsUpdated);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<SupplierMasterModel>("USP_ADDUPATE_SupplierAttachmentDetails", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public SupplierMasterModel AddUpdateBulkForContact(SupplierMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@SupplierDetID", obj.SupplierID);
                queryParameters.Add("@ContactPerson", obj.ContactPerson);
                queryParameters.Add("@Mobile", obj.ContactNumber);
                queryParameters.Add("@Email", obj.ContactEmail);
                queryParameters.Add("@Designation", obj.Desination);
                queryParameters.Add("@IsUpdated", obj.IsUpdated);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<SupplierMasterModel>("USP_ADDUPATE_SupplierContactDetails", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public List<SupplierMasterModel> ToList()
        {
            List<SupplierMasterModel> obj = new List<SupplierMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierMasterModel>("USP_GetSupplierDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SupplierMasterModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<SupplierMasterModel> obj = new List<SupplierMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierMasterModel>("USP_GetSupplierDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SupplierMasterModel DeleteTable(string QueryType, Int64 DeptId)
        {
            SupplierMasterModel objmodel = new SupplierMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", QueryType);
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<SupplierMasterModel>("USP_SupplierAddUpdate_Details", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SupplierMasterModel> SearchSupplier(string Querytype, string SearchKey)
        {
            List<SupplierMasterModel> obj = new List<SupplierMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierMasterModel>("USP_GetSupplierDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SupplierAuditDetailsModel> GetSupplierAuditlst(string Querytype, Int64 GroupID)
        {
            List<SupplierAuditDetailsModel> obj = new List<SupplierAuditDetailsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SupplierID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierAuditDetailsModel>("USP_SupplierAuditReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SupplierMasterModel> GetCode(string Querytype, string PageName)
        {
            List<SupplierMasterModel> obj = new List<SupplierMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SupplierMasterModel> GetCodeByID(string Querytype, string Supplierid, string companyid)
        {
            List<SupplierMasterModel> obj = new List<SupplierMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SupplierId", Supplierid);
                perm.Add("@CompanyId", companyid);

                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierMasterModel>("USP_SUpplierOpneningBalance_GetDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}