using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Person p1 = new Person();
                p1.Name = "aaa";
                p1.Age = 20;
                ctx.Persons.Add(p1);
                ctx.SaveChanges();
                Console.WriteLine("添加成功");
                Console.ReadLine();
            }
        }
    }
}
