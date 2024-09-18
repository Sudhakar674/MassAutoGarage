using Dapper;
using MassAutoGarage.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Data
{
    public class BindDropdownlist
    {
        public static List<SelectListItem> DropdownList(string QueryType, int value)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@QueryType", QueryType);
                queryParameters.Add("@Value", value);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("USP_BindDropdownList", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}