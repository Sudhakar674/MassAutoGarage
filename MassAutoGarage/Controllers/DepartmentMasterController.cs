using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.DepartmentMaster;
using MassAutoGarage.Models;
using MassAutoGarage.Models.DepartmentMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class DepartmentMasterController : Controller
    {
        // GET: DepartmentMaster


        ClsGeneral objcls = new ClsGeneral();
        DepartmentMaster_DL objDL = new DepartmentMaster_DL();
        public ActionResult DepartmentDetails(string Key)
        {
            List<DepartmentMasterModel> model = new List<DepartmentMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchDepartmentMaster("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new DepartmentMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        DepartmentName = i.DepartmentName,
                        RevenueAccountName = i.RevenueAccountName,
                        ExpenseAccountName = i.ExpenseAccountName,
                        InventoryAccountName = i.InventoryAccountName,
                        DeptID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new DepartmentMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        DepartmentName = i.DepartmentName,
                        RevenueAccountName = i.RevenueAccountName,
                        ExpenseAccountName = i.ExpenseAccountName,
                        InventoryAccountName = i.InventoryAccountName,
                        DeptID = Convert.ToInt64(i.ID),
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
            return View(model);
        }
        [HttpGet]
        public ActionResult Department(string ID = "")
        {
            ViewBag.Revenuelist = BindDropdownlist.DropdownList("41", 6);
            ViewBag.Expenselist = BindDropdownlist.DropdownList("41", 7);
            ViewBag.Inventorylist = BindDropdownlist.DropdownList("41", 8);

            DepartmentMasterModel model = new DepartmentMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.DepartmentMasterModelList = objDL.GetDepartmentlstIdWise("42", id);
                var lst = model.DepartmentMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.DepartmentName = lst.DepartmentName;
                    model.RevenueAccountID = lst.RevenueAccountID;
                    model.ExpenseAccountID = lst.ExpenseAccountID;
                    model.InventoryAccountID = lst.InventoryAccountID;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.DepartmentMasterModelList = objDL.GetCode("41", "Department");
                var promotioncode = model.DepartmentMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
            ;
        }

        public JsonResult SaveDepartmentMaster(DepartmentMasterModel model)
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
                    if (model.msg == 2)
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
                    if (model.msg == 1)
                    {
                        result = "1";
                    }
                    else if (model.msg == 4)
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

        public JsonResult DeleteDepartment(Int64 DeptID)
        {
            DepartmentMasterModel model = new DepartmentMasterModel();
            var lst = objDL.Delete(DeptID);
            return Json(lst.msg, JsonRequestBehavior.AllowGet);
        }
    }
}