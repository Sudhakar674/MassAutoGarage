using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class JobCardSalesReturnController : Controller
    {
        // GET: JobCardSalesReturn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddJobCardSalesReturn()
        {
            return View();
        
        }
    }
}