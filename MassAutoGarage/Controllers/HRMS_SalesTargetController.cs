using DocumentFormat.OpenXml.VariantTypes;
using MassAutoGarage.Data;
using MassAutoGarage.Data.HRMS_SalesTarget;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Holiday;
using MassAutoGarage.Models.HRMS_SalesTarget;
using MassAutoGarage.Models.SupplierMaster;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.X509;
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
        HRMSSalesTargetModel model = new HRMSSalesTargetModel();
        HRMSSalesTargetDL DL = new HRMSSalesTargetDL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesTarget()
        {
            ViewBag.SalesList = DL.DropdownList();
            return View();
        }

        //[HttpPost]


        //public JsonResult InsertUpdateSupplier(List<SupplierMasterModel> PatientArr)

        //public JsonResult SaveSalesTarget(List<HRMSSalesTargetModel> ProductListArrSddsfsdg)
        //{
        //    //HRMSSalesTargetModel model = new HRMSSalesTargetModel();
        //    try
        //    {
        //        model.CreatedBy = Session["userId"].ToString();
        //        model.QueryType = "11";
        //        model = DL.AddUpdate(model);
        //        var selsid  = model.FK_SalesTargetId;

        //        //foreach (var Attch in PatientArr)
        //        //{
        //        //    model.CreatedBy = Session["userId"].ToString();
        //        //    model.QueryType = "12";
        //        //    model.FK_SalesTargetId = selsid;
        //        //    model.FromDate = Attch.FromDate;
        //        //    model.ToDate = Attch.ToDate;
        //        //    model.Target = Attch.Target;
        //        //    model = DL.AddUpdateBulk(model);
        //        //}
        //        if (model.Message == "1")
        //            {
        //                model.Result = "yes";
        //            }
        //            else
        //            {
        //                model.Result = "";
        //            }                           
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}



        //public ActionResult SaveSalesTarget(List<HRMSSalesTargetModel> ProductListArr, HRMSSalesTargetModel model)
        public JsonResult SaveSalesTarget(List<HRMSSalesTargetModel> ProductListArr)
        {
            HRMSSalesTargetModel model = new HRMSSalesTargetModel();

            try
            {
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
                model.SalesId = ProductListArr[0].SalesId;
                model = DL.AddUpdate(model);

                var SalesTargetId = model.SalesTargetId;


                foreach (var Attch in ProductListArr)
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "12";
                    model.SalesTargetId = Attch.SalesTargetId;
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