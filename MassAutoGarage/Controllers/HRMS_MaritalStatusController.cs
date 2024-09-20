using dotless.Core.Parser.Infrastructure.Nodes;
using MassAutoGarage.Data.HRMS_MaritalStatus;
using MassAutoGarage.Models.HRMS_Department;
using MassAutoGarage.Models.HRMS_MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MassAutoGarage.Controllers
{
    public class HRMS_MaritalStatusController : Controller
    {
        // GET: HRMS_MaritalStatus
        HRMSMaritalStatusModel model=new HRMSMaritalStatusModel();
        HRMSMaritalStatus_DL DL = new HRMSMaritalStatus_DL();
        public ActionResult MaritalStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveMaritalStatus(HRMSMaritalStatusModel model,string MaritalSId)
        {
            try
            {
                model.MaritalSId= MaritalSId;
                if(model.MaritalSId==null || model.MaritalSId=="")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "1";
                    model = DL.AddUpdate(model);
                    if (model.Message == "1")
                    {
                        model.Result = "yes";
                    }
                    else
                    {
                        model.Result = "";
                    }
                }
                else
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "2";
                    model = DL.AddUpdate(model);
                    if (model.Message == "1")
                    {
                        model.Result = "yes1";
                    }
                    else
                    {
                        model.Result = "";
                    }
                }
                                        
            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MaritalStatusList()
        {
            List<HRMSMaritalStatusModel> MaritalSList = new List<HRMSMaritalStatusModel>();

            var GroupList = DL.GetMaritalStatusList();
            foreach (var i in GroupList)
            {
                MaritalSList.Add(new HRMSMaritalStatusModel
                {
                    MaritalSId = i.MaritalSId,
                    MaritalStatus = i.MaritalStatus
                });
            }
            return Json(MaritalSList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteMaritalStatus(HRMSMaritalStatusModel model,string MaritalSId)
        {
            try
            {
                model.MaritalSId= MaritalSId;
                model.QueryType = "4";
                model = DL.DeleteMaritalStatus(model);
                if (model.Message == "1")
                {
                    model.Result = "yes";
                }
                else
                {
                    model.Result = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }



    }
}