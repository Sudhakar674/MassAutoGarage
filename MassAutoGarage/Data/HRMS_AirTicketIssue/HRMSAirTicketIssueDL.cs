using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_AirTicketIssue;
using MassAutoGarage.Models.HRMS_InternalRequest;
using MassAutoGarage.Models.HRMS_Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_AirTicketIssue
{
    public class HRMSAirTicketIssueDL
    {
        public List<HRMSAirTicketIssueModel> DropdownList()
        {
            List<HRMSAirTicketIssueModel> obj = new List<HRMSAirTicketIssueModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSAirTicketIssueModel> DropDownEmployeeList()
        {
            List<HRMSAirTicketIssueModel> obj = new List<HRMSAirTicketIssueModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSAirTicketIssueModel> DropDownLeavTypeList()
        {
            List<HRMSAirTicketIssueModel> obj = new List<HRMSAirTicketIssueModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSAirTicketIssueModel> GetMaxVoucher()
        {
            List<HRMSAirTicketIssueModel> obj = new List<HRMSAirTicketIssueModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "36");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public HRMSAirTicketIssueModel AddUpdate(HRMSAirTicketIssueModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@Date", obj.Date);
                Parameters.Add("@TicketCount", obj.TicketCount);
                Parameters.Add("@TicketFrom", obj.TicketFrom);
                Parameters.Add("@TicketTo", obj.TicketTo);
                Parameters.Add("@ArrivalDate", obj.ArrivalDate);
                Parameters.Add("@DepartureDate", obj.DepartureDate);
                Parameters.Add("@AirlineName", obj.AirlineName);
                Parameters.Add("@PNRNumber", obj.PNRNumber);
                Parameters.Add("@ArrivalAirport", obj.ArrivalAirport);
                Parameters.Add("@DepartureAirport", obj.DepartureAirport);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idencrept);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMSAirTicketIssueModel> GetAirTicketIssueList()
        {
            List<HRMSAirTicketIssueModel> obj = new List<HRMSAirTicketIssueModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSAirTicketIssueModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSAirTicketIssueModel> obj = new List<HRMSAirTicketIssueModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSAirTicketIssueModel> GetAirTicketIssueDetailsById(HRMSAirTicketIssueModel objmodel)
        {
            List<HRMSAirTicketIssueModel> obj = new List<HRMSAirTicketIssueModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idencrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSAirTicketIssueModel DeleteAirTicketIssue(HRMSAirTicketIssueModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idencrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSAirTicketIssueModel>("USP_HRMS_AirTicketIssue", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}