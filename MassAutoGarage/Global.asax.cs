using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MassAutoGarage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            if (Session["Username"] != null)
            {
               

            }
            else
            {
                //Redirect to Login Page if Session is null & Expires                   
                new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "Login" } });
            }
        }
    }
}
