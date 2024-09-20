using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.AddOnsMaster;
using MassAutoGarage.Models.ColorMaster;
using MassAutoGarage.Models.HRMS_Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data
{
    public class HRMSDepartment_DL
    {
        public HRMSDepartmentModel AddUpdate(HRMSDepartmentModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@DepartmentName", obj.DepartmentName);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@DeptId", obj.DeptID);

                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSDepartmentModel>("USP_HRMS_Department", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HRMSDepartmentModel> GetDepartmentList()
        {
            List<HRMSDepartmentModel> obj = new List<HRMSDepartmentModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "2");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSDepartmentModel>("USP_HRMS_Department", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSDepartmentModel Delete(Int64 DeptId)
        {
            HRMSDepartmentModel obj = new HRMSDepartmentModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "3");
                perm.Add("@DeptId", DeptId);
                obj = DBHelperDapper.DAAddAndReturnModel<HRMSDepartmentModel>("USP_HRMS_Department", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}