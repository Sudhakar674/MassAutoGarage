using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeDocumentsController : Controller
    {
        // GET: HRMS_EmployeeDocuments
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeDocuments()
        {
            return View();
        }
    }
}