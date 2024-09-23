using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_DeductionType;
using MassAutoGarage.Models.HRMS_LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_LeaveType
{
    public class HRMSLeaveTypeDL
    {

        public HRMSLeaveTypeModel AddUpdate(HRMSLeaveTypeModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@LeaveType", obj.LeaveType);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@LeaveID", obj.LeaveID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSLeaveTypeModel>("USP_HRMS_LeaveType", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMSLeaveTypeModel> GetLeaveTypeListList()
        {
            List<HRMSLeaveTypeModel> obj = new List<HRMSLeaveTypeModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "3");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSLeaveTypeModel>("USP_HRMS_LeaveType", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSLeaveTypeModel DeleteLeaveType(HRMSLeaveTypeModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@LeaveID", obj.LeaveID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSLeaveTypeModel>("USP_HRMS_LeaveType", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}