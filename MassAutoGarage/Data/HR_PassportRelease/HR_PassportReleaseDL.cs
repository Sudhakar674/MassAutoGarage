using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HR_PassportRelease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ClosedXML.Excel.XLPredefinedFormat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Data.HR_PassportRelease
{
    public class HR_PassportReleaseDL
    {
        public List<HR_PassportReleaseModel> ddlEmployee()
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_PassportReleaseModel> ddlDesignation()
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_PassportReleaseModel> ddlBranch()
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_PassportReleaseModel> ddlDepartment()
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_PassportReleaseModel> GetMaxVoucher()
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "36");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_PassportReleaseModel AddUpdate(HR_PassportReleaseModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@EmployeeID", obj.EmployeeId);
                Parameters.Add("@Date", obj.Date);
                Parameters.Add("@DesignationID", obj.DesignationId);
                Parameters.Add("@EmpNo", obj.EmpNo);
                Parameters.Add("@BranchID", obj.BranchId);
                Parameters.Add("@DepartmentID", obj.DepartmentId);
                Parameters.Add("@ReasonForReleasePassReq", obj.ReasonForReleasePassReq);
                Parameters.Add("@ExpectedReturnDate", obj.ExpectedReturnDate);
                Parameters.Add("@EmployeeUndertaking", obj.EmployeeUndertaking);
                Parameters.Add("@SignDate", obj.SignDate);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_PassportReleaseModel>("USP_HR_PassportRelease", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_PassportReleaseModel> GetPassportReleaseList()
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_PassportReleaseModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_PassportReleaseModel> GetPassportReleaseDetaildById(HR_PassportReleaseModel objmodel)
        {
            List<HR_PassportReleaseModel> obj = new List<HR_PassportReleaseModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_PassportReleaseModel>("USP_HR_PassportRelease", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_PassportReleaseModel DeletePassportRelease(HR_PassportReleaseModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_PassportReleaseModel>("USP_HR_PassportRelease", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}