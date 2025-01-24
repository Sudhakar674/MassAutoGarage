using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_MainPowerRequisition;
using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using MassAutoGarage.Models.HR_WorkHandOverReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HR_MainPowerRequisition
{
    public class HR_MainPowerRequisitionDL
    {  
        public List<HR_MainPowerRequisitionModel> ddlDesignation()
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public List<HR_MainPowerRequisitionModel> ddlDepartment()
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_MainPowerRequisitionModel> GetMaxVoucher()
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_MainPowerRequisitionModel AddUpdate(HR_MainPowerRequisitionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@ReqDepartmentID", obj.DepartmentId);
                Parameters.Add("@RequestedDate", obj.RequestedDate);
                Parameters.Add("@RequiredDate", obj.RequiredDate);
                Parameters.Add("@DesignationID", obj.DesignationId);
                Parameters.Add("@FullTime", obj.FullTime);
                Parameters.Add("@ProjectHire", obj.ProjectHire);
                Parameters.Add("@Temporary", obj.Temporary);
                Parameters.Add("@JobDescription", obj.JobDescription);
                Parameters.Add("@AdditionNew", obj.AdditionNew);
                Parameters.Add("@Budgeted", obj.Budgeted);
                Parameters.Add("@Replacement", obj.Replacement);
                Parameters.Add("@AgeRange", obj.AgeRange);
                Parameters.Add("@SalaryRange", obj.SalaryRange);
                Parameters.Add("@StatusID", obj.StatusID);
                Parameters.Add("@GenderID", obj.GenderID);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@ManpowerID", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HR_MainPowerRequisitionModel AddUpdateBulk(HR_MainPowerRequisitionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                //Parameters.Add("@WorkHandOverID", obj.WorkHandOverID);
                //Parameters.Add("@Tasks", obj.Tasks);
                //Parameters.Add("@Status", obj.Status);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HR_MainPowerRequisitionModel AddUpdateBulkEducationalRequirement(HR_MainPowerRequisitionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Qualification", obj.Qualification);
                Parameters.Add("@PassingYear", obj.PassingYear);
                Parameters.Add("@Board", obj.Board);
                Parameters.Add("@Percentage", obj.Percentage);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@ManPowerID", obj.ManPowerID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HR_MainPowerRequisitionModel AddUpdateBulkPreferredQualification(HR_MainPowerRequisitionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@PreferredQualification", obj.PreferredQualification);
                Parameters.Add("@PreferredExperience", obj.PreferredExperience);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@ManPowerID", obj.ManPowerID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_MainPowerRequisitionModel> GetMainPowerList()
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_MainPowerRequisitionModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_MainPowerRequisitionModel> GetRenualAndNonRenwalDetaildById(HR_MainPowerRequisitionModel objmodel)
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_MainPowerRequisitionModel DeleteMainPowerRequisition(HR_MainPowerRequisitionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@ManPowerID", obj.ManPowerID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HR_MainPowerRequisitionModel> GetMainPowerDetailsById(string Querytype, string Id)
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ManPowerID", Id);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_MainPowerRequisitionModel> GetMainPowerDetailsByIdForEdit(HR_MainPowerRequisitionModel objmodel)
        {
            List<HR_MainPowerRequisitionModel> obj = new List<HR_MainPowerRequisitionModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@ManPowerID", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_MainPowerRequisitionModel>("USP_HR_ManPowerRequisitionForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}