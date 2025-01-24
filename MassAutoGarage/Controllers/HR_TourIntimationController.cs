using DocumentFormat.OpenXml.EMMA;
using MassAutoGarage.Data.HR_RenualAndNonRenwal;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_TourIntimation;
using MassAutoGarage.Data.HR_TourIntimation;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HR_TourIntimationController : Controller
    {
        // GET: HR_TourIntimation
        HR_TourIntimationModel model = new HR_TourIntimationModel();
        HR_TourIntimationDL DL = new HR_TourIntimationDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult TourIntimation(HR_TourIntimationModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ButtonText = "Save";

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "37";
                var lst = DL.GetTourIntimationDetaildById(model).FirstOrDefault();

                if (lst.VisaSingleEntry == true)
                {
                    model.VisaSingleEntry = true;
                }
                else
                {
                    model.VisaSingleEntry = false;
                }

                if (lst.VisaMultipleEntry == true)
                {
                    model.VisaMultipleEntry = true;
                }
                else
                {
                    model.VisaMultipleEntry = false;
                }

                if (lst.HotelEconomic == true)
                {
                    model.HotelEconomic = true;
                }
                else
                {
                    model.HotelEconomic = false;
                }

                if (lst.PassportRelease == true)
                {
                    model.PassportRelease = true;
                }
                else
                {
                    model.PassportRelease = false;
                }

                if (lst.TravelInsuranceYes == true)
                {
                    model.TravelInsuranceYes = true;
                }
                else
                {
                    model.TravelInsuranceYes = false;
                }

                if (lst.TravelInsuranceNo == true)
                {
                    model.TravelInsuranceNo = true;
                }
                else
                {
                    model.TravelInsuranceNo = false;
                }

                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.DesignationId = lst.DesignationId;
                    model.TourDestination = lst.TourDestination;
                    model.TravelModeID = lst.TravelModeID;
                    model.StartDate = lst.StartDate;
                    model.ReturnDate = lst.ReturnDate;
                    model.PurposeOfTour = lst.PurposeOfTour;
                    model.Details = lst.Details;
                    model.SuggestReplacement = lst.SuggestReplacement;
                    model.Acknowledgement = lst.Acknowledgement;
                    model.CashAdvanceAmt = lst.CashAdvanceAmt;
                    ViewBag.ButtonText = "Update";
                }
            }
            return View(model);
        }

        public ActionResult GetMaxVoucher()
        {
            List<HR_TourIntimationModel> GetMaxVoucher = new List<HR_TourIntimationModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_TourIntimationModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveTourIntimation(HR_TourIntimationModel model)
        {
            try
            {

                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.StartDate = string.IsNullOrEmpty(model.StartDate) ? null : Common.ConvertToSystemDate(model.StartDate, "dd/MM/yyyy");
                    model.ReturnDate = string.IsNullOrEmpty(model.ReturnDate) ? null : Common.ConvertToSystemDate(model.ReturnDate, "dd/MM/yyyy");
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
                    model.StartDate = string.IsNullOrEmpty(model.StartDate) ? null : Common.ConvertToSystemDate(model.StartDate, "dd/MM/yyyy");
                    model.ReturnDate = string.IsNullOrEmpty(model.ReturnDate) ? null : Common.ConvertToSystemDate(model.ReturnDate, "dd/MM/yyyy");
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

        public ActionResult TourIntimationList(string Key)
        {
            List<HR_TourIntimationModel> TourIntimationList = new List<HR_TourIntimationModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("36", Key);
                foreach (var i in GroupList)
                {
                    TourIntimationList.Add(new HR_TourIntimationModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Designation = i.Designation,
                        TourDestination = i.TourDestination,
                        TravelModeID = i.TravelModeID,
                        StartDate = i.StartDate,
                        ReturnDate = i.ReturnDate,
                        PurposeOfTour = i.PurposeOfTour,
                        Details = i.Details,
                        SuggestReplacement = i.SuggestReplacement,
                        Acknowledgement = i.Acknowledgement,
                        VisaSingleEntry = i.VisaSingleEntry,
                        VisaMultipleEntry = i.VisaMultipleEntry,
                        HotelEconomic = i.HotelEconomic,
                        PassportRelease = i.PassportRelease,
                        TravelInsuranceYes = i.TravelInsuranceYes,
                        TravelInsuranceNo = i.TravelInsuranceNo,
                        CashAdvanceAmt = i.CashAdvanceAmt

                    });
                }
            }
            else
            {
                var GroupList = DL.GetTourIntimationList();
                foreach (var i in GroupList)
                {
                    TourIntimationList.Add(new HR_TourIntimationModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Designation = i.Designation,
                        TourDestination = i.TourDestination,
                        TravelModeID = i.TravelModeID,
                        StartDate = i.StartDate,
                        ReturnDate = i.ReturnDate,
                        PurposeOfTour = i.PurposeOfTour,
                        Details = i.Details,
                        SuggestReplacement = i.SuggestReplacement,
                        Acknowledgement = i.Acknowledgement,
                        VisaSingleEntry = i.VisaSingleEntry,
                        VisaMultipleEntry = i.VisaMultipleEntry,
                        HotelEconomic = i.HotelEconomic,
                        PassportRelease = i.PassportRelease,
                        TravelInsuranceYes = i.TravelInsuranceYes,
                        TravelInsuranceNo = i.TravelInsuranceNo,
                        CashAdvanceAmt = i.CashAdvanceAmt
                    });
                }
            }
            return View(TourIntimationList);
        }

        [HttpPost]
        public ActionResult DeleteTourIntimation(HR_TourIntimationModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteTourIntimation(model);
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