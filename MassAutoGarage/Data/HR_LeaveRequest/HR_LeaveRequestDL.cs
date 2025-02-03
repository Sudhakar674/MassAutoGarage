using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_FinalClearanceReport;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HR_LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HR_LeaveRequest
{
    public class HR_LeaveRequestDL
    {
        public List<HR_LeaveRequestModel> ddlEmployee()
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_LeaveRequestModel> ddlDesignation()
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_LeaveRequestModel> ddlCompany()
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_LeaveRequestModel> ddlDepartment()
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_LeaveRequestModel> ddlBranch()
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "36");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_LeaveRequestModel> GetMaxVoucher()
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "37");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_LeaveRequestModel AddUpdate(HR_LeaveRequestModel obj)
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
                Parameters.Add("@CompanyID", obj.CompanyID);
                Parameters.Add("@DepartmentID", obj.DepartmentId);
                Parameters.Add("@BranchID", obj.BranchId);
                Parameters.Add("@DateOfJoining", obj.DateOfJoining);
                Parameters.Add("@MarriageLeave", obj.MarriageLeave);
                Parameters.Add("@AnnualLeave", obj.AnnualLeave);
                Parameters.Add("@AuthorizedUnpaidLeave", obj.AuthorizedUnpaidLeave);
                Parameters.Add("@EmergencyLeave", obj.EmergencyLeave);
                Parameters.Add("@SickLeave", obj.SickLeave);
                Parameters.Add("@MaternityLeave", obj.MaternityLeave);
                Parameters.Add("@Others", obj.Others);
                Parameters.Add("@PleaseSpecifyOtherLeave", obj.PleaseSpecifyOtherLeave);
                Parameters.Add("@LocalLeave", obj.LocalLeave);
                Parameters.Add("@LeaveFromDate", obj.LeaveFromDate);
                Parameters.Add("@LeaveToDate", obj.LeaveToDate);
                Parameters.Add("@AirportName", obj.AirportName);
                Parameters.Add("@FromAirportName", obj.FromAirportName);
                Parameters.Add("@ToAirportName", obj.ToAirportName);
                Parameters.Add("@ReasonforSickLeave", obj.ReasonforSickLeave);
                Parameters.Add("@MedicalCertificate", obj.MedicalCertificate);
                Parameters.Add("@MedicalCertificateFile", obj.MedicalCertificateFile);
                Parameters.Add("@Email", obj.Email);
                Parameters.Add("@MobileNo", obj.MobileNo);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_LeaveRequestModel> GetLeaveRequestList()
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_LeaveRequestModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_LeaveRequestModel> GetLeaveRequestDetaildById(HR_LeaveRequestModel objmodel)
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_LeaveRequestModel DeleteLeaveRequest(HR_LeaveRequestModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<HR_LeaveRequestModel> GetLeaveRequestDetailsById(string Querytype, string Id)
        {
            List<HR_LeaveRequestModel> obj = new List<HR_LeaveRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", Id);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_LeaveRequestModel>("USP_HR_LeaveRequestMaster", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }







    }
}