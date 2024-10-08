using MassAutoGarage.Data.HRMS_Employee;
using MassAutoGarage.Models.HRMS_Employee;
using MassAutoGarage.Models.HRMS_Holiday;
using System;
using System.Collections.Generic;
using System.IO;
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


        [HttpPost]
        public ActionResult SaveEmployee(HRMSEmployeeModel model,HttpPostedFileBase Photo)
        {
            try
            {
                if (Photo != null)
                {
                    model.Photo = "/Images/EmployeePhoto/" + Guid.NewGuid() + Path.GetExtension(Photo.FileName);
                    Photo.SaveAs(Path.Combine(Server.MapPath(model.Photo)));
                }
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
                model = DL.AddUpdate(model);
                if (model.Message == "1")
                {
                    model.Result = "yes";
                }
                else
                {
                    model.Result = "";
                }                      
            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

      





    }
}