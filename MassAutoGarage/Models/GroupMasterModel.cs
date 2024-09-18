using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models
{
    public class GroupMasterModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string GroupName { get; set; }      
        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public int IsActive { get; set; }
        public int Flag { get; set; }
        public string Message { get; set; }
        public string QueryType { get; set; }
        public string GroupID { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int page { get; set; }
        public string CurrentCount { get; set; }

        public List<GroupMasterModel> GroupMasterList { get; set; }
      
    }

    public class ResponseType
    {
        public static string Success { get { return "success"; } }
        public static string Warning { get { return "warning"; } }
        public static string Error { get { return "error"; } }
        public static string Info { get { return "info"; } }
        public static string Red { get { return "red"; } }
        public static string Green { get { return "green"; } }
        public static string Organge { get { return "orange"; } }
        public static string Blue { get { return "blue"; } }
    }
}