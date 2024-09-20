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
        public JsonResult SaveDepartment(HRMSDepartmentModel model)
        {
            string result = string.Empty;
            try
            {
                model.QueryType = "1";
                if (Session["userId"] != null)
                {
                    model.CreatedBy = Convert.ToInt64(Session["userId"]);
                }

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


        public JsonResult Delete(Int64 DeptId)
        {
            
            var lst = DL.Delete(DeptId);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }







        //public JsonResult SaveAddONSMaster(AddOnsMasterModel model)
        //{
        //    string result = string.Empty;
        //    try
        //    {

        //        if (model.ID != "" && model.ID != null)
        //        {


        //            model.QueryType = "21";
        //            if (Session["userId"] != null)
        //            {
        //                model.CreatedBy = Convert.ToInt64(Session["userId"]);
        //            }
        //            model.ID = objcls.Decrypt(model.ID);
        //            model = objDL.AddUpdate(model);
        //            if (model.Flag == 2)
        //            {
        //                result = "2";
        //            }
        //            else
        //            {
        //                result = "";
        //            }
        //        }
        //        else
        //        {

        //            model.QueryType = "11";
        //            if (Session["userId"] != null)
        //            {
        //                model.CreatedBy = Convert.ToInt64(Session["userId"]);
        //            }

        //            model = objDL.AddUpdate(model);
        //            if (model.Flag == 1)
        //            {
        //                result = "1";
        //            }
        //            else if (model.Flag == 4)
        //            {
        //                result = "4";
        //            }
        //            else
        //            {
        //                result = "";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}










    }
}