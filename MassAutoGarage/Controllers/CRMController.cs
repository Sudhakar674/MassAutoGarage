using DocumentFormat.OpenXml.Bibliography;
using dotless.Core.Response;
using Irony.Parsing;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.Facebook;
using MassAutoGarage.Models.CustomerMaster;
using MassAutoGarage.Models.Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class CRMController : Controller
    {
        LeadGenerate_DL objDL = new LeadGenerate_DL();
        // GET: CRM
        [ActionName("Contacts")]
        public ActionResult Contacts()
        {
            return View();
        }

        [ActionName("Companies")]
        public ActionResult Companies()
        {
            return View();
        }

        [ActionName("Deals")]
        public ActionResult Deals()
        {
            List<LeadsGenerateModel> model = new List<LeadsGenerateModel>();

            var GroupList = objDL.ToList();
            foreach (var i in GroupList)
            {
                model.Add(new LeadsGenerateModel
                {
                    FacebookLeadID=i.FacebookLeadID,
                    Full_name = i.Full_name,
                    Campaign_Name = i.Campaign_Name,
                    Platform = i.Platform,
                    Phone_number = i.Phone_number,
                    City = i.City,
                    Created_Time = i.Created_Time,
                    IsRead = i.IsRead,
                    IsConverted = i.IsConverted,
                });

            }

            var ReadQTY = objDL.GetlstIdWise("42").FirstOrDefault();
            ViewBag.ReadLeadqty = ReadQTY.ReadQTY;

            var Unreadqty = objDL.GetlstIdWise("43").FirstOrDefault();
            ViewBag.UnreadLeadqty = Unreadqty.UnreadQTY;


            var IGreadqty = objDL.GetlstIdWise("44").FirstOrDefault();
            ViewBag.IGReadLeadqty = IGreadqty.IGReadQTY;

            var IGUnreadqty = objDL.GetlstIdWise("45").FirstOrDefault();
            ViewBag.IGUnreadLeadqty = IGUnreadqty.IGUnreadQTY;

            return View(model);
        }
        public JsonResult SaveLeads(List<LeadsGenerateModel> LeadeListArr)
        {
            string result = string.Empty;
            LeadsGenerateModel model = new LeadsGenerateModel();
            // IEnumerable<LeadsGenerateModel> LeadsListArr

            foreach (var Attch in LeadeListArr)
            {

                model.QueryType = "11";
                model.ID = Attch.ID;
                model.Created_Time = Attch.Created_Time;
                model.Ad_Id = Attch.Ad_Id;
                model.Ad_Name = Attch.Ad_Name;
                model.AdSet_Id = Attch.AdSet_Id;
                model.AdSet_Name = Attch.AdSet_Name;
                model.Campaign_Id = Attch.Campaign_Id;
                model.Campaign_Name = Attch.Campaign_Name;
                model.Form_Id = Attch.Form_Id;
                model.Form_Name = Attch.Form_Name;
                model.Is_organic = Attch.Is_organic;
                model.Platform = Attch.Platform;
                model.Full_name = Attch.Full_name;
                model.Phone_number = Attch.Phone_number;
                model.Email = Attch.Email;
                model.City = Attch.City;
                model.Is_qualified = Attch.Is_qualified;
                model.Is_quality = Attch.Is_quality;
                model.Is_converted = Attch.Is_converted;
                model.CreatedDate = DateTime.Now.ToShortDateString();

                model = objDL.AddUpdate(model);


            }

            return Json(model.msg, JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateIsRead(Int64 fbID)
        {
            var lst = objDL.UpdateIsreadLead(fbID);
            return Json(lst.msg, JsonRequestBehavior.AllowGet);
        }

        public void GetLeadReadCount() 
        {
          
        }  



        [ActionName("Leads")]
        public ActionResult Leads()
        {

            List<LeadsGenerateModel> model = new List<LeadsGenerateModel>();

            var GroupList = objDL.ToList();
            foreach (var i in GroupList)
            {
                model.Add(new LeadsGenerateModel
                {
                    FacebookLeadID = i.FacebookLeadID,
                    Full_name = i.Full_name,
                    Campaign_Name = i.Campaign_Name,
                    Platform = i.Platform,
                    Phone_number = i.Phone_number,
                    City = i.City,
                    Created_Time =i.Created_Time,
                    IsRead = i.IsRead,
                    IsConverted = i.IsConverted,
                });
                               
            }

            return View(model);
        }

        public ActionResult UserInputLeads()
        {
            return View();
        }



    }
}