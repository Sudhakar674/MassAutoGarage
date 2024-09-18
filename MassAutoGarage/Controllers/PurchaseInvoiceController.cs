using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class PurchaseInvoiceController : Controller
    {
        // GET: PurchaseInvoice
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]        
        public ActionResult AddPurchaseInvoice()
        {
            return View();
        }



    }
}