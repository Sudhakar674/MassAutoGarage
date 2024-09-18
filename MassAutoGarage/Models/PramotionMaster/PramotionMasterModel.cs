using DocumentFormat.OpenXml.Office2013.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace MassAutoGarage.Models.PramotionMaster
{
    public class PramotionMasterModel
    {
        public Int64 PramotionID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string PromotionName { get; set; }
        public string PeriodFromDate { get; set; }
        public string ToDate { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; }
        public string Suffix { get; set; }
        public string CurrentCount { get; set; }
        public List<PramotionMasterModel> PramotionMasterModelList { get; set; }

    }
}