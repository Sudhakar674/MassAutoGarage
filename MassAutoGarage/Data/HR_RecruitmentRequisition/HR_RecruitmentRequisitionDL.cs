using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_FinalClearanceReport;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HR_RecruitmentRequisition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HR_RecruitmentRequisition
{
    public class HR_RecruitmentRequisitionDL
    {

       
        public List<HR_RecruitmentRequisitionModel> GetMaxVoucher()
        {
            List<HR_RecruitmentRequisitionModel> obj = new List<HR_RecruitmentRequisitionModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RecruitmentRequisitionModel>("USP_HR_RecruitmentRequisitionForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_RecruitmentRequisitionModel AddUpdate(HR_RecruitmentRequisitionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@FullName", obj.FullName);
                Parameters.Add("@Date", obj.Date);
                Parameters.Add("@ExpectedSalary", obj.ExpectedSalary);
                Parameters.Add("@SalaryOffered", obj.SalaryOffered);
                Parameters.Add("@AdditionNew", obj.AdditionNew);
                Parameters.Add("@Budgeted", obj.Budgeted);
                Parameters.Add("@Replacement", obj.Replacement);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_RecruitmentRequisitionModel>("USP_HR_RecruitmentRequisitionForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_RecruitmentRequisitionModel> GetRecruitmentRequisitionList()
        {
            List<HR_RecruitmentRequisitionModel> obj = new List<HR_RecruitmentRequisitionModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RecruitmentRequisitionModel>("USP_HR_RecruitmentRequisitionForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_RecruitmentRequisitionModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_RecruitmentRequisitionModel> obj = new List<HR_RecruitmentRequisitionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RecruitmentRequisitionModel>("USP_HR_RecruitmentRequisitionForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_RecruitmentRequisitionModel> GetGeneralRequestDetaildById(HR_RecruitmentRequisitionModel objmodel)
        {
            List<HR_RecruitmentRequisitionModel> obj = new List<HR_RecruitmentRequisitionModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RecruitmentRequisitionModel>("USP_HR_RecruitmentRequisitionForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_RecruitmentRequisitionModel DeleteRecruitmentRequisition(HR_RecruitmentRequisitionModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_RecruitmentRequisitionModel>("USP_HR_RecruitmentRequisitionForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HR_RecruitmentRequisitionModel> GetRecruitmentRequisitionDetailsById(string Querytype, string Id)
        {
            List<HR_RecruitmentRequisitionModel> obj = new List<HR_RecruitmentRequisitionModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", Id);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_RecruitmentRequisitionModel>("USP_HR_RecruitmentRequisitionForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}