using MVCDemo01.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            DataTable dt = SQLHelper.GetDataSet("select * from T_Persons").Tables[0];
            return View(dt);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person p)
        {
            int result = SQLHelper.Update("insert into T_Persons(Name, Age, Tel) values(@Name, @Age, @Tel)",
                new SqlParameter[] {
                new SqlParameter("@Name",p.Name),
                new SqlParameter("@Age", p.Age),
                new SqlParameter("@Tel", p.Tel)}
                );
            return Redirect("~/Person/Index");
        }
        [HttpGet]
        public ActionResult Update(int Id)
        {
            DataTable dt = SQLHelper.GetDataSet("select * from T_Persons where Id=@Id",new SqlParameter[] { new SqlParameter("@Id",Id)}).Tables[0];
            Person p = new Person();
            p.Name = Convert.ToString(dt.Rows[0]["Name"]);
            p.Age = Convert.ToInt32(dt.Rows[0]["Age"]);
            p.Tel = Convert.ToString(dt.Rows[0]["Tel"]);
            p.Id = Id;
            return View(p);
        }
        [HttpPost]
        public ActionResult Update(Person p)
        {
            int result = SQLHelper.Update("update T_Persons set Name=@Name, Age=@Age, Tel=@Tel where Id=@Id",
                new SqlParameter[]
                {
                    new SqlParameter("@Name", p.Name),
                    new SqlParameter("@Age", p.Age),
                    new SqlParameter("@Tel", p.Tel),
                    new SqlParameter("@Id", p.Id)
                });
                return Redirect("~/Person/Index");
        }
        public ActionResult Del(int id)
        {
            int result = SQLHelper.Update("delete from T_Persons where Id=@Id",
                new SqlParameter[]
                {
                    new SqlParameter("@Id",id)
                });
            return Redirect("~/Person/Index");
        }
    }
}