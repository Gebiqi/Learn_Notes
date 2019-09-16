using MVC_AND_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                ////添加基础数据
                //MinZu mz = new MinZu() { Name = "汉族" };
                //ctx.Set<MinZu>().Add(mz);
                //Class c1 = new Class() { Name = "三年级二班" };
                //Student s1 = new Student() { Name = "Jacky", Age = 8,Class=c1,MinZu=mz };
                //Student s2 = new Student() { Name = "Tom", Age = 9,Class=c1,MinZu=mz };
                //ctx.Classes.Add(c1);
                //ctx.Students.Add(s1);
                //ctx.Students.Add(s2);
                //ctx.SaveChanges();

                //遍历查询班级学生信息
                var c1 = ctx.Classes.First();
                var stu = ctx.Students.Where(s => s.Class.Id == c1.Id).ToList();
                HomeIndexModel HiModel = new HomeIndexModel();
                HiModel.Class = c1;
                HiModel.Students = stu;
                return View(HiModel);
            }

            //return Content("数据添加成功");
        }
    }
}