using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.HRMS_Holiday;
using MassAutoGarage.Models.HRMS_Holiday;
using MassAutoGarage.Models.HRMS_LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_HolidayController : Controller
    {
        // GET: HRMS_Holiday
        HRMSHolidayDL DL = new HRMSHolidayDL();
        public ActionResult Holiday()
        {
            ViewBag.DepartmentList = DL.DropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult SaveHoliday(HRMSHolidayModel model, string HolidayId)
        {
            try
            {
                model.HolidayId = HolidayId;
                if (model.HolidayId == null || model.HolidayId == "")
                {
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
                else
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "21";
                    model = DL.AddUpdate(model);
                    if (model.Message == "1")
                    {
                        model.Result = "yes1";
                    }
                    else
                    {
                        model.Result = "";
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult HolidayList()
        {
            List<HRMSHolidayModel> HolidayList = new List<HRMSHolidayModel>();

            var GroupList = DL.GetHolidayList();
            foreach (var i in GroupList)
            {
                HolidayList.Add(new HRMSHolidayModel
                {
                    HolidayId = i.HolidayId,
                    FK_DepartmentId = i.FK_DepartmentId,
                    DepartmentName = i.DepartmentName,
                    HolidayDate = i.HolidayDate,
                    HolidayName = i.HolidayName
                    
                });
            }
            return Json(HolidayList, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult DeleteHoliday(HRMSHolidayModel model, string HolidayId)
        {
            try
            {
                model.HolidayId = HolidayId;
                model.QueryType = "41";
                model = DL.DeleteHoliday(model);
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