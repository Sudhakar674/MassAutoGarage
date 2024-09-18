using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.DBContext
{
    public class SessionManager
    {
        public void RemoveSession()
        {
            try
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Session.RemoveAll();
            }
            catch
            {

            }
        }

        public string userName
        {
            get
            {
                if (HttpContext.Current.Session["userName"] != null)
                {
                    return HttpContext.Current.Session["userName"].ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["userName"] = value;
            }
        }

        public Int64 Fk_MemId
        {
            get
            {
                if (HttpContext.Current.Session["Fk_MemId"] != null)
                {
                    return Convert.ToInt64(HttpContext.Current.Session["Fk_MemId"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["Fk_MemId"] = value;
            }
        }
        public Int64 UserTypeId
        {
            get
            {
                if (HttpContext.Current.Session["UserTypeId"] != null)
                {
                    return Convert.ToInt64(HttpContext.Current.Session["UserTypeId"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["UserTypeId"] = value;
            }
        }
        public string LoginId
        {
            get
            {
                if (HttpContext.Current.Session["LoginId"] != null)
                {
                    return HttpContext.Current.Session["LoginId"].ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["LoginId"] = value;
            }
        }

        public string Usertype
        {
            get
            {
                if (HttpContext.Current.Session["Usertype"] != null)
                {
                    return HttpContext.Current.Session["Usertype"].ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Usertype"] = value;
            }
        }

        public string UserExceptionSession
        {
            get
            {
                if (HttpContext.Current.Session["UserExceptionSession"] != null)
                {
                    return HttpContext.Current.Session["UserExceptionSession"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["UserExceptionSession"] = value;
            }
        }

        public Int64 userId
        {
            get
            {
                if (HttpContext.Current.Session["userId"] != null)
                {
                    return Convert.ToInt64(HttpContext.Current.Session["userId"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["userId"] = value;
            }
        }
    }
}