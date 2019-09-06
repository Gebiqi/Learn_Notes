using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Filters
{
    public class ExceptionLogFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            string path = filterContext.HttpContext.Server.MapPath("~/errLog.txt");
            File.AppendAllText(path, $"{DateTime.Now.ToShortDateString()} 出现异常：{ex.ToString()}\r\n");
        }
    }
}