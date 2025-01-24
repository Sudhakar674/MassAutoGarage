using Dapper;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_Reimbursement;
using MassAutoGarage.Models.HR_ResumingDuty;
using MassAutoGarage.Models.HR_WorkHandOverReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ClosedXML.Excel.XLPredefinedFormat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HR_WorkHandOverReport
{
    public class HR_WorkHandOverReportDL
    {
        public List<HR_WorkHandOverReportModel> ddlEmployee()
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_WorkHandOverReportModel> ddlDesignation()
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_WorkHandOverReportModel> ddlBranch()
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_WorkHandOverReportModel> ddlDepartment()
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  

        public List<HR_WorkHandOverReportModel> GetMaxVoucher()
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "37");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_WorkHandOverReportModel AddUpdate(HR_WorkHandOverReportModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@EmployeeID", obj.EmployeeId);
                Parameters.Add("@Date", obj.Date);
                Parameters.Add("@DesignationID", obj.DesignationId);
                Parameters.Add("@EmpNo", obj.EmpNo);
                Parameters.Add("@BranchID", obj.BranchId);
                Parameters.Add("@ReasonForWorkHandOver", obj.ReasonForWorkHandOver);
                Parameters.Add("@TakenOverBy", obj.TakenOverBy);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public HR_WorkHandOverReportModel AddUpdateBulk(HR_WorkHandOverReportModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@WorkHandOverID", obj.WorkHandOverID);
                Parameters.Add("@Tasks", obj.Tasks);
                Parameters.Add("@Status", obj.Status);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HR_WorkHandOverReportModel> GetWorkHandOverReportList()
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_WorkHandOverReportModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HR_WorkHandOverReportModel DeleteWorkHandOverReport(HR_WorkHandOverReportModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public List<HR_WorkHandOverReportModel> GetWorkHandOverReportById(string Querytype, string Id)
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@Id", Id);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<HR_WorkHandOverReportModel> GetWorkHandOvermultiReportById(HR_WorkHandOverReportModel objmodel)
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<HR_WorkHandOverReportModel> FindWorkHandOverReporByIdForEdit(HR_WorkHandOverReportModel objmodel)
        {
            List<HR_WorkHandOverReportModel> obj = new List<HR_WorkHandOverReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_WorkHandOverReportModel>("USP_HR_WorkHandOverForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








    }
}