using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Filters
{
    public class CheckAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            
            string controllorName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            if (controllorName=="Login"&&(actionName=="Index"||actionName=="Login"))
            {
                //什么都不做
            }
            else
            {
                if (filterContext.HttpContext.Session["username"]==null)
                {
                    ContentResult result = new ContentResult();
                    result.Content = "未登录";
                    //如果给filterContext.Result赋值了，则不再执行Action方法及返回Actionresult了
                    //直接将filterContext.Result内容return 返回
                    //作用：组织Action执行并返回原因
                    //filterContext.Result = result;
                    //不推荐：filterContext.HttpContext.Response.Redirect("/Login/Index");
                    filterContext.Result = new RedirectResult("/Login/Index");
                }

            }
        }
    }
}