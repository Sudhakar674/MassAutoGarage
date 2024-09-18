using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.CustomerGroupMaster;
using MassAutoGarage.Models.CustomerGroupMaster;
using MassAutoGarage.Models.DepartmentMaster;
using MassAutoGarage.Models.StatusMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class CustomerGroupMasterController : Controller
    {
        // GET: CustomerGroupMaster

        ClsGeneral objcls = new ClsGeneral();
        CustomerGroupMaster_DL objDL = new CustomerGroupMaster_DL();
        public ActionResult CustomerDetails(string Key)
        {
            List<CustomerGroupMasterModel> model = new List<CustomerGroupMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {

                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchCustomerGroupMaster("43", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerGroupMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            CustomerGroupName = i.CustomerGroupName,
                            GroupID = Convert.ToInt64(i.ID),
                            IsActive = i.IsActive
                        });
                    }

                }
                else
                {
                    var GroupList = objDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new CustomerGroupMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            CustomerGroupName = i.CustomerGroupName,
                            GroupID = Convert.ToInt64(i.ID),
                            IsActive = i.IsActive
                        });
                    }
                }
                if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
                {
                    Int64 userID = Convert.ToInt64(Session["userId"]);
                    var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();
                    ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                    ViewBag.compnyAddress = logo.Address;
                }
                else
                {
                    ViewBag.compnylgo = null;
                }
            }
            else
            {
                return RedirectToAction("Logout", "LoginAuth");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CustomersGroup(string ID = "")
        {
            CustomerGroupMasterModel model = new CustomerGroupMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.CustomerGroupMasterModelList = objDL.GetStatusstIdWise("42", id);
                var lst = model.CustomerGroupMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.CustomerGroupName = lst.CustomerGroupName;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.CustomerGroupMasterModelList = objDL.GetCode("41", "Customer Group");
                var promotioncode = model.CustomerGroupMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }

            return View(model);
        }

        public JsonResult SaveCustomerGroupMaster(CustomerGroupMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.ID != "" && model.ID != null)
                {


                    model.QueryType = "21";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.ID = objcls.Decrypt(model.ID);
                    model = objDL.AddUpdate(model);
                    if (model.Flag == 2)
                    {
                        result = "2";
                    }
                    else
                    {
                        result = "";
                    }
                }
                else
                {

                    model.QueryType = "11";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }

                    model = objDL.AddUpdate(model);
                    if (model.Flag == 1)
                    {
                        result = "1";
                    }
                    else if (model.Flag == 4)
                    {
                        result = "4";
                    }
                    else
                    {
                        result = "";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCustomerGroup(Int64 GroupID)
        {
            CustomerGroupMasterModel model = new CustomerGroupMasterModel();
            var lst = objDL.Delete(GroupID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}