using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class DepreciationAssetsController : Controller
    {
        // GET: DepreciationAssets
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult AddDepreciationAssets()
        {
            return View();
        }


    }
}