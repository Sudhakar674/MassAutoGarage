﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class PurchaseReturnController : Controller
    {
        // GET: PurchaseReturn
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult AddPurchaseReturn()
        {
            return View();
        }


    }
}