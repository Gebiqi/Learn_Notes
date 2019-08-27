using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ////var关键字的使用
            //object b = 20;
            //b = "abc";
            //var a = 20;
            //a = "abc";
            ////var使用中的常见错误；
            //var a;//必须初始化
            //var a = { 1, 2, 3 };//必须用new关键字
            //var a = null;//不能指定null给var类型

            ////匿名类
            //var student = new
            //{
            //    name="abc",
            //    age=20,
            //    gender="男"
            //};
            //Console.WriteLine($"姓名：{student.name}年龄：{student.age}性别：{student.gender}");
            //Console.ReadLine();

            ////简单扩展方法的应用
            ////int a = 10;
            ////string name = "HuHu";
            ////Console.WriteLine(a.GetSum());
            ////Console.WriteLine(name.Welcome());
            ////Console.ReadLine();
            //Student stu = new Student() {
            //    StudentName = "HuHu",
            //     Age=33
            //};
            //Console.WriteLine(stu.ShowStuInfo(67,95));
            //Console.ReadLine();

            ////委托的使用
            ////3创建委托对象，关联具体方法
            //CalculatorDelegate objCal = new CalculatorDelegate(Add);
            ////4通过委托调用方法
            //Console.WriteLine(objCal(10,27));
            ////5委托对象关联的方法动态变换
            //objCal -= Add;
            //objCal += Sub;
            //Console.WriteLine(objCal(10, 27));

            ////匿名方法的使用
            //CalculatorDelegate objCal = delegate (int a, int b)
            //  { return a + b; };
            //Console.WriteLine(objCal(10,20));

            ////Lambda表达式
            //CalculatorDelegate objCal = (a, b) => a + b;
            //Console.WriteLine(objCal(10,20));

            ////LinQ 基础
            //int[] nums = { 1, 22, 53, 15, 55, 22, 33, 66, 44, 88, 99 };
            //List<int> list = new List<int>();
            //foreach (int item in nums)
            //{
            //    if (item%2!=0)
            //    {
            //        list.Add(item);
            //    }
            //}
            //list.Sort();
            //list.Reverse();
            //LinQ的查询语句
            //var list = from num in nums
            //           where num % 2 != 0
            //           orderby num descending
            //           select num;
            ////LINQ查询方法
            ////var list = nums.Select(a => a * a);
            ////LINQ链式编程 where
            ////var list = nums.Where(r => r % 2 == 0).Select(s=>s*s);
            ////orderby
            //var list = nums.Where(r => r % 2 == 0).Select(s => s * s).OrderByDescending(item=>item);
            //foreach (int item in list)
            //{
            //    Console.WriteLine(item);
            //}

            ////LINQ分组 ***需要两层循环遍历***
            //string[] names = new string[] {
            //    "王三",
            //    "李四",
            //    "刘六",
            //    "孙七",
            //    "王一",
            //    "ABC"
            //};
            //var list2 = names.Where(item => item.Length == 2).Select(item => item).GroupBy(item => item.Substring(0, 1));
            //foreach (var item in list2)
            //{
            //    Console.WriteLine($"分组字段:{item.Key},分组的人数{item.Count()}");
            //    foreach (var item2 in item)
            //    {
            //        Console.WriteLine(item2);
            //    }
            //    Console.WriteLine("---------------------");
            //}

            //var list = nums.Where(r => r % 2 == 0).Select(s => s * s).OrderByDescending(item => item).Count();
            //Console.WriteLine(list.ToString());

            ////复合From子句
            Student objStu1 = new Student()
            {
                StudentName = "张三",
                Age = 25,
                ScoreList = new List<int>() { 80, 70 }
            };
            Student objStu2 = new Student()
            {
                StudentName = "李四",
                Age = 29,
                ScoreList = new List<int>() { 90, 95 }
            };
            Student objStu3 = new Student()
            {
                StudentName = "王五",
                Age = 35,
                ScoreList = new List<int>() { 88, 60 }
            };
            List<Student> list = new List<Student>() { objStu1, objStu2, objStu3 };
            //var result = from stu in list
            //           from score in stu.ScoreList 
            //           where score>=85
            //           select stu;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.StudentName);
            //    foreach (var score in item.ScoreList)
            //    {
            //        Console.WriteLine(score.ToString());
            //    }
            //}


            ////多个From子查询 多个数据源 注意查询结果的输出相当于Union多个结果集
            //Student objStu1 = new Student()
            //{
            //    StudentName = "张三",
            //    Age = 31,
            //    ScoreList = new List<int>() { 80, 70 }
            //};
            //Student objStu2 = new Student()
            //{
            //    StudentName = "李四",
            //    Age = 22,
            //    ScoreList = new List<int>() { 90, 95 }
            //};
            //Student objStu3 = new Student()
            //{
            //    StudentName = "王五",
            //    Age = 35,
            //    ScoreList = new List<int>() { 88, 60 }
            //};
            //Student objStu4 = new Student()
            //{
            //    StudentName = "孙六",
            //    Age = 22,
            //    ScoreList = new List<int>() { 98, 75 }
            //};
            //List<Student> list1 = new List<Student>() { objStu1, objStu2};
            //List<Student> list2 = new List<Student>() { objStu3, objStu4 };
            //var list = from item in list1
            //           where item.Age > 30
            //           from item2 in list2
            //           where item2.Age > 20
            //           select new { item, item2 };
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.item.StudentName);
            //    Console.WriteLine(item.item2.StudentName);
            //}


            ////高级查询 聚合类
            //var result1 = (from stu in list
            //              where stu.Age >= 25
            //              select stu
            //             ).Count();
            //var result2 = list.Where(s => s.Age >= 25).Count();
            //Console.WriteLine($"result1={result1};result2={result2}");

            ////高级查询 排序类
            //var result1 = from stu in list
            //              where stu.Age >= 25
            //              orderby stu.StudentName, stu.Age
            //              select stu;
            //var result2 = list.Where(s => s.Age >= 25).OrderBy(s => s.StudentName).ThenBy(s => s.Age);

            //foreach (var item in result1)
            //{
            //    Console.WriteLine(item.StudentName+"    "+item.Age);
            //}
            //Console.WriteLine("-----------------");
            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item.StudentName + "    " + item.Age);
            //}

            ////高级查询 分区类
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var result1 = nums.Skip(1).Take(3);
            //var result2 = nums.SkipWhile(s => s % 3 != 0)
            //    .TakeWhile(s => s % 2 != 0);
            //foreach (var item in result1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("---------------");
            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}

            ////高级查询 集合类
            //int[] nums = { 1, 2,8,2,3,4,5, 3, 4, 5, 6, 7, 8, 9 };
            //var result = nums.Distinct();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //高级查询 生成类 Range和Repeat都是静态方法
            var list1 = Enumerable.Range(10, 50);
            var list2 = Enumerable.Repeat("ABC",10);
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }




            Console.ReadLine();
        }

        //2根据委托定义方法
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
    }

    //1声明委托：定义一个函数/方法的原型
    public delegate int CalculatorDelegate(int a, int b);
}
