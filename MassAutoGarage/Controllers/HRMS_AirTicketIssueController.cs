using MassAutoGarage.Data.HRMS_Leave;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_AirTicketIssue;
using MassAutoGarage.Data.HRMS_AirTicketIssue;
using MassAutoGarage.Models;
using static ClosedXML.Excel.XLPredefinedFormat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using MassAutoGarage.Models.HRMS_InternalRequest;

namespace MassAutoGarage.Controllers
{
    public class HRMS_AirTicketIssueController : Controller
    {
        // GET: HRMS_AirTicketIssue
        HRMSAirTicketIssueModel model = new HRMSAirTicketIssueModel();
        HRMSAirTicketIssueDL DL = new HRMSAirTicketIssueDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSAirTicketIssueModel> AirTicketIssueList = new List<HRMSAirTicketIssueModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("35", Key);
                foreach (var i in GroupList)
                {
                    AirTicketIssueList.Add(new HRMSAirTicketIssueModel
                    {
                        Idencrept = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        VoucherNo = i.VoucherNo,
                        Date = i.Date,
                        EmployeeName = i.EmployeeName,
                        TicketCount = i.TicketCount,
                        TicketFrom = i.TicketFrom,
                        TicketTo = i.TicketTo,
                        ArrivalDate = i.ArrivalDate,
                        DepartureDate = i.DepartureDate,
                        AirlineName = i.AirlineName,
                        PNRNumber = i.PNRNumber,
                        ArrivalAirport = i.ArrivalAirport,
                        DepartureAirport = i.DepartureAirport
                    });
                }
            }
            else
            {
                var GroupList = DL.GetAirTicketIssueList();
                foreach (var i in GroupList)
                {
                    AirTicketIssueList.Add(new HRMSAirTicketIssueModel
                    {
                        Idencrept = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        VoucherNo = i.VoucherNo,
                        Date = i.Date,
                        EmployeeName = i.EmployeeName,
                        TicketCount = i.TicketCount,
                        TicketFrom = i.TicketFrom,
                        TicketTo = i.TicketTo,
                        ArrivalDate = i.ArrivalDate,
                        DepartureDate = i.DepartureDate,
                        AirlineName = i.AirlineName,
                        PNRNumber = i.PNRNumber,
                        ArrivalAirport = i.ArrivalAirport,
                        DepartureAirport = i.DepartureAirport
                    });
                }
            }
            return View(AirTicketIssueList);
        }
        public ActionResult AirTicketIssue(HRMSAirTicketIssueModel model, string Id)
        {
            ViewBag.BranchList = DL.DropdownList();
            ViewBag.EmployeeList = DL.DropDownEmployeeList();


            if (Id != null)
            {
                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "34";
                var lst = DL.GetAirTicketIssueDetailsById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.BranchId = lst.BranchId;
                    model.VoucherNo = lst.VoucherNo;
                    model.Date = lst.Date;
                    model.EmployeeId = lst.EmployeeId;
                    model.TicketCount = lst.TicketCount;
                    model.TicketFrom = lst.TicketFrom;
                    model.TicketTo = lst.TicketTo;
                    model.ArrivalDate = lst.ArrivalDate;
                    model.DepartureDate = lst.DepartureDate;
                    model.AirlineName = lst.AirlineName;
                    model.PNRNumber = lst.PNRNumber;
                    model.ArrivalAirport = lst.ArrivalAirport;
                    model.DepartureAirport = lst.DepartureAirport;             
                }
            }
            return View(model);
        }

        public ActionResult GetMaxVoucher()
        {
            List<HRMSAirTicketIssueModel> GetMaxVoucher = new List<HRMSAirTicketIssueModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HRMSAirTicketIssueModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult SaveAirTicketIssue(HRMSAirTicketIssueModel model)
        {
            try
            {
                if (model.ID == null || model.ID == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.ArrivalDate = string.IsNullOrEmpty(model.ArrivalDate) ? null : Common.ConvertToSystemDate(model.ArrivalDate, "dd/MM/yyyy");
                    model.DepartureDate = string.IsNullOrEmpty(model.DepartureDate) ? null : Common.ConvertToSystemDate(model.DepartureDate, "dd/MM/yyyy");
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
                    model.Idencrept = objcls.Decrypt(model.ID);
                    model.QueryType = "21";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.ArrivalDate = string.IsNullOrEmpty(model.ArrivalDate) ? null : Common.ConvertToSystemDate(model.ArrivalDate, "dd/MM/yyyy");
                    model.DepartureDate = string.IsNullOrEmpty(model.DepartureDate) ? null : Common.ConvertToSystemDate(model.DepartureDate, "dd/MM/yyyy");

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

        public ActionResult DeleteAirTicketIssue(HRMSAirTicketIssueModel model, string Id)
        {
            try
            {

                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteAirTicketIssue(model);
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