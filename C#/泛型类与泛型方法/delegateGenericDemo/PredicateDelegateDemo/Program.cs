using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateDelegateDemo
{
    /*Predicate委托定义如下
     * public delegate bool Predicate<T>(T obj);
     * 此委托是引用一个返回bool值的方法
     * 实际开发中这个委托引用的是一个判断条件的方法
     * 在方法体内部应该写满足条件的判断条件，如果满足条件，返回true
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>()
            {
                new Student(){ StudentId=1001,StudentName="AAA"},
                new Student(){ StudentId=1002,StudentName="BBB"},
                new Student(){ StudentId=1003,StudentName="CCC"},
                new Student(){ StudentId=1004,StudentName="DDD"},
                new Student(){ StudentId=1005,StudentName="EEE"},
                new Student(){ StudentId=1006,StudentName="FFF"},
            };

            //查找学号>3的学生数据

            List<Student> stuList = list.FindAll(stu=>stu.StudentId>1003);

            foreach (Student item in stuList)
            {
                Console.WriteLine(item.StudentName);
            }
            Console.ReadLine();

        }
    }
}
