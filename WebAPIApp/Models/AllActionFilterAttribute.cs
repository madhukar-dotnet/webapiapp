using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPIApp.Models
{
    public class AllActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {

            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, filterContext.ModelState);
            }
        }
    }
}