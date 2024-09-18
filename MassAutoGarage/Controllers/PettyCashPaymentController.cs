using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class PettyCashPaymentController : Controller
    {
        // GET: PettyCashPayment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPettyCashPayment()
        {
            return View();
        }

    }
}