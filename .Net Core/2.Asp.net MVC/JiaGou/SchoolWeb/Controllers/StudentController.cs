using SchoolDTO;
using SchoolService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentService objStudentService = new StudentService();
            var students = objStudentService.GetStudentByClassId(1);
            return View(students);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            MinZuService objMinZuService = new MinZuService();
            var minzus = objMinZuService.GetAll();
            SelectList list = new SelectList(minzus,nameof(MinZuDTO.Id),nameof(MinZuDTO.Name));
            return View(list);
        }

        [HttpPost]
        public ActionResult AddNew(string name,int age,long Id)
        {
            StudentService objStudentService = new StudentService();
            objStudentService.AddNew(name,age,Id,1);
            return RedirectToAction(nameof(Index));
            //return Redirect("/Student");
        }

        public ActionResult Delete(long Id)
        {
            StudentService objStudentService = new StudentService();
            objStudentService.Delete(Id);
            return Redirect("/Student");
        }
    }
}