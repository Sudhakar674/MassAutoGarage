using MassAutoGarage.Data.HRMS_Employee;
using MassAutoGarage.Models.HRMS_Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeController : Controller
    {
        // GET: HRMS_Employee
        HRMSEmployeeDL DL=new HRMSEmployeeDL();
        HRMSEmployeeModel model=new HRMSEmployeeModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Employee()
        {
            ViewBag.DepartmentDropdownList = DL.DepartmentDropdownList();
            ViewBag.BranchLocationDropdownList = DL.BranchLocationDropdownList();
            ViewBag.NationalityDropdownList = DL.NationalityDropdownList();
            ViewBag.MaritalStatusDropdownList = DL.MaritalStatusDropdownList();

            ViewBag.StatusDropdownList = DL.StatusDropdownList();
            




            return View(); 
        }
    }
}