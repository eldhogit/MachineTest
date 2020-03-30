using Nimap.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nimap.MVC.CustomErrorFilter
{
    public class RedirectToErrorPage : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            //TODO : Logging Error
            HelperMethods.WriteErrorLog(ex.ToString());

            filterContext.Result = new ViewResult()
            {
                ViewName = "CustomErrorPage",
            };
        }
    }
}