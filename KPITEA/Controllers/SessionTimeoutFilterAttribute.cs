using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KPITEA.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionTimeoutFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            var sid = HttpContext.Current.Session.SessionID;

            // If the browser session or authentication session has expired...
            if (session.IsNewSession || HttpContext.Current.Session["LoggedUserId"] == null)
            {   
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    { "Controller", "Login" },
                    { "Action", "Index" }
                });

            }               
            

            base.OnActionExecuting(filterContext);
        }

    }
}