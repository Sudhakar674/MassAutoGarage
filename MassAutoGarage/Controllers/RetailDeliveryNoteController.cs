using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class RetailDeliveryNoteController : Controller
    {
        // GET: RetailDeliveryNote
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRetailDeliveryNote()
        {
            return View();
        }
    }
}