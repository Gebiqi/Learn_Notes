using MVCDemo01.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }
        [ValidAttrTestFilter]
        public ActionResult Login(string username, string password)
        {
            string a = null;
            a.ToString();
            if (username=="abc"&&password=="123")
            {
                Session["username"] = username;
                return Content("登录成功");
            }
            else
            {
                return Content("登录失败");
            }
        }
    }
}