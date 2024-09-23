using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.ColorMaster;
using MassAutoGarage.Models.HRMS_Holiday;
using MassAutoGarage.Models.HRMS_LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Data.HRMS_Holiday
{
    public class HRMSHolidayDL
    {

        public HRMSHolidayModel AddUpdate(HRMSHolidayModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@FK_DepartmentId", obj.FK_DepartmentId);
                Parameters.Add("@HolidayDate", obj.HolidayDate);
                Parameters.Add("@HolidayName", obj.HolidayName);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@HolidayId", obj.HolidayId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSHolidayModel>("USP_HRMS_Holiday", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMSHolidayModel> DropdownList()
        {
            List<HRMSHolidayModel> obj = new List<HRMSHolidayModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSHolidayModel>("USP_HRMS_Holiday", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSHolidayModel> GetHolidayList()
        {
            List<HRMSHolidayModel> obj = new List<HRMSHolidayModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSHolidayModel>("USP_HRMS_Holiday", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSHolidayModel DeleteHoliday(HRMSHolidayModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@HolidayId", obj.HolidayId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSHolidayModel>("USP_HRMS_Holiday", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}