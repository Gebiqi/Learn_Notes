using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI//一对多
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                ctx.Database.Log = (sql) => { Console.WriteLine(sql); };
                //Class c1 = new Class();
                //c1.Name = "三年级二班";
                //ctx.Classes.Add(c1);
                //Student s1 = new Student();
                //s1.Age = 8;
                //s1.Name = "Jacky";
                //s1.Class = c1;
                //ctx.Students.Add(s1);
                //ctx.SaveChanges();
                //Console.WriteLine("Add Finished...");
                //Student s = ctx.Students.First();
                //Console.WriteLine(s.Name);
                //Class c = s.Class;
                //Console.WriteLine(c.Name);
                //Class c1 = ctx.Classes.First();

                //foreach (var item in c1.Students)
                //{
                //    Console.WriteLine(item.Name);
                //}
                //foreach (Student student in ctx.Students.Where(s=>s.ClassId==c1.Id))
                //{
                //    Console.WriteLine(student.Name);
                //}

                Class c1 = new Class();
                c1.Name = "六年级二班";
                Class c2 = new Class();
                c2.Name = "升初冲刺班";
                ctx.Classes.Add(c1);
                ctx.Classes.Add(c2);
                Student s1 = new Student();
                s1.Name = "六年级学生A";
                s1.Age = 13;
                s1.Class = c1;
                s1.XZClass = c2;
                ctx.Students.Add(s1);
                ctx.SaveChanges();
                Console.WriteLine("OK");
            }
            Console.ReadKey();
        }
        static void Main2(string[] args)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                Person p1 = new Person();
                p1.Name = "AA";
                //p1.Name = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
                p1.Age = 1;
                ctx.Persons.Add(p1);
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    //foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    //{
                    //    foreach (DbValidationError validationError in item.ValidationErrors)
                    //    {
                    //        Console.WriteLine(validationError.PropertyName+":"+validationError.ErrorMessage);
                    //    }
                    //}
                    foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                    {
                        Console.WriteLine(ve.PropertyName + ":" + ve.ErrorMessage);
                    }

                }

                Console.WriteLine("Add Finished!");
            }

            Console.ReadLine();
        }
    }
}
