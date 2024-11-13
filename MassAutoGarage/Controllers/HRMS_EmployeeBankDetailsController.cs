using MassAutoGarage.Data.HRMS_EmployeeDocuments;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_EmployeeBankDetails;
using MassAutoGarage.Data.HRMS_EmployeeBankDetails;
using MassAutoGarage.Models.HRMS_MaritalStatus;
using MassAutoGarage.Models.HRMS_Holiday;
using MassAutoGarage.Models.HRMS_Attendance;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeBankDetailsController : Controller
    {
        // GET: HRMS_EmployeeBankDetails
        HRMSEmployeeBankDetailsModel model = new HRMSEmployeeBankDetailsModel();
        HRMSEmployeeBankDetailsDL DL = new HRMSEmployeeBankDetailsDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSEmployeeBankDetailsModel> EmployeeBankDetailsList = new List<HRMSEmployeeBankDetailsModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("34", Key);
                foreach (var i in GroupList)
                {
                    EmployeeBankDetailsList.Add(new HRMSEmployeeBankDetailsModel
                    {
                        IdEncrypte = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        AccountNumber = i.AccountNumber,
                        EmployeeName = i.EmployeeName,
                        IBANCODE = i.IBANCODE,
                        BankName = i.BankName,
                        BankBranch = i.BankBranch,
                        Status = i.Status
                    });
                }
            }
            else
            {
                var GroupList = DL.GetEmployeeBankDetailsList();
                foreach (var i in GroupList)
                {
                EmployeeBankDetailsList.Add(new HRMSEmployeeBankDetailsModel
                {
                    IdEncrypte = objcls.Encrypt(i.ID),
                    BranchName = i.BranchName,
                    AccountNumber = i.AccountNumber,
                    EmployeeName = i.EmployeeName,
                    IBANCODE = i.IBANCODE,
                    BankName = i.BankName,
                    BankBranch = i.BankBranch,
                    Status = i.Status
                });
                }
            }
            return View(EmployeeBankDetailsList);
        }




        public ActionResult EmployeeBankDetails(HRMSEmployeeBankDetailsModel model, string Id)
        {
            ViewBag.BranchList = DL.DropdownList();
            ViewBag.StatusDropdownList = DL.StatusDropdownList();


            if (Id != null)
            {
                model.IdEncrypte = objcls.Decrypt(Id);
                model.QueryType = "35";
                var lst = DL.GetEmployeeBankDetailById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.BranchId = lst.BranchId;
                    model.AccountNumber = lst.AccountNumber;
                    model.EmployeeName = lst.EmployeeName;
                    model.IBANCODE = lst.IBANCODE;
                    model.BankName = lst.BankName;
                    model.BankBranch = lst.BankBranch;
                    model.StatusId = lst.StatusId;
                }
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult SaveEmployeeBankDetails(HRMSEmployeeBankDetailsModel model)
        {
            try
            {
                if(model.IdEncrypte == null || model.IdEncrypte == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model = DL.AddUpdate(model);
                    if (model.Message == "1")
                    {
                        model.Result = "yes";
                        TempData["msg"] = "Record Successfully Saved.";
                    }
                    else
                    {
                        TempData["msg"] = "Record Not Successfully Saved.";
                    }
                }
                else
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "21";
                    model = DL.AddUpdate(model);
                    if (model.Message == "1")
                    {
                     
                        TempData["msg"] = "Record Successfully Updated.";
                    }
                    else
                    {
                        TempData["msg"] = "Record Not Successfully Updated.";
                    }
                }           
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("EmployeeBankDetails", "HRMS_EmployeeBankDetails");
        }




        public ActionResult DeleteEmployeeBankDetails(HRMSEmployeeBankDetailsModel model, string Id)
        {
            try
            {

                model.IdEncrypte = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteEmployeeBankDetails(model);
                if (model.Message == "1")
                {
                    TempData["msg"] = "Records Successfully Deleted.";
                }
                else
                {
                    TempData["msg"] = "Records Not Successfully Deleted.";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "HRMS_EmployeeBankDetails");

        }




    }
}