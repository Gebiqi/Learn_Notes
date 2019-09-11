using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBFirstTEst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestEntities ctx = new TestEntities())
            {
                T_Persons p1 = new T_Persons();
                p1.Name = "abc";
                p1.Age = 18;
                p1.Tel = "666";
                ctx.T_Persons.Add(p1);
                ctx.SaveChanges();
            }
            Console.WriteLine("添加成功");
            Console.ReadLine();
        }
    }
}
