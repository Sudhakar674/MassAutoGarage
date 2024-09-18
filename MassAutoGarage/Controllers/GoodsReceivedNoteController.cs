using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class GoodsReceivedNoteController : Controller
    {
        // GET: GoodsReceivedNote
        public ActionResult GoodsReceivedNoteDetails()
        {
            return View();
        }

        public ActionResult AddGoodsReceivedNote()
        {
            return View();
        }
    }
}