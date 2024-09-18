using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.LoyaltyPointMaster
{
    public class LoyaltyPointMasterModel
    {
        public Int64 LoyaltyID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public decimal SalesValue { get; set; }
        public decimal ToSalesValue { get; set; }
        public string LoyaltyPoints { get; set; }       
        public int IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string CurrentCount { get; set; }
        public int Flag { get; set; }

        public List<LoyaltyPointMasterModel> LoyaltyPointMasterModelList { get; set; }
    }
}