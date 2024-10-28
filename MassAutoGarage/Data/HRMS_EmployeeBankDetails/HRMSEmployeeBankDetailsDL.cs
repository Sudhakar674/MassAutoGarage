using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Employee;
using MassAutoGarage.Models.HRMS_EmployeeBankDetails;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HRMS_EmployeeBankDetails
{
    public class HRMSEmployeeBankDetailsDL
    {


        public List<HRMSEmployeeBankDetailsModel> DropdownList()
        {
            List<HRMSEmployeeBankDetailsModel> obj = new List<HRMSEmployeeBankDetailsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeBankDetailsModel>("USP_HRMS_EmployeeBankDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeBankDetailsModel> StatusDropdownList()
        {
            List<HRMSEmployeeBankDetailsModel> obj = new List<HRMSEmployeeBankDetailsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeBankDetailsModel>("USP_HRMS_EmployeeBankDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSEmployeeBankDetailsModel AddUpdate(HRMSEmployeeBankDetailsModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@AccountNumber", obj.AccountNumber);
                Parameters.Add("@EmployeeName", obj.EmployeeName);
                Parameters.Add("@IBANCODE", obj.IBANCODE);
                Parameters.Add("@BankName", obj.BankName);
                Parameters.Add("@BankBranch", obj.BankBranch);
                Parameters.Add("@StatusId", obj.StatusId);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeBankDetailsModel>("USP_HRMS_EmployeeBankDetails", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}