using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HR_LeaveRequestController : Controller
    {
        // GET: HR_LeaveRequest
        public ActionResult LeaveRequest()
        {
            return View();
        }

        public ActionResult LeaveRequestList()
        {
            return View();
        }
    }
}