using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDBContext ctx = new MyDBContext())
            {
                ////建库
                Console.Write(ctx.Teachers.Count());
                ////数据初始化
                //Teacher t1 = new Teacher() { Name="T1", Grade=1, Salary=1000 };
                //Teacher t2 = new Teacher() { Name = "T2", Grade = 2, Salary = 2000 };
                //ctx.Teachers.Add(t1);
                //ctx.Set<Teacher>().Add(t2);
                //ctx.SaveChanges();
                ////使用通用方法实现数据增删改查
                //CommonCRUD<Teacher> t = new CommonCRUD<Teacher>(ctx);
                //long id = ctx.Teachers.FirstOrDefault().Id;
                //t.MarkDeleted(id);
                //Console.WriteLine("删除成功");

                //关系表数据初始化
                Class c1 = new Class() { Name = "三年级二班" };
                Student s1 = new Student() { StuNo = "1001", Name = "S1", Class = c1 };
                ctx.Set<Class>().Add(c1);
                ctx.Students.Add(s1);
                ctx.SaveChanges();




            }
            Console.ReadKey();
        }
    }
}
