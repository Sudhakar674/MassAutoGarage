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
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSSalesTargetModel> SalesTargetList = new List<HRMSSalesTargetModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("33", Key);
                foreach (var i in GroupList)
                {
                    SalesTargetList.Add(new HRMSSalesTargetModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        PK_Id = i.PK_Id,
                        SalesId = i.SalesId,
                        SalesTargetId = i.SalesTargetId,
                        SalesMan = i.SalesMan,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
                        Target = i.Target,
                    });
                }
            }
            else
            {
                var GroupList = DL.GetSalesTargetList();
                foreach (var i in GroupList)
                {
                    SalesTargetList.Add(new HRMSSalesTargetModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        PK_Id = i.PK_Id,
                        SalesId = i.SalesId,
                        SalesTargetId = i.SalesTargetId,
                        SalesMan = i.SalesMan,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
                        Target = i.Target,
                    });
                }
            }
            return View(SalesTargetList);
        }
        public ActionResult SalesTarget(HRMSSalesTargetModel model, string Id)
        {
            ViewBag.SalesList = DL.DropdownList();


            if (Id != null)
            {
                model.Id = objcls.Decrypt(Id);
                model.QueryType = "42";
                var lst = DL.GetSalesTargetDetaildById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.PK_Id = lst.PK_Id;
                    model.SalesId = lst.SalesId;
                    model.FromDate = lst.FromDate;
                    model.ToDate = lst.ToDate;
                    model.Target = lst.Target;
                }
            }
            return View(model);

        }

        public JsonResult SaveSalesTarget(List<HRMSSalesTargetModel> PatientArr)
        {
            HRMSSalesTargetModel model = new HRMSSalesTargetModel();

            try
            {
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
                model.SalesId = PatientArr[0].SalesId;
                model.PK_Id = PatientArr[0].PK_Id;
                model = DL.AddUpdate(model);

                var SalesTargetId = model.SalesTargetId;

                foreach (var Attch in PatientArr)
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "12";
                    model.SalesTargetId = SalesTargetId;
                    model.FromDate = Convert.ToDateTime(Attch.FromDate);
                    model.ToDate = Convert.ToDateTime(Attch.ToDate);
                    model.Target = Attch.Target;
                    model.PK_Id = Attch.PK_Id;
                    model = DL.AddUpdateBulk(model);
                }
                if (model.PK_Id == null || model.PK_Id == "")
                {
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


        [HttpPost]
        public ActionResult DeleteSalesTarget(HRMSSalesTargetModel model, string Id)
        {
            try
            {
                model.Id = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteSalesTarget(model);
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