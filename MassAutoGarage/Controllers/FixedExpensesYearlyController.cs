using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class FixedExpensesYearlyController : Controller
    {
        // GET: FixedExpensesYearly
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult AddFixedExpensesYearly()
        {
            return View();
        }


    }
}