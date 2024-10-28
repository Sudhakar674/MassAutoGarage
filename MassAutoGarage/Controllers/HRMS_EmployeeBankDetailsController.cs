using MassAutoGarage.Data.HRMS_EmployeeDocuments;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_EmployeeBankDetails;
using MassAutoGarage.Data.HRMS_EmployeeBankDetails;
using MassAutoGarage.Models.HRMS_MaritalStatus;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeBankDetailsController : Controller
    {
        // GET: HRMS_EmployeeBankDetails
        //HRMSEmployeeBankDetailsModel model = new HRMSEmployeeBankDetailsModel();
        HRMSEmployeeBankDetailsDL DL = new HRMSEmployeeBankDetailsDL();
        //ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeBankDetails()
        {
            ViewBag.BranchList = DL.DropdownList();
            ViewBag.StatusDropdownList = DL.StatusDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult SaveEmployeeBankDetails(HRMSEmployeeBankDetailsModel model)
        {
            try
            {
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
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
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }





        [HttpPost]
        public ActionResult SaveMaritalStatus1211(HRMSEmployeeBankDetailsModel model, string MaritalSId)
        {
            try
            {
                //model.MaritalSId = MaritalSId;
                //if (model.MaritalSId == null || model.MaritalSId == "")
                //{
                //    model.CreatedBy = Session["userId"].ToString();
                //    model.QueryType = "1";
                //    //model = DL.AddUpdate(model);
                //    if (model.Message == "1")
                //    {
                //        model.Result = "yes";
                //    }
                //    else
                //    {
                //        model.Result = "";
                //    }
                //}
                //else
                //{
                //    model.CreatedBy = Session["userId"].ToString();
                //    model.QueryType = "2";
                //    //model = DL.AddUpdate(model);
                //    if (model.Message == "1")
                //    {
                //        model.Result = "yes1";
                //    }
                //    else
                //    {
                //        model.Result = "";
                //    }
                //}

            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


    }
}