using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class RetailerInvoiceController : Controller
    {
        // GET: RetailerInvoice
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddRetailerInvoice()
        {
            return View();
        }
    }
}