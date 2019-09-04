using MVCDemo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index(DefaultModel model)
        {
            return Content($"Name:{model.Name}    Id:{model.Id}");
        }

        public ActionResult F1(string Name, int Id)
        {
            return Content($"Name:{Name}    Id:{Id}");
        }
        public ActionResult F2Show()
        {
            return View();
        }
        public ActionResult F2(FormCollection fc)
        {
            string Name = fc["name"];
            string Id = fc["id"];
            return Content($"Name:{Name}    Id:{Id}");
        }
        [HttpPost]
        public ActionResult Register(DefaultModel model,HttpPostedFileBase file, string gender = "男")
        {
            file.SaveAs(Server.MapPath("~/"+file.FileName));
            return Content("注册成功");
        }
        public ActionResult Register()
        {
            DefaultModel df = new DefaultModel();
            df.Name = "ABC";
            return View("AAA",df);
        }
    }
}