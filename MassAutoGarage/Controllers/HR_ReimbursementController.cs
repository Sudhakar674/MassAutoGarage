using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HR_ReimbursementController : Controller
    {
        // GET: HR_Reimbursement
        public ActionResult Reimbursement()
        {
            return View();
        }

        public ActionResult ReimbursementList()
        {
            return View();
        }
    }
}