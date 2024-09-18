using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.VATMaster
{
    public class VATMaster_DL
    {
        public VATMasterModel AddUpd(VATMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Id", Convert.ToInt64(obj.Id));
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@CompanyId", obj.CompanyId);
                queryParameters.Add("@VAT", obj.VAT);
                queryParameters.Add("@StartDate", obj.StrDate);
                queryParameters.Add("@EndDate", obj.EdingDate);
                queryParameters.Add("@Printing", obj.Printing);               
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@CurrentCount", obj.CurrentCount);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<VATMasterModel>("USP_VAT_Master", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<VATMasterModel> ToList()
        {
            List<VATMasterModel> obj = new List<VATMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<VATMasterModel>("USP_VAT_MasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VATMasterModel> GetVATMasterIdWise(string Querytype, Int64 UserId)
        {
            List<VATMasterModel> obj = new List<VATMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", UserId);

                obj = DBHelperDapper.DAAddAndReturnModelList<VATMasterModel>("USP_VAT_MasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VATMasterModel> SearchVATMaster(string Querytype, string SearchKey)
        {
            List<VATMasterModel> obj = new List<VATMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<VATMasterModel>("USP_VAT_MasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VATMasterModel Delete(Int64 VatID)
        {
            VATMasterModel obj = new VATMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", VatID);
                obj = DBHelperDapper.DAAddAndReturnModel<VATMasterModel>("USP_VAT_Master", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VATMasterModel> GetCode(string Querytype, string PageName)
        {
            List<VATMasterModel> obj = new List<VATMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<VATMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}