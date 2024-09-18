using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class JournalVouchersController : Controller
    {
        // GET: JournalVouchers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddJournalVouchers()
        {
            return View();
        }


    }
}