using MassAutoGarage.Models.PramotionMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.AddOnsMaster
{
    public class AddOnsMasterModel
    {
        public Int64 AddOnsID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string ServiceName { get; set; }
        public int ServiceID { get; set; }
        public decimal Comission { get; set; }
        public decimal ComissionAmount { get; set; }
        public int IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public string CurrentCount { get; set; }
        public string QueryType { get; set; }
        public int Flag { get; set; }
       
        public List<AddOnsMasterModel> AddOnsMasterModelList { get; set; }
    }
}