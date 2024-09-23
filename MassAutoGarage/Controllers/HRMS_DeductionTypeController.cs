using MassAutoGarage.Data.HRMS_DeductionType;
using MassAutoGarage.Data.HRMS_MaritalStatus;
using MassAutoGarage.Models.HRMS_DeductionType;
using MassAutoGarage.Models.HRMS_MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_DeductionTypeController : Controller
    {
        // GET: HRMS_DeductionType
        HRMS_DeductionTypeModel model = new HRMS_DeductionTypeModel();
        HRMSDeductionTypeDL DL = new HRMSDeductionTypeDL();
        public ActionResult DeductionType()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SaveDeductionType(HRMS_DeductionTypeModel model, string DeductionID)
        {
            try
            {
                model.DeductionID = DeductionID;
                if (model.DeductionID == null || model.DeductionID == "")
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


        public ActionResult DeductionTypeList()
        {
            List<HRMS_DeductionTypeModel> DeductionTypeList = new List<HRMS_DeductionTypeModel>();

            var GroupList = DL.GetDeductionTypeList();
            foreach (var i in GroupList)
            {
                DeductionTypeList.Add(new HRMS_DeductionTypeModel
                {
                    DeductionID = i.DeductionID,
                    DeductionType = i.DeductionType
                });
            }
            return Json(DeductionTypeList, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult DeleteDeductionType(HRMS_DeductionTypeModel model, string DeductionID)
        {
            try
            {
                model.DeductionID = DeductionID;
                model.QueryType = "4";
                model = DL.DeleteDeductionType(model);
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