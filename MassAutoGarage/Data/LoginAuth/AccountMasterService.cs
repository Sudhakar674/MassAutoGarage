using Dapper;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.LoginAuth
{
    public class AccountMasterService
    {

        public T GetLogin<T>(string LoginID, string Password)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@UserID", LoginID);
                queryParameters.Add("@Password", Password);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<T>("USP_LoginAuthServices", queryParameters);
                return _iresult;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}