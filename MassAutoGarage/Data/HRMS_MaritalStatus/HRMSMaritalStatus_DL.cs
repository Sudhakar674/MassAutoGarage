using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Department;
using MassAutoGarage.Models.HRMS_MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_MaritalStatus
{
    public class HRMSMaritalStatus_DL
    {

        public HRMSMaritalStatusModel AddUpdate(HRMSMaritalStatusModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@MaritalStatus", obj.MaritalStatus);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@ID", obj.MaritalSId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSMaritalStatusModel>("USP_HRMS_MaritalStatus", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMSMaritalStatusModel> GetMaritalStatusList()
        {
            List<HRMSMaritalStatusModel> obj = new List<HRMSMaritalStatusModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType","3");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSMaritalStatusModel>("USP_HRMS_MaritalStatus", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSMaritalStatusModel DeleteMaritalStatus(HRMSMaritalStatusModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@ID", obj.MaritalSId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSMaritalStatusModel>("USP_HRMS_MaritalStatus", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}