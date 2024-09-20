using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Models.AddOnsMaster;
using MassAutoGarage.Models.HRMS_Department;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MassAutoGarage.Controllers
{
    public class HRMS_DepartmentController : Controller
    {
        // GET: HRMS_Department

        HRMSDepartmentModel model=new HRMSDepartmentModel();
        HRMSDepartment_DL DL=new HRMSDepartment_DL();
        public ActionResult Department()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveDepartment(HRMSDepartmentModel model, string DeptId)
        {
            string result = string.Empty;
            try
            {
                model.DepartmentId = DeptId;
                if(model.DepartmentId == null || model.DepartmentId == "")
                {
                    model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    model.QueryType = "1";
                    model = DL.AddUpdate(model);
                    if (model.Flag == 1)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "";
                    }
                }
                else
                {
                    model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    model.QueryType = "2";
                    model = DL.AddUpdate(model);
                    if (model.Flag == 1)
                    {
                        result = "2";
                    }
                    else
                    {
                        result = "";
                    }
                }          
            }
            catch (Exception)
            {
                throw;
            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public string GetList()
        {
            List<HRMSDepartmentModel> modellist = new List<HRMSDepartmentModel>();
           
            var GroupList = DL.GetDepartmentList();
            foreach (var i in GroupList)
            {
                modellist.Add(new HRMSDepartmentModel
                {
                    DeptID = i.DeptID,
                    DepartmentName = i.DepartmentName
                });
            }
            var lst = new JavaScriptSerializer().Serialize (modellist.ToList());

            return lst; 
        }


        public JsonResult Delete(HRMSDepartmentModel model,string DeptId)
        {
            string result = string.Empty;
            try
            {
                model.DepartmentId = DeptId;
                model.QueryType = "4";
                model = DL.Delete(model);
                if (model.Flag == 1)
                {
                    result = "1";
                }
                else
                {
                    result = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
            //var lst = DL.Delete(DeptId);
            //return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }




    }
}