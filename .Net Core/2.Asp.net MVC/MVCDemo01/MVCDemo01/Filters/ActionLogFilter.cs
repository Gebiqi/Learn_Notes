using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Filters
{
    public class ActionLogFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string path = filterContext.HttpContext.Server.MapPath("~/actionLog.txt");
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            File.AppendAllText(path,$"已经执行 {controllerName}.{actionName}方法\r\n");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string path = filterContext.HttpContext.Server.MapPath("~/actionLog.txt");
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            File.AppendAllText(path, $"将要执行 {controllerName}.{actionName}方法\r\n");
        }
    }
}