using Dapper;
using DocumentFormat.OpenXml.Wordprocessing;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HR_Reimbursement;
using MassAutoGarage.Models.HR_WorkHandOverReport;
using MassAutoGarage.Models.HRMS_SalesTarget;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HR_Reimbursement
{
    public class HR_ReimbursementDL
    {

        public List<HR_ReimbursementModel> ddlBranch()
        {
            List<HR_ReimbursementModel> obj = new List<HR_ReimbursementModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ReimbursementModel>("USP_HR_Reimbursement", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ReimbursementModel> GetMaxVoucher()
        {
            List<HR_ReimbursementModel> obj = new List<HR_ReimbursementModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ReimbursementModel>("USP_HR_Reimbursement", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_ReimbursementModel AddUpdate(HR_ReimbursementModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@Name", obj.Name);
                Parameters.Add("@FromDate", obj.FromDate);
                Parameters.Add("@ToDate", obj.ToDate);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_ReimbursementModel>("USP_HR_Reimbursement", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HR_ReimbursementModel AddUpdateBulk(HR_ReimbursementModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@ReimbursementId", obj.ReimbursementId);
                Parameters.Add("@DateOfBill", obj.DateOfBill);
                Parameters.Add("@Description", obj.Description);
                Parameters.Add("@Amount", obj.Amount);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_ReimbursementModel>("USP_HR_Reimbursement", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_ReimbursementModel> GetReimbursementList()
        {
            List<HR_ReimbursementModel> obj = new List<HR_ReimbursementModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ReimbursementModel>("USP_HR_Reimbursement", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ReimbursementModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_ReimbursementModel> obj = new List<HR_ReimbursementModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ReimbursementModel>("USP_HR_Reimbursement", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_ReimbursementModel DeleteReimbursement(HR_ReimbursementModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_ReimbursementModel>("USP_HR_Reimbursement", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_ReimbursementModel> GetReimbursementDetailsById(string Querytype, string Id)
        {
            List<HR_ReimbursementModel> obj = new List<HR_ReimbursementModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@Id", Id);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ReimbursementModel>("USP_HR_Reimbursement", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_ReimbursementModel> GetReimbursementById(HR_ReimbursementModel objmodel)
        {
            List<HR_ReimbursementModel> obj = new List<HR_ReimbursementModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idencrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_ReimbursementModel>("USP_HR_Reimbursement", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}