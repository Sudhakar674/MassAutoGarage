using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_FinalClearanceReport;
using MassAutoGarage.Models.HR_LeaveClearance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HR_LeaveClearance
{
    public class HR_LeaveClearanceDL
    {
        public List<HR_LeaveClearanceModel> ddlEmployee()
        {
            List<HR_LeaveClearanceModel> obj = new List<HR_LeaveClearanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_LeaveClearanceModel> ddlDesignation()
        {
            List<HR_LeaveClearanceModel> obj = new List<HR_LeaveClearanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_LeaveClearanceModel> ddlDepartment()
        {
            List<HR_LeaveClearanceModel> obj = new List<HR_LeaveClearanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_LeaveClearanceModel> GetMaxVoucher()
        {
            List<HR_LeaveClearanceModel> obj = new List<HR_LeaveClearanceModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_LeaveClearanceModel AddUpdate(HR_LeaveClearanceModel obj)
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
                Parameters.Add("@FromDate", obj.FromDate);
                Parameters.Add("@ToDate", obj.ToDate);
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
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_LeaveClearanceModel> GetLeaveClearanceList()
        {
            List<HR_LeaveClearanceModel> obj = new List<HR_LeaveClearanceModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_LeaveClearanceModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_LeaveClearanceModel> obj = new List<HR_LeaveClearanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_LeaveClearanceModel> GetLeaveClearanceDetaildById(HR_LeaveClearanceModel objmodel)
        {
            List<HR_LeaveClearanceModel> obj = new List<HR_LeaveClearanceModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_LeaveClearanceModel DeleteLeaveClearance(HR_LeaveClearanceModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_LeaveClearanceModel>("USP_HR_LeaveClearanceForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}