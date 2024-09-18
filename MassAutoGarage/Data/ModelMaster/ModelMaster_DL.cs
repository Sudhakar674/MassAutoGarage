using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using MassAutoGarage.Models.MakeMaster;
using MassAutoGarage.Models.ModelMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.ModelMaster
{
    public class ModelMaster_DL
    {
        public ModelMasterModels AddUpdate(ModelMasterModels obj)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@QueryType", obj.QueryType);
                queryParameters.Add("@Code", obj.Code);
                queryParameters.Add("@MakeId", obj.MakeId);
                queryParameters.Add("@ModelName", obj.ModelName);
                queryParameters.Add("@CreatedBy", obj.CreatedBy);
                queryParameters.Add("@IsActive", obj.IsActive);
                queryParameters.Add("@ID", Convert.ToInt64(obj.ID));
                queryParameters.Add("@CurrentCount", obj.CurrentCount);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<ModelMasterModels>("USP_ModelMaster", queryParameters);
                return _iresult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ModelMasterModels> ToList()
        {
            List<ModelMasterModels> obj = new List<ModelMasterModels>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "41");
                obj = DBHelperDapper.DAAddAndReturnModelList<ModelMasterModels>("USP_ModelMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelMasterModels> GetlstIdWise(string Querytype, Int64 GroupID)
        {
            List<ModelMasterModels> obj = new List<ModelMasterModels>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@ID", GroupID);

                obj = DBHelperDapper.DAAddAndReturnModelList<ModelMasterModels>("USP_ModelMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ModelMasterModels Delete(Int64 DeptId)
        {
            ModelMasterModels objmodel = new ModelMasterModels();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "31");
                perm.Add("@ID", DeptId);
                objmodel = DBHelperDapper.DAAddAndReturnModel<ModelMasterModels>("USP_ModelMaster", perm);
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelMasterModels> SearchByKey(string Querytype, string SearchKey)
        {
            List<ModelMasterModels> obj = new List<ModelMasterModels>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<ModelMasterModels>("USP_ModelMasterDetails", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ModelMasterModels> GetCode(string Querytype, string PageName)
        {
            List<ModelMasterModels> obj = new List<ModelMasterModels>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@PageName", PageName);

                obj = DBHelperDapper.DAAddAndReturnModelList<ModelMasterModels>("USP_GetCode", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}