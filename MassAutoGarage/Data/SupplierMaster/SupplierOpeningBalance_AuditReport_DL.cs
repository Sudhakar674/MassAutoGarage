using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.SupplierAuditDetails;
using MassAutoGarage.Models.SupplierMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.SupplierMaster
{
    public class SupplierOpeningBalance_AuditReport_DL
    {
        public List<SupplierOpeningBalanceAudit> ToList()
        {
            List<SupplierOpeningBalanceAudit> obj = new List<SupplierOpeningBalanceAudit>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierOpeningBalanceAudit>("USP_SupplierOpeningBalance_AuditReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SupplierOpeningBalanceAudit> GetlstIdWise(string Querytype, string GroupID)
        {
            List<SupplierOpeningBalanceAudit> obj = new List<SupplierOpeningBalanceAudit>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<SupplierOpeningBalanceAudit>("USP_SupplierOpeningBalance_AuditReport", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}