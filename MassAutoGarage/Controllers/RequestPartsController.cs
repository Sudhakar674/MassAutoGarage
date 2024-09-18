using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net;
using Microsoft.Identity.Client;

namespace MassAutoGarage.Controllers
{
    public class RequestPartsController : Controller
    {
        // GET: RequestParts

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRequestParts()
        {
            return View();
        }

        public string Outlook()
        {
            var ToMail = "atssanjay09@gmail.com";
            var cc = "zubair.0928@gmail.com";

            string body = "Hello,\n\nThis is the body of the email.\n\nRegards,\nYour Name";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("abc.Info@gmail.com");
            mailMessage.To.Add(new MailAddress(ToMail));
            mailMessage.CC.Add(new MailAddress(cc));

            mailMessage.Body = (body);            
            mailMessage.IsBodyHtml = true;          
           
            //var outlookmail = "mailto:" + mailMessage.To.ToString() + "?Cc:" + mailMessage.CC.ToString() + "&subject=" + "Test Subject" + "&body=" + mailMessage.Body.ToString();
            var outlookmail = "mailto:" + mailMessage.To.ToString() + "?subject=" + "Test Subject" + "&Cc=" + mailMessage.CC.ToString() + "&body=" + mailMessage.Body.ToString();
           
            return outlookmail;

        }

        public ActionResult OutlookMessage()
        {
            return View();
        }
    }
}
