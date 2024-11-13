using Dapper;
using DocumentFormat.OpenXml.Drawing;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_SalesTarget;
using MassAutoGarage.Models.SupplierMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_Attendance
{
    public class HRMSAttendanceDL
    {

        public List<HRMSAttendanceModel> DropdownList()
        {
            List<HRMSAttendanceModel> obj = new List<HRMSAttendanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAttendanceModel>("USP_HRMS_Attendance", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSAttendanceModel AddUpdate(HRMSAttendanceModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@AttendanceDate", obj.AttendanceDate);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSAttendanceModel>("USP_HRMS_Attendance", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HRMSAttendanceModel AddUpdateBulk(HRMSAttendanceModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@AttendanceDate", obj.AttendanceDate);
                Parameters.Add("@VoucherNumber", obj.VoucherNumber);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@NumberOfWorkingHours", obj.NumberOfWorkingHours);
                Parameters.Add("@StartTime", obj.StartTime);
                Parameters.Add("@EndTime", obj.EndTime);
                Parameters.Add("@BreakTimeStart", obj.BreakTimeStart); 
                Parameters.Add("@BreakTimeEnd", obj.BreakTimeEnd);
                Parameters.Add("@StartTime1", obj.StartTime1);
                Parameters.Add("@EndTime1", obj.EndTime1);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSAttendanceModel>("USP_HRMS_Attendance", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }




        public List<HRMSAttendanceModel> GetMaxVoucher()
        {
            List<HRMSAttendanceModel> obj = new List<HRMSAttendanceModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAttendanceModel>("USP_HRMS_Attendance", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<HRMSAttendanceModel> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<HRMSAttendanceModel> obj = new List<HRMSAttendanceModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSAttendanceModel>("USP_HRMS_Attendance", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}