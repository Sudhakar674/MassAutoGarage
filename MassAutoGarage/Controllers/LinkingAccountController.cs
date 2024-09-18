using MassAutoGarage.Models.LinkingAccount;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class LinkingAccountController : Controller
    {
        // GET: LinkingAccount
        public ActionResult AddLinkingAccount()
        {
            List<LinkingAccountModel> objlist = new List<LinkingAccountModel>();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {

                new DataColumn("Linking", typeof(string)),
                new DataColumn("VoucherType", typeof(string)),
                new DataColumn("AccountID", typeof(int)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("AccountCode", typeof(int)),


            });
            DataRow dr = null;
            dr = dt.NewRow();
            dr["Linking"] = "Cash";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Card";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Inventory";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "JobCard Billing";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Direct JobCard";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Retail Sales";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Purchase Discount";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Purchase Other Charges";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "JobCard Discount";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Retail Sales Discount";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "JobCard COST OF GOODS SOLD";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Retail Sales COST OF GOODS SOLD";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Contract Sales";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Contract Sales Discount";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Contract Sales COST OF GOODS SOLD";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Reserve Account";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Car Trading";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Linking"] = "Car Trading Discount";
            dt.Rows.Add(dr);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                objlist.Add(new LinkingAccountModel
                {

                    Linking = dt.Rows[i]["Linking"].ToString(),
                    VoucherType = "",
                    AccountID = 0,
                    Description = "",
                    AccountCode = 0

                });
            }
            ViewBag.LinkingAccountList = objlist.ToList();
            return View();
        }


    }
}