using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class PurchaseOrderController : Controller
    {
        // GET: PurchaseOrder
        [HttpGet]
        public ActionResult PurchaseOrderDetail()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddPurchaseOrder()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SavePurchaseOrder() 
        {
            string result = string.Empty;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return Json(result);
        }

    }
}