using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class PaymentVoucherController : Controller
    {
        // GET: PaymentVoucher
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult AddPaymentVoucher()
        {
            return View();
        }
    }
}