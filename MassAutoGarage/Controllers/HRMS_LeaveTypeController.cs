using MassAutoGarage.Data.HRMS_DeductionType;
using MassAutoGarage.Data.HRMS_LeaveType;
using MassAutoGarage.Models.HRMS_DeductionType;
using MassAutoGarage.Models.HRMS_LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_LeaveTypeController : Controller
    {
        // GET: HRMS_LeaveType
        HRMSLeaveTypeDL DL = new HRMSLeaveTypeDL();
        public ActionResult LeaveType()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SaveLeaveType(HRMSLeaveTypeModel model, string LeaveID)
        {
            try
            {
                model.LeaveID = LeaveID;
                if (model.LeaveID == null || model.LeaveID == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "1";
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
                    model.QueryType = "2";
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



        public ActionResult LeaveTypeList()
        {
            List<HRMSLeaveTypeModel> LeaveTypeList = new List<HRMSLeaveTypeModel>();

            var GroupList = DL.GetLeaveTypeListList();
            foreach (var i in GroupList)
            {
                LeaveTypeList.Add(new HRMSLeaveTypeModel
                {
                    LeaveID = i.LeaveID,
                    LeaveType = i.LeaveType
                });
            }
            return Json(LeaveTypeList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteLeaveType(HRMSLeaveTypeModel model, string LeaveID)
        {
            try
            {
                model.LeaveID = LeaveID;
                model.QueryType = "4";
                model = DL.DeleteLeaveType(model);
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