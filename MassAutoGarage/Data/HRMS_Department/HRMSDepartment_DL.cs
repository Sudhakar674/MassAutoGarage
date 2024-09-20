using Dapper;
using DocumentFormat.OpenXml.Bibliography;
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
                queryParameters.Add("@DeptId", obj.DepartmentId);

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
                perm.Add("@QueryType", "3");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSDepartmentModel>("USP_HRMS_Department", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSDepartmentModel Delete(HRMSDepartmentModel obj)
        {
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", obj.QueryType);
                perm.Add("@DeptId", obj.DepartmentId);
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