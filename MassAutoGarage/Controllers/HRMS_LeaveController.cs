using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_LeaveController : Controller
    {
        // GET: HRMS_Leave
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult Leave()
        {
            return View();
        }

    }
}