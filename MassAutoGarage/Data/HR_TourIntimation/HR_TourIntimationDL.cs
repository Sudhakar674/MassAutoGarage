using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HR_FinalClearanceReport;
using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using MassAutoGarage.Models.HR_TourIntimation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.HR_TourIntimation
{
    public class HR_TourIntimationDL
    {
        public List<HR_TourIntimationModel> ddlEmployee()
        {
            List<HR_TourIntimationModel> obj = new List<HR_TourIntimationModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_TourIntimationModel>("USP_HR_TourIntimationForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HR_TourIntimationModel> ddlDesignation()
        {
            List<HR_TourIntimationModel> obj = new List<HR_TourIntimationModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_TourIntimationModel>("USP_HR_TourIntimationForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_TourIntimationModel> GetMaxVoucher()
        {
            List<HR_TourIntimationModel> obj = new List<HR_TourIntimationModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_TourIntimationModel>("USP_HR_TourIntimationForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_TourIntimationModel AddUpdate(HR_TourIntimationModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@VoucherNo", obj.VoucherNo);
                Parameters.Add("@EmployeeID", obj.EmployeeId);
                Parameters.Add("@DesignationID", obj.DesignationId);
                Parameters.Add("@TourDestination", obj.TourDestination);
                Parameters.Add("@TravelModeID", obj.TravelModeID);
                Parameters.Add("@StartDate", obj.StartDate);
                Parameters.Add("@ReturnDate", obj.ReturnDate);
                Parameters.Add("@PurposeOfTour", obj.PurposeOfTour);
                Parameters.Add("@Details", obj.Details);
                Parameters.Add("@SuggestReplacement", obj.SuggestReplacement);
                Parameters.Add("@Acknowledgement", obj.Acknowledgement);
                Parameters.Add("@VisaSingleEntry", obj.VisaSingleEntry);
                Parameters.Add("@VisaMultipleEntry", obj.VisaMultipleEntry);
                Parameters.Add("@HotelEconomic", obj.HotelEconomic);
                Parameters.Add("@PassportRelease", obj.PassportRelease);
                Parameters.Add("@TravelInsuranceYes", obj.TravelInsuranceYes);
                Parameters.Add("@TravelInsuranceNo", obj.TravelInsuranceNo);
                Parameters.Add("@CashAdvanceAmt", obj.CashAdvanceAmt);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_TourIntimationModel>("USP_HR_TourIntimationForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HR_TourIntimationModel> GetTourIntimationList()
        {
            List<HR_TourIntimationModel> obj = new List<HR_TourIntimationModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_TourIntimationModel>("USP_HR_TourIntimationForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_TourIntimationModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HR_TourIntimationModel> obj = new List<HR_TourIntimationModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HR_TourIntimationModel>("USP_HR_TourIntimationForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_TourIntimationModel> GetTourIntimationDetaildById(HR_TourIntimationModel objmodel)
        {
            List<HR_TourIntimationModel> obj = new List<HR_TourIntimationModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@Id", objmodel.Idincrept);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_TourIntimationModel>("USP_HR_TourIntimationForm", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HR_TourIntimationModel DeleteTourIntimation(HR_TourIntimationModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@Id", obj.Idincrept);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HR_TourIntimationModel>("USP_HR_TourIntimationForm", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HR_TourIntimationModel> GetTourIntimationDetailsById(string Querytype, string Id)
        {
            List<HR_TourIntimationModel> obj = new List<HR_TourIntimationModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", Id);
                obj = DBHelperDapper.DAAddAndReturnModelList<HR_TourIntimationModel>("USP_HR_TourIntimationForm", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}