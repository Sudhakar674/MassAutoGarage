using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class CustomerContractReturnController : Controller
    {
        // GET: CustomerContractReturn
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddCustomerContractReturn()
        {
            return View();
        }
    }
}