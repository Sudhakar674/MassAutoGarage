using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class AccountGroupController : Controller
    {
        // GET: AccountGroup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddAccountGroup()
        {
            return View();
        }

    }
}