using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            string[] ss = new string[] {
                "aaa","bbb","ccc"
            };
            //ss.OrderBy(s=>s.Length).ThenByDescending
            return View();
        }
    }
}