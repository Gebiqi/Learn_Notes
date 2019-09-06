using MVCDemo01.Helper;
using MVCDemo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class DataValidateController : Controller
    {
        // GET: DataValidate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult V1(Person p)
        {
            if (ModelState.IsValid)
            {
                return Content(p.Age.ToString());
            }
            else
            {
                string errorMsg = MVCHelper.GetValidMsg(ModelState);
                return Content("验证失败,具体原因"+errorMsg);
            }
        }
    }
}