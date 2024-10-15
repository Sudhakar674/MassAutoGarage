using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_SalesTarget
{
    public class HRMSSalesTargetModel
    {
        public string Id { get; set; }
        public string PK_Id { get; set; }
        public string SalesId { get; set; }
        public string SalesTargetId { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        //public string ID { get; set; }
        public string SalesMan { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Target { get; set; }
        public List<HRMSSalesTargetModel> HRMSSalesTargetModelList { get; set; }






    }
}