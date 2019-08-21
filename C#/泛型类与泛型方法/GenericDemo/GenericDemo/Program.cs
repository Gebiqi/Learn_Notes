using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class Program
    {
        #region 泛型类出入栈
        //static void Main(string[] args)
        //{
        //    GenericStack<int> objStack = new GenericStack<int>(10);
        //    objStack.Push(2);
        //    objStack.Push(3);
        //    objStack.Push(5);
        //    Console.WriteLine(objStack.Pop().ToString());
        //    Console.WriteLine(objStack.Pop().ToString());
        //    Console.WriteLine(objStack.Pop().ToString());
        //    Console.ReadLine();

        //}
        #endregion

        #region 带约束的泛型类测试
        static void Main(string[] args)
        {
            //1实例化泛型类型对象
            MyGenericClass2<int, Course, Teacher> obj1 = new MyGenericClass2<int, Course, Teacher>();
            //2给对象的属性赋值
            obj1.publisher = new Teacher() { Name="HuHu", Count=20 };
            obj1.productList = new List<Course>()
            {
                new Course(){ CourseName="c#", Period=20},
                new Course(){ CourseName="c1", Period=1},
                new Course(){ CourseName="c2", Period=2},
                new Course(){ CourseName="c3", Period=3},
            };
            //3调用对象方法
            Course objCourse = obj1.Buy(0);
            //4数据处理
            string info = string.Format("我已购买课程{0},学时{1},授课老师{2}",
                objCourse.CourseName,
                objCourse.Period,
                obj1.publisher.Name
                );
            Console.WriteLine(info);
            Console.ReadLine();
        }
        #endregion


        #region default关键字的使用
        private class MyGenericClass1<T1, T2>
        {
            private T1 obj1;
            public MyGenericClass1()
            {
                //obj1 = null;
                //obj1 = new T1();
                obj1 = default(T1);
            }
        }
        #endregion

        #region 给泛型增加约束

        private class MyGenericClass2<T1, T2, T3>
            where T1 : struct //类型必须是值类型
            where T2 : class  //类型必须是引用类型
            where T3 : new()  //类型必须有一个无参数构造方法,且这个类型必须放到最后
            //基类类型、接口类型
        {
            public List<T2> productList { get; set; }
            public T3 publisher { get; set; }
            public MyGenericClass2()
            {
                productList = new List<T2>();
                publisher = new T3();
            }

            public T2 Buy(T1 num)
            {
                dynamic a = num;
                return productList[a];
            }
        }

        #endregion

        #region 泛型类的应用
        class Course
        {
            public string CourseName { get; set; }  //课程名称
            public int Period { get; set; }         //学习周期
        }
        class Teacher
        {
            public string Name { get; set; }    //姓名
            public int Count { get; set; }      //授课数量
        }
        #endregion
    }
}
