using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_DeductionType;
using MassAutoGarage.Models.HRMS_MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_DeductionType
{
    public class HRMSDeductionTypeDL
    {


        public HRMS_DeductionTypeModel AddUpdate(HRMS_DeductionTypeModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@DeductionType", obj.DeductionType);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@DeductionID", obj.DeductionID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMS_DeductionTypeModel>("USP_HRMS_DeductionType", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMS_DeductionTypeModel> GetDeductionTypeList()
        {
            List<HRMS_DeductionTypeModel> obj = new List<HRMS_DeductionTypeModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "3");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMS_DeductionTypeModel>("USP_HRMS_DeductionType", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMS_DeductionTypeModel DeleteDeductionType(HRMS_DeductionTypeModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@DeductionID", obj.DeductionID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMS_DeductionTypeModel>("USP_HRMS_DeductionType", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}