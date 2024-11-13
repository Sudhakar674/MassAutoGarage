using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_AirTicketIssue;
using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Models.HRMS_InternalRequest;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Data.HRMS_InternalRequest
{
    public class HRMSInternalRequestDL
    {

        public List<HRMSInternalRequestModel> DropDownCompanyList()
        {
            List<HRMSInternalRequestModel> obj = new List<HRMSInternalRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSInternalRequestModel> DropDownEmployeeList()
        {
            List<HRMSInternalRequestModel> obj = new List<HRMSInternalRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSInternalRequestModel> DropDownDepartmentList()
        {
            List<HRMSInternalRequestModel> obj = new List<HRMSInternalRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<HRMSInternalRequestModel> GetMaxVoucher()
        {
            List<HRMSInternalRequestModel> obj = new List<HRMSInternalRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "37");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSInternalRequestModel AddUpdate(HRMSInternalRequestModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@CompanyId", obj.CompanyId);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@DepartmentId", obj.DepartmentId);
                Parameters.Add("@RequestFor", obj.RequestFor);
                Parameters.Add("@Purpose", obj.Purpose);
                Parameters.Add("@Remarks", obj.Remarks);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMSInternalRequestModel> GetInternalRequestList()
        {
            List<HRMSInternalRequestModel> obj = new List<HRMSInternalRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSInternalRequestModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSInternalRequestModel> obj = new List<HRMSInternalRequestModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSInternalRequestModel> GetInternalRequesDetailsById(HRMSInternalRequestModel objmodel)
        {
            List<HRMSInternalRequestModel> obj = new List<HRMSInternalRequestModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idencrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSInternalRequestModel DeleteInternalRequest(HRMSInternalRequestModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSInternalRequestModel>("USP_HRMS_InternalRequest", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}