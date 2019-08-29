using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10event1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.MSG += benmingnian;
            p1.MSG += benmingnian2;
            p1.Age = 12;
            p1.MSG -= benmingnian;
            p1.Age = 24;
            Console.ReadLine();
        }

        static void benmingnian()
        {
            Console.WriteLine("今年是你的本命年.");
        }
        static void benmingnian2()
        {
            Console.WriteLine("本命年啦，恭喜恭喜~");
        }
    }
}
