using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.ColorMaster;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Holiday;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HRMS_EmployeeDocuments
{
    public class HRMSEmployeeDocumentsDL
    {
        public HRMSEmployeeDocumentsModel AddUpdate(HRMSEmployeeDocumentsModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@FK_BranchId", obj.FK_BranchId);
                Parameters.Add("@EmployeeName", obj.EmployeeName);
                Parameters.Add("@Files", obj.files);
                Parameters.Add("@EmirateFile", obj.EmirateFile);
                Parameters.Add("@PassportFile", obj.PassportFile);
                Parameters.Add("@VisaFile", obj.VisaFile);
                Parameters.Add("@InsuranceFile", obj.InsuranceFile);
                Parameters.Add("@EmpCardFile", obj.EmpCardFile);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@EmpDocId", obj.EmpDocId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeDocumentsModel>("USP_HRMS_EmployeeDocuments", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HRMSEmployeeDocumentsModel> DropdownList()
        {
            List<HRMSEmployeeDocumentsModel> obj = new List<HRMSEmployeeDocumentsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDocumentsModel>("USP_HRMS_EmployeeDocuments", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeDocumentsModel> GetEmployeeDocumentsList()
        {
            List<HRMSEmployeeDocumentsModel> obj = new List<HRMSEmployeeDocumentsModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDocumentsModel>("USP_HRMS_EmployeeDocuments", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeDocumentsModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSEmployeeDocumentsModel> obj = new List<HRMSEmployeeDocumentsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDocumentsModel>("USP_HRMS_EmployeeDocuments", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<HRMSEmployeeDocumentsModel> GetEmployeeDocumentsDetaildById(HRMSEmployeeDocumentsModel objmodel)
        {
            List<HRMSEmployeeDocumentsModel> obj = new List<HRMSEmployeeDocumentsModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@EmpDocId", objmodel.EmpDocId);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDocumentsModel>("USP_HRMS_EmployeeDocuments", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<HRMSEmployeeDocumentsModel> GetlstIdWise(string Querytype, Int64 UserId)
        {
            List<HRMSEmployeeDocumentsModel> obj = new List<HRMSEmployeeDocumentsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", UserId);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeDocumentsModel>("USP_HRMS_EmployeeDocuments", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public HRMSEmployeeDocumentsModel DeleteEmployeeDocuments(HRMSEmployeeDocumentsModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@EmpDocId", obj.EmpDocId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeDocumentsModel>("USP_HRMS_EmployeeDocuments", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}