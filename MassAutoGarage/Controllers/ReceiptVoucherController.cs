using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class ReceiptVoucherController : Controller
    {
        // GET: ReceiptVoucher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddReceiptVoucher()
        {
            return View();
        }
    }
}