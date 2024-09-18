using MassAutoGarage.Models.GenderMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.Facebook
{
    public class LeadsGenerateModel
    {
        public int FacebookLeadID { get; set; }
        public string ID { get; set; }
        public string Created_Time { get; set; }
        public string Ad_Id { get; set; }
        public string Ad_Name { get; set; }
        public string AdSet_Id { get; set; }
        public string AdSet_Name { get; set; }
        public string Campaign_Id { get; set; }
        public string Campaign_Name { get; set; }
        public string Form_Id { get; set; }
        public string Form_Name { get; set; }
        public string Is_organic { get; set; }
        public string Platform { get; set; }
        public string Full_name { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Is_qualified { get; set; }
        public string Is_quality { get; set; }
        public string Is_converted { get; set; }
        public string CreatedDate { get; set; }

        public string msg { get; set; }
        public string QueryType { get; set; }
        public int IsRead { get; set; }
        public int IsConverted { get; set; }
        public int ReadQTY { get; set; }
        public int UnreadQTY { get; set; }

        public int IGReadQTY { get; set; }
        public int IGUnreadQTY { get; set; }

        public List<LeadsGenerateModel> LeadsGenerateModellList { get; set; }
    }
}