using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class RetailerEstimationController : Controller
    {
        // GET: RetailerEstimation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRetailerEstimation()
        {
            return View();
        }

    }
}