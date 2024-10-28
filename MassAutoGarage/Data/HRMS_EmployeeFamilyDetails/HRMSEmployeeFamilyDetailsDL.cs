using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_EmployeeFamilyDetails;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HRMS_EmployeeFamilyDetails
{
    public class HRMSEmployeeFamilyDetailsDL
    {

        public List<HRMSEmployeeFamilyDetailsModel> DropdownList()
        {
            List<HRMSEmployeeFamilyDetailsModel> obj = new List<HRMSEmployeeFamilyDetailsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeFamilyDetailsModel>("USP_HRMS_EmployeeFamilyDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeFamilyDetailsModel> DropdownListMarital()
        {
            List<HRMSEmployeeFamilyDetailsModel> obj = new List<HRMSEmployeeFamilyDetailsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeFamilyDetailsModel>("USP_HRMS_EmployeeFamilyDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSEmployeeFamilyDetailsModel AddUpdate(HRMSEmployeeFamilyDetailsModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@BranchId", obj.BranchId);
                Parameters.Add("@MotherName", obj.MotherName);
                Parameters.Add("@EmployeeName", obj.EmployeeName);
                Parameters.Add("@MaritalStatusId", obj.MaritalStatusId);
                Parameters.Add("@FatherName", obj.FatherName);
                Parameters.Add("@Photo", obj.Photo);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@ID", obj.ID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeFamilyDetailsModel>("USP_HRMS_EmployeeFamilyDetails", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<HRMSEmployeeFamilyDetailsModel> GetEmployeeFamilyList()
        {
            List<HRMSEmployeeFamilyDetailsModel> obj = new List<HRMSEmployeeFamilyDetailsModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeFamilyDetailsModel>("USP_HRMS_EmployeeFamilyDetails", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeFamilyDetailsModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSEmployeeFamilyDetailsModel> obj = new List<HRMSEmployeeFamilyDetailsModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeFamilyDetailsModel>("USP_HRMS_EmployeeFamilyDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<HRMSEmployeeFamilyDetailsModel> GetEmployeeFamilyDetailsById(HRMSEmployeeFamilyDetailsModel objmodel)
        {
            List<HRMSEmployeeFamilyDetailsModel> obj = new List<HRMSEmployeeFamilyDetailsModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@ID", objmodel.ID);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeFamilyDetailsModel>("USP_HRMS_EmployeeFamilyDetails", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HRMSEmployeeFamilyDetailsModel DeleteEmployeeFamilyDetails(HRMSEmployeeFamilyDetailsModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@ID", obj.ID);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeFamilyDetailsModel>("USP_HRMS_EmployeeFamilyDetails", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}