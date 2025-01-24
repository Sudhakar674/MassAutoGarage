using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace MassAutoGarage.Data.HR_RenualAndNonRenwal
{
    public class HR_RenualAndNonRenwalDL
    {

        public List<HR_RenualAndNonRenwalModel> ddlEmployee()
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_RenualAndNonRenwalModel> ddlDesignation()
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_RenualAndNonRenwalModel> ddlBranch()
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_RenualAndNonRenwalModel> ddlDepartment()
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_RenualAndNonRenwalModel> GetMaxVoucher()
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "36");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_RenualAndNonRenwalModel AddUpdate(HR_RenualAndNonRenwalModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@EmployeeID", obj.EmployeeId);
                Parameters.Add("@DateOfJoined", obj.DateOfJoined);
                Parameters.Add("@DesignationID", obj.DesignationId);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@DepartmentID", obj.DepartmentId);
                Parameters.Add("@Renew", obj.Renew);
                Parameters.Add("@NotRenewing", obj.NotRenewing);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_RenualAndNonRenwalModel> GetRenualAndNonRenwalList()
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_RenualAndNonRenwalModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_RenualAndNonRenwalModel> GetRenualAndNonRenwalDetaildById(HR_RenualAndNonRenwalModel objmodel)
        {
            List<HR_RenualAndNonRenwalModel> obj = new List<HR_RenualAndNonRenwalModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_RenualAndNonRenwalModel DeleteRenualAndNonRenwal(HR_RenualAndNonRenwalModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_RenualAndNonRenwalModel>("USP_HR_RenewAndNotRenewingForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}