using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.DriverMaster;
using MassAutoGarage.Models.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.Facebook
{
    public class LeadGenerate_DL
    {
        public LeadsGenerateModel AddUpdate(LeadsGenerateModel obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@ID", obj.ID);
                queryParameters.Add("@Created_Time", obj.Created_Time);
                queryParameters.Add("@Ad_Id", obj.Ad_Id);
                queryParameters.Add("@Ad_Name", obj.Ad_Name);
                queryParameters.Add("@AdSet_Id", obj.AdSet_Id);
                queryParameters.Add("@AdSet_Name",obj.AdSet_Name);
                queryParameters.Add("@Campaign_Id", obj.Campaign_Id);

                queryParameters.Add("@Campaign_Name", obj.Campaign_Name);
                queryParameters.Add("@Form_Id", obj.Form_Id);
                queryParameters.Add("@Form_Name", obj.Form_Name);
                queryParameters.Add("@Is_organic", obj.Is_organic);
                queryParameters.Add("@Platform", obj.Platform);
                queryParameters.Add("@Full_name", obj.Full_name);
                queryParameters.Add("@Phone_number", obj.Phone_number);

                queryParameters.Add("@Email", obj.Email);
                queryParameters.Add("@City", obj.City);
                queryParameters.Add("@Is_qualified", obj.Is_qualified);
                queryParameters.Add("@Is_quality", obj.Is_quality);
                queryParameters.Add("@CreatedDate", obj.CreatedDate);
              

                var _iresult = DBHelperDapper.DAAddAndReturnModel<LeadsGenerateModel>("USP_FacebookLeads_Generate", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<LeadsGenerateModel> ToList()
        {
            List<LeadsGenerateModel> obj = new List<LeadsGenerateModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<LeadsGenerateModel>("USP_FacebookLeads_GenerateDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LeadsGenerateModel> GetlstIdWise(string Querytype)
        {
            List<LeadsGenerateModel> obj = new List<LeadsGenerateModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);               

                obj = DBHelperDapper.DAAddAndReturnModelList<LeadsGenerateModel>("USP_FacebookLeads_GenerateDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LeadsGenerateModel UpdateIsreadLead(Int64 fbID)
        {
            LeadsGenerateModel objmodel = new LeadsGenerateModel();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "21");
                perm.Add("@FacebookLeadID", fbID);
                objmodel = DBHelperDapper.DAAddAndReturnModel<LeadsGenerateModel>("USP_FacebookLeads_Generate", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}