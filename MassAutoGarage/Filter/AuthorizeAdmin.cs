using MassAutoGarage.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MassAutoGarage.Filter
{
    public class AuthorizeAdmin: AuthorizeAttribute
    {
        SessionManager SM = new SessionManager();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var rd = HttpContext.Current.Request.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");
            bool isValidUser = false;

            if (SM.Fk_MemId != 0)
            {
                isValidUser = true;
            }
            else
            {
                //isValidUser = true;

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new EmptyResult();
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    SM.UserExceptionSession = "Your session has expired and you have been Logged Out.";
                    filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                           {
                                       { "action", "Logout" },
                                       { "controller", "LoginAuth" },
                           });
                }
            }

            if (!isValidUser)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new EmptyResult();
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    SM.UserExceptionSession = "Your are not authorized.";
                    filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                           {
                                       { "action", "Logout" },
                                       { "controller", "LoginAuth" }
                           });
                }
            }
        }
    }
}