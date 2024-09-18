using MassAutoGarage.Data.CustomerMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Models.CustomerMaster;

namespace MassAutoGarage.Controllers
{
    public class AuditMasterController : Controller
    {
        // GET: AuditMaster
        CustomerMaster_DL objDL = new CustomerMaster_DL();
        CustomerOpeningBalanceAudit_DL customerOpeningBalanceAudit_DL = new CustomerOpeningBalanceAudit_DL();
        ClsGeneral objcls = new ClsGeneral();

        #region Customer Audit Master
        public ActionResult CustomerMasterAudit(string Key)
        {
            Int64 userID = 0;
            List<CustomerMasterModel> model = new List<CustomerMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchSupplier("47", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            CustomerName = i.CustomerName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            CustomerID = Convert.ToInt64(i.ID),
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
                        model.Add(new CustomerMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            CustomerName = i.CustomerName,
                            CompanyID = i.CompanyID,
                            AccountName = i.AccountName,
                            Address = i.Address,
                            CustomerID = Convert.ToInt64(i.ID),
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

        public JsonResult GetCustomerDetails(Int64 SupplierID)
        {
            var supplrlist = objDL.Get_CustomerAuditlst("41", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAttachmentList(Int64 SupplierID)
        {
            var supplrlist = objDL.Get_CustomerAuditlst("42", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetContactList(Int64 SupplierID)
        {
            var supplrlist = objDL.Get_CustomerAuditlst("43", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Customer Opening Balance Audit Report
        public ActionResult CustomerOpeningBalance(string Key)
        {
            Int64 userID = 0;
            List<CustomerOpeningBalance_AuditModel> model = new List<CustomerOpeningBalance_AuditModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                userID = Convert.ToInt64(Session["userId"]);

                if (Key != "" && Key != null)
                {
                    var GroupList = customerOpeningBalanceAudit_DL.GetlstIdWise("44", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerOpeningBalance_AuditModel
                        {
                            ID = i.ID,

                            CompanyName = i.CompanyName,
                            JobCardDate = i.JobCardDate,
                            JobCardNumber = i.JobCardNumber,
                           
                        });
                    }

                }
                else
                {

                    var GroupList = customerOpeningBalanceAudit_DL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerOpeningBalance_AuditModel
                        {
                            ID = i.ID,
                            CompanyName = i.CompanyName,
                            JobCardDate = i.JobCardDate,
                            JobCardNumber = i.JobCardNumber,

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
            var supplrlist = customerOpeningBalanceAudit_DL.GetlstIdWise("42", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOpeningBalanceDetailsList(string SupplierID)
        {
            var supplrlist = customerOpeningBalanceAudit_DL.GetlstIdWise("43", SupplierID);
            return Json(supplrlist, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}