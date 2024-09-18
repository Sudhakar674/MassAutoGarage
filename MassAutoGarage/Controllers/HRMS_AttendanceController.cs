using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_AttendanceController : Controller
    {
        // GET: HRMS_Attendance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Attendance()
        {
            return View();
        }
    }
}