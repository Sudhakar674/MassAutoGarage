using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class CustomerContractController : Controller
    {
        // GET: CustomerContract
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCustomerContract()
        {
            return View();
        }
    }
}