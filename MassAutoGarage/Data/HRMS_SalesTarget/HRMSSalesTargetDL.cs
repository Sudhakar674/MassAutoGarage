using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Holiday;
using MassAutoGarage.Models.HRMS_SalesTarget;
using MassAutoGarage.Models.SupplierMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_SalesTarget
{
    public class HRMSSalesTargetDL
    {

        public List<HRMSSalesTargetModel> DropdownList()
        {
            List<HRMSSalesTargetModel> obj = new List<HRMSSalesTargetModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public HRMSSalesTargetModel AddUpdate(HRMSSalesTargetModel obj)
        //{
        //    try
        //    {
        //        var Parameters = new DynamicParameters();

        //        Parameters.Add("@QueryType", obj.QueryType);
        //        Parameters.Add("@SalesId", obj.SalesId);
        //        Parameters.Add("@CreatedBy", obj.CreatedBy);
        //        var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
        //        return _iresult;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public HRMSSalesTargetModel AddUpdateBulk(HRMSSalesTargetModel obj)
        //{
        //    try
        //    {
        //        var Parameters = new DynamicParameters();

        //        Parameters.Add("@QueryType", obj.QueryType);
        //        Parameters.Add("@FK_SalesTargetId", obj.FK_SalesTargetId);
        //        Parameters.Add("@FromDate", obj.FromDate);
        //        Parameters.Add("@ToDate", obj.ToDate);
        //        Parameters.Add("@Target", obj.Target);
        //        Parameters.Add("@CreatedBy", obj.CreatedBy);
        //        var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
        //        return _iresult;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



        public HRMSSalesTargetModel AddUpdate(HRMSSalesTargetModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@SalesId", obj.SalesId);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public HRMSSalesTargetModel AddUpdateBulk(HRMSSalesTargetModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@SalesTargetId", obj.SalesTargetId);
                Parameters.Add("@FromDate", obj.FromDate);
                Parameters.Add("@ToDate", obj.ToDate);
                Parameters.Add("@Target", obj.Target);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }









    }
}