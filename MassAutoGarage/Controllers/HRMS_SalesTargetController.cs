using MassAutoGarage.Data.HRMS_SalesTarget;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Holiday;
using MassAutoGarage.Models.HRMS_SalesTarget;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_SalesTargetController : Controller
    {
        // GET: HRMS_SalesTarget
        HRMSSalesTargetModel model=new HRMSSalesTargetModel();
        HRMSSalesTargetDL DL=new HRMSSalesTargetDL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesTarget()
        {
            ViewBag.SalesList = DL.DropdownList();
            return View();
        }

        [HttpPost]
        //public ActionResult SaveSalesTarget(HRMSSalesTargetModel model)
        public ActionResult SaveSalesTarget(HRMSSalesTargetModel model,List<HRMSSalesTargetModel> PatientArr)
        {
            try
            {
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
                model = DL.AddUpdate(model);
                var selsid  = model.FK_SalesTargetId;

                foreach (var Attch in PatientArr)
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "12";
                    model.FK_SalesTargetId = selsid;
                    model.FromDate = Attch.FromDate;
                    model.ToDate = Attch.ToDate;
                    model.Target = Attch.Target;
                    model = DL.AddUpdateBulk(model);
                }
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