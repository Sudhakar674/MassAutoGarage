using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class PurchaseEnquiryController : Controller
    {
        // GET: PurchaseEnquiry
        public ActionResult PurchaseEnquiryDetails()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPurchaseEnquiry()
        {
            return View();
        }

    }
}