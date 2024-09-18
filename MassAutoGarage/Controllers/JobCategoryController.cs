using MassAutoGarage.Data.CylinderMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.JobCategoryMaster;
using MassAutoGarage.Models.CylinderMaster;
using MassAutoGarage.Models.JobCategoryMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class JobCategoryController : Controller
    {
        // GET: JobCategory
        ClsGeneral objcls = new ClsGeneral();
        JobCategoryMaster_DL objDL = new JobCategoryMaster_DL();
        public ActionResult JobCategoryDetails(string Key)
        {
            List<JobCategoryMasterModel> model = new List<JobCategoryMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new JobCategoryMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        JobCategory = i.JobCategory,
                        JobID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new JobCategoryMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        JobCategory = i.JobCategory,
                        JobID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }
            }
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                Int64 userID = Convert.ToInt64(Session["userId"]);
                var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();
                ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                ViewBag.compnyAddress = logo.Address;
            }
            else
            {
                ViewBag.compnylgo = null;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult JobCategoryMaster(string ID = "")
        {
            JobCategoryMasterModel model = new JobCategoryMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.JobCategoryMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.JobCategoryMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.JobCategory = lst.JobCategory;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.JobCategoryMasterModelList = objDL.GetCode("41", "Job-Category");
                var promotioncode = model.JobCategoryMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveJobCategoryMaster(JobCategoryMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.ID != "" && model.ID != null)
                {


                    model.QueryType = "21";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.ID = objcls.Decrypt(model.ID);
                    model = objDL.AddUpdate(model);
                    if (model.Flag == 2)
                    {
                        result = "2";
                    }
                    else
                    {
                        result = "";
                    }
                }
                else
                {

                    model.QueryType = "11";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }

                    model = objDL.AddUpdate(model);
                    if (model.Flag == 1)
                    {
                        result = "1";
                    }
                    else if (model.Flag == 4)
                    {
                        result = "4";
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Int64 JobID)
        {
            JobCategoryMasterModel model = new JobCategoryMasterModel();
            var lst = objDL.Delete(JobID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}