using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Centric.Internship.Mvc.Custom
{
    public class GlobalLogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        private void Log(string methodName, Microsoft.AspNetCore.Routing.RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            string message = methodName + " Controller:" + controllerName + " Action:" + actionName + " Date: "
                             + DateTime.Now.ToString() + Environment.NewLine;

            //saving the data in a text file called Log.txt
            File.AppendAllLines(Path.GetPathRoot(Assembly.GetExecutingAssembly().Location) + "/Log/Log.txt",
                new List<string>{message});
        }
    }
}