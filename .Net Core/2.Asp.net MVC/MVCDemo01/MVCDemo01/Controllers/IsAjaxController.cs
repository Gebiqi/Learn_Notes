using MVCDemo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class IsAjaxController : Controller
    {
        // GET: IsAjax
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ajax()
        {
            Person p = new Person();
            p.Name = "ABC";
            if (Request.IsAjaxRequest())
            {
                return Json(p);
            }
            else
            {
                return Content(p.Name);
            }
        }
    }
}