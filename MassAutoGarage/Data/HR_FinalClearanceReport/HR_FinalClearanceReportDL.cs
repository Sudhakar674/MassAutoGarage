using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_FinalClearanceReport;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HR_MainPowerRequisition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace MassAutoGarage.Data.HR_FinalClearanceReport
{
    public class HR_FinalClearanceReportDL
    {
        public List<HR_FinalClearanceReportModel> ddlEmployee()
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_FinalClearanceReportModel> ddlDesignation()
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_FinalClearanceReportModel> ddlDepartment()
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_FinalClearanceReportModel> GetMaxVoucher()
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_FinalClearanceReportModel AddUpdate(HR_FinalClearanceReportModel obj)
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
                Parameters.Add("@DepartmentID", obj.DepartmentId);
                Parameters.Add("@LastWorkingDay", obj.LastWorkingDay);
                Parameters.Add("@Vehichle", obj.Vehichle);
                Parameters.Add("@Laptop", obj.Laptop);
                Parameters.Add("@CompanySim", obj.CompanySim);
                Parameters.Add("@MedicalInsurance", obj.MedicalInsurance);
                Parameters.Add("@C3Card", obj.C3Card);
                Parameters.Add("@Replacement", obj.Replacement);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_FinalClearanceReportModel> GetFinalClearanceReportList()
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_FinalClearanceReportModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_FinalClearanceReportModel> GetFinalClearanceReportDetaildById(HR_FinalClearanceReportModel objmodel)
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_FinalClearanceReportModel DeleteFinalClearanceReport(HR_FinalClearanceReportModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HR_FinalClearanceReportModel> GetFinalClearanceReportDetailsById(string Querytype, string Id)
        {
            List<HR_FinalClearanceReportModel> obj = new List<HR_FinalClearanceReportModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", Id);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_FinalClearanceReportModel>("USP_HR_FinalClearanceReportForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}