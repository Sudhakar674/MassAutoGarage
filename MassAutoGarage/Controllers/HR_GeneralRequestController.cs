using MassAutoGarage.Data.HRMS_Loan;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Data.HR_GeneralRequest;
using Microsoft.Azure.Pipelines.WebApi;
using Org.BouncyCastle.Asn1.X509;
using MassAutoGarage.Models.HRMS_EmployeeBankDetails;
using System.Data;
using MassAutoGarage.Models.HRMS_SalesTarget;

namespace MassAutoGarage.Controllers
{
    public class HR_GeneralRequestController : Controller
    {
        // GET: HR_GeneralRequest
        HR_GeneralRequestModel model = new HR_GeneralRequestModel();
        HR_GeneralRequestDL DL = new HR_GeneralRequestDL();
        ClsGeneral objcls = new ClsGeneral();
        //public ActionResult GeneralRequest(HR_GeneralRequestModel model)
        //{
        //    ViewBag.ddlEmployee = DL.ddlEmployee();
        //    ViewBag.ddlDesignation = DL.ddlDesignation();
        //    ViewBag.ddlBranch = DL.ddlBranch();
        //    ViewBag.ddlDepartment = DL.ddlDepartment();
        //    ViewBag.SalaryCertificatelst = DL.SalaryCertificatelst();
        //    return View();
        //}

        //public ActionResult GeneralRequest(HR_GeneralRequestModel model)
        //{
        //    ViewBag.ddlEmployee = DL.ddlEmployee();
        //    ViewBag.ddlDesignation = DL.ddlDesignation();
        //    ViewBag.ddlBranch = DL.ddlBranch();
        //    ViewBag.ddlDepartment = DL.ddlDepartment();

        //    // Binding dynamic checkbox values start..........
        //    //IEnumerable<HR_GeneralRequestModel> dynamicDataSc = DL.SalaryCertificatelst();
        //    //ViewBag.DynamicValuesSC = dynamicDataSc;

        //    IEnumerable<HR_GeneralRequestModel> dynamicDataSc = DL.Certificatelst();
        //    ViewBag.DynamicValuesSC = dynamicDataSc;

        //    // Binding dynamic checkbox values end............

        //    return View();
        //}


        public ActionResult GeneralRequest(HR_GeneralRequestModel model)
        {
            List<HR_GeneralRequestModel> lst = new List<HR_GeneralRequestModel>();

            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlBranch = DL.ddlBranch();
            ViewBag.ddlDepartment = DL.ddlDepartment();

            var GroupList = DL.Certificatelst();
            foreach (var item in GroupList)
            {
                HR_GeneralRequestModel obj = new HR_GeneralRequestModel();
                obj.Id = item.Id;
                obj.Certificate = item.Certificate;
                lst.Add(obj);
            }
            model.lst = lst;
            return View(model);
        }

        public JsonResult SaveGeneralRequest(HR_GeneralRequestModel model)
        {
            try
            {
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";

                if (model.SalaryCertificate == "on")
                {
                    model.SalaryCertificate = "1";
                }
                else
                {
                    model.SalaryCertificate = "0";
                }

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


        public ActionResult GeneralRequestList()
        {
            return View();
        }





    }
}