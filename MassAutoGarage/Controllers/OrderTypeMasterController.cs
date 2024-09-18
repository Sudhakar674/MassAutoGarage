using MassAutoGarage.Data.LeadSourceMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.OrderTypeMaster;
using MassAutoGarage.Models.LeadSourceMaster;
using MassAutoGarage.Models.OrderTypeMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class OrderTypeMasterController : Controller
    {
        // GET: OrderTypeMaster
        ClsGeneral objcls = new ClsGeneral();
        OrderTypeMaster_DL objDL = new OrderTypeMaster_DL();

        public ActionResult OrderTypeDetails(string Key)
        {
            List<OrderTypeMasterModel> model = new List<OrderTypeMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new OrderTypeMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        OrderType = i.OrderType,
                        OrderID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new OrderTypeMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        OrderType = i.OrderType,
                        OrderID = Convert.ToInt64(i.ID),
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
        public ActionResult OrderType(string ID = "")
        {
            OrderTypeMasterModel model = new OrderTypeMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.OrderTypeMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.OrderTypeMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.OrderType = lst.OrderType;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.OrderTypeMasterModelList = objDL.GetCode("41", "Order Type");
                var promotioncode = model.OrderTypeMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveOrderTypeMaster(OrderTypeMasterModel model)
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

        public JsonResult DeleteOrderType(Int64 OrderID)
        {
            OrderTypeMasterModel model = new OrderTypeMasterModel();
            var lst = objDL.Delete(OrderID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}