using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Filters
{
    /// <summary>
    /// 非全局过滤器
    /// </summary>
    public class ValidAttrTestFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string path = filterContext.HttpContext.Server.MapPath("~/LoginLog.txt");
            File.AppendAllText(path, $"已经执行登录方法\r\n");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string path = filterContext.HttpContext.Server.MapPath("~/LoginLog.txt");
            File.AppendAllText(path, $"将要执行登录方法\r\n");
        }
    }
}