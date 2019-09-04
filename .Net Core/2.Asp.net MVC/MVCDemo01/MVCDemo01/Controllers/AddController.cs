using MVCDemo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class AddController : Controller
    {
        // GET: Add
        public ActionResult Index(NumAdd model)
        {
            model.Result = model.Num1 + model.Num2;
            ViewData["name"] = "HuHu";
            ViewData["age"] = 10;
            ViewBag.gender = "男";
            return View(model);
        }
    }
}