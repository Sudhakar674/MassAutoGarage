using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Models.HRMS_OverTime;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HRMS_OverTime
{
    public class HRMSOverTimeDL
    {

        public List<HRMSOverTimeModel> DropdownBranchList()
        {
            List<HRMSOverTimeModel> obj = new List<HRMSOverTimeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSOverTimeModel>("USP_HRMS_OverTime", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSOverTimeModel> DropdownEmployeeList()
        {
            List<HRMSOverTimeModel> obj = new List<HRMSOverTimeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSOverTimeModel>("USP_HRMS_OverTime", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSOverTimeModel> GetMaxVoucher()
        {
            List<HRMSOverTimeModel> obj = new List<HRMSOverTimeModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "36");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSOverTimeModel>("USP_HRMS_OverTime", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSOverTimeModel AddUpdateBulk(HRMSOverTimeModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                Parameters.Add("@OTDate", obj.OTDate);
                Parameters.Add("@OTTime", obj.OTTime);
                Parameters.Add("@OTRate", obj.OTRate);
                Parameters.Add("@Amount", obj.Amount);
                Parameters.Add("@Remarks", obj.Remarks);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.ID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSOverTimeModel>("USP_HRMS_OverTime", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }






    }
}