﻿using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
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

        public HRMSSalesTargetModel AddUpdate(HRMSSalesTargetModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@SalesId", obj.SalesId);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.PK_Id);
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
                Parameters.Add("@Id", obj.PK_Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HRMSSalesTargetModel> GetSalesTargetList()
        {
            List<HRMSSalesTargetModel> obj = new List<HRMSSalesTargetModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSSalesTargetModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSSalesTargetModel> obj = new List<HRMSSalesTargetModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSSalesTargetModel DeleteSalesTarget(HRMSSalesTargetModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Id);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HRMSSalesTargetModel> GetSalesTargetDetaildById(HRMSSalesTargetModel objmodel)
        {
            List<HRMSSalesTargetModel> obj = new List<HRMSSalesTargetModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Id);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSSalesTargetModel>("USP_HRMS_SalesTarget", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }







    }
}