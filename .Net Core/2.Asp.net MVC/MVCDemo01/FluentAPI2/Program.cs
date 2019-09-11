using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2//多对多
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher t1 = new Teacher();
            Teacher t2 = new Teacher();

            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();

            t1.Name = "语文徐";
            t2.Name = "辛数学";

            s1.Name = "学生1";
            s2.Name = "学生2";
            s3.Name = "学生3";

            t1.Students.Add(s1);
            t1.Students.Add(s2);

            t2.Students.Add(s1);
            t2.Students.Add(s3);
            using (MyDBContext ctx = new MyDBContext())
            {
                ctx.Teachers.Add(t1);
                ctx.Teachers.Add(t2);
                ctx.SaveChanges();
                Console.WriteLine("OK");
            }
            Console.ReadLine();
        }
    }
}
