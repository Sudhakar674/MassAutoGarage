using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class ContractEstimationController : Controller
    {
        // GET: ContractEstimation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddContractEstimation()
        {
            return View();
        }
    }
}