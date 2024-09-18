using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.SupplierMaster;
using MassAutoGarage.Models.SupplierAuditDetails;
using MassAutoGarage.Models.SupplierMaster;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class SupplierAuditController : Controller
    {
        // GET: SupplierAudit
        SupplierMaster_DL objDL = new SupplierMaster_DL();
        ClsGeneral objcls = new ClsGeneral();
        SupplierOpeningBalance_AuditReport_DL objAuditDL = new SupplierOpeningBalance_AuditReport_DL();
        #region Supplier Master
        public ActionResult SupplierAuditDetails(string Key)
        {
            Int64 userID = 0;
            List<SupplierMasterModel> model = new List<SupplierMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchSupplier("47", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new SupplierMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            SupplierName = i.SupplierName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            SupplierID = Convert.ToInt64(i.ID),
                            IsActive = i.IsActive,
                            CompanyName = i.CompanyName,
                            Mobile = i.Mobile
                        });
                    }

                }
                else
                {

                    var GroupList = objDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new SupplierMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            SupplierName = i.SupplierName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            SupplierID = Convert.ToInt64(i.ID),
                            IsActive = i.IsActive,
                            CompanyName = i.CompanyName,
                            Mobile = i.Mobile
                        });

                    }
                }



                var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();
                if (logo != null)
                {
                    ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                    ViewBag.compnyAddress = logo.Address;
                }
            }
            else
            {
                ViewBag.compnylgo = null;
            }
            return View(model);
        }

        public JsonResult GetSupplierDetails(Int64 SupplierID)
        {
            var supplrlist = objDL.GetSupplierAuditlst("41", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContactList(Int64 SupplierID)
        {
            var supplrlist = objDL.GetSupplierAuditlst("42", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAttachmentList(Int64 SupplierID)
        {
            var supplrlist = objDL.GetSupplierAuditlst("43", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Supplier Opening Balance

        public ActionResult SupplierOpeningBalanceAuditDetails(string Key)
        {
            Int64 userID = 0;
            List<SupplierOpeningBalanceAudit> model = new List<SupplierOpeningBalanceAudit>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = objAuditDL.GetlstIdWise("42", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new SupplierOpeningBalanceAudit
                        {
                            ID = i.ID,
                            Code = i.Code,
                            CompanyName = i.CompanyName,
                            SupplierName = i.SupplierName
                        });
                    }

                }
                else
                {

                    var GroupList = objAuditDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new SupplierOpeningBalanceAudit
                        {
                            ID = i.ID,
                            Code = i.Code,
                            CompanyName = i.CompanyName,
                            SupplierName = i.SupplierName
                           
                        });

                    }
                }



                var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();
                if (logo != null)
                {
                    ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                    ViewBag.compnyAddress = logo.Address;
                }
            }
            else
            {
                ViewBag.compnylgo = null;
            }
            return View(model);
        }
        public JsonResult GetOpeningBalanceMasterList(string SupplierID)
        {
            var supplrlist = objAuditDL.GetlstIdWise("42", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOpeningBalanceDetailsList(string SupplierID)
        {
            var supplrlist = objAuditDL.GetlstIdWise("43", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }

        #endregion 

    }
}