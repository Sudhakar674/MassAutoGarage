using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.CustomerMaster;
using MassAutoGarage.Models.SupplierAuditDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.CustomerMaster
{
    public class CustomerOpeningBalanceAudit_DL
    {
        public List<CustomerOpeningBalance_AuditModel> ToList()
        {
            List<CustomerOpeningBalance_AuditModel> obj = new List<CustomerOpeningBalance_AuditModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerOpeningBalance_AuditModel>("USP_CustomerOpeningBalance_AuditReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerOpeningBalance_AuditModel> GetlstIdWise(string Querytype, string GroupID)
        {
            List<CustomerOpeningBalance_AuditModel> obj = new List<CustomerOpeningBalance_AuditModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<CustomerOpeningBalance_AuditModel>("USP_CustomerOpeningBalance_AuditReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}