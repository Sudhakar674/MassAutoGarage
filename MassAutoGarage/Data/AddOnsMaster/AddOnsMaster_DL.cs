using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.AddOnsMaster;
using MassAutoGarage.Models.ColorMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.AddOnsMaster
{
    public class AddOnsMaster_DL
    {
        public AddOnsMasterModel AddUpdate(AddOnsMasterModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@VoucherCode", obj.Code);
                queryParameters.Add("@ServiceID", obj.ServiceID);
                queryParameters.Add("@Comission", obj.Comission);
                queryParameters.Add("@ComissionAmount", obj.ComissionAmount);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);               
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<AddOnsMasterModel>("USP_InsertUpdated_AddONSMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public List<AddOnsMasterModel> ToList()
        {
            List<AddOnsMasterModel> obj = new List<AddOnsMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<AddOnsMasterModel>("USP_GetAddONSMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<AddOnsMasterModel> GetlstIdWise(string Querytype, Int64 AddONSID)
        {
            List<AddOnsMasterModel> obj = new List<AddOnsMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", AddONSID);

                obj = DBHelperDapper.DAAddAndReturnModelList<AddOnsMasterModel>("USP_GetAddONSMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AddOnsMasterModel Delete(Int64 AddONSID)
        {
            AddOnsMasterModel obj = new AddOnsMasterModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@Id", AddONSID);
                obj = DBHelperDapper.DAAddAndReturnModel<AddOnsMasterModel>("USP_InsertUpdated_AddONSMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AddOnsMasterModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<AddOnsMasterModel> obj = new List<AddOnsMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<AddOnsMasterModel>("USP_GetAddONSMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AddOnsMasterModel> GetCode(string Querytype, string PageName)
        {
            List<AddOnsMasterModel> obj = new List<AddOnsMasterModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<AddOnsMasterModel>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}