using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.LinkingAccount
{
    public class LinkingAccountModel
    {
        public string Linking { get; set; }
        public string VoucherType { get; set; }
        public int AccountID { get; set; }
        public string Description { get; set; }
        public int AccountCode { get; set; }
        public List<LinkingAccountModel> LinkingAccountModelList { get; set; }
    }
}