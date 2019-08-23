using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试01自动属性初始化方法
            Console.WriteLine("------测试01自动属性初始化方法--------");
            Student objStudent = new Student();
            Console.WriteLine(objStudent.StudentId+"  "+objStudent.StudentName);

            //测试02StringFormat简化写法
            Console.WriteLine("------测试02StringFormat简化写法--------");
            NewStringFormat.OldMethod();
            NewStringFormat.NewMethod();

            //测试03表达式属性和表达式方法
            Console.WriteLine("------测试03表达式属性和表达式方法--------");
            Expression objExpression = new Expression();
            Console.WriteLine(objExpression.Age);
            Console.WriteLine(objExpression.Add(55,35));


            //测试04泛型集合Dictionary新初始化方法
            Console.WriteLine("------测试04泛型集合Dictionary新初始化方法--------");
            NewCollectionInitMethod objNewCollectionInitMethod = new NewCollectionInitMethod();
            Dictionary<string, int> student = objNewCollectionInitMethod.NewInitMethod();
            foreach (var item in student.Keys)
            {
                Console.WriteLine($"{item}-------------{student[item]}");
            }


            //测试05static声明静态类的引用
            Console.WriteLine("------测试05static声明静态类的引用--------");

            //测试06nameof表达式
            Console.WriteLine("------测试06nameof表达式--------");

            //测试07Null条件表达式
            Console.WriteLine("------测试07Null条件表达式--------");

            Console.ReadLine();
        }
    }
}
