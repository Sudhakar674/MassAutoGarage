using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Employee;
using MassAutoGarage.Models.HRMS_Holiday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_Employee
{
    public class HRMSEmployeeDL
    {
        public List<HRMSEmployeeModel> DepartmentDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HRMSEmployeeModel> BranchLocationDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HRMSEmployeeModel> NationalityDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeModel> MaritalStatusDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeModel> StatusDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "37");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        















    }
}