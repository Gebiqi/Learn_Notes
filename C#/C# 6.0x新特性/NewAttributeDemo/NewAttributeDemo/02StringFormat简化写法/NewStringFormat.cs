using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAttributeDemo
{
    public class NewStringFormat
    {
        static Student objStudent = new Student();
        public static void OldMethod()
        {
            string s = string.Format("{0,10},{1,10:d3}",objStudent.StudentName,objStudent.Age);
            Console.WriteLine(s);

        }

        public static void NewMethod()
        {
            string s = $"{objStudent.StudentName,10},{objStudent.Age:d3}";
            Console.WriteLine($"{s}");
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd}");
        }
    }
}
