using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] nums1 = { 1, 33, 2, 44, 3, 55 };
            object max1 = GetMax(nums1, CompareInt);
            Console.WriteLine(max1);

            object[] nums2 = { 23.4f, 342.1f, 11.3f, 123.2f };
            object max2 = GetMax(nums2, CompareFloat);
            Console.WriteLine(max2);

            Person p1 = new Person("A20", 20);
            Person p2 = new Person("B30", 30);
            Person p3 = new Person("C10", 10);

            object[] nums3 = { p1, p2, p3 };
            object max3 = GetMax(nums3, ComparePerson);
            Console.WriteLine(max3);

            int[] num4 = { 1, 66, 2, 53 };
            int max4 = GetMax2<int>(num4, CompareInt2);
            Console.WriteLine(max4);

            Console.ReadLine();
        }

        //3定义通用方法GetMax
        static T GetMax<T>(T[] objs, CompareDelegate func)
        // static T GetMax<T>(T[] objs, Func<T,T,bool> func)
        {
            T max = objs[0];
            for (int i = 1; i < objs.Length; i++)
            {
                if (func(objs[i],max))
                {
                    max = objs[i];
                }
            }
            return max;
        }

        static T GetMax2<T>(T[] objs, CompareDelegate2<T> func)
        {
            T max = objs[0];
            for (int i = 1; i < objs.Length; i++)
            {
                if (func(objs[i], max))
                {
                    max = objs[i];
                }
            }
            return max;
        }

        //2根据委托定义方法
        static bool CompareInt(object obj1,object obj2)
        {
            int i1 = (int)obj1;
            int i2 = (int)obj2;
            return i1 >= i2;
        }

        static bool CompareFloat(object obj1,object obj2)
        {
            float f1 = (float)obj1;
            float f2 = (float)obj2;
            return f1 >= f2;
        }

        static bool ComparePerson(object obj1,object obj2)
        {
            Person p1 = (Person)obj1;
            Person p2 = (Person)obj2;
            return p1.Age >= p2.Age;
        }

        static bool CompareInt2(int i1,int i2)
        { return i1 >= i2; }
    }

    //1针对不同数据类型，比较的写法不一样，设计一个委托用于GetMax函数的形参
    public delegate bool CompareDelegate(object obj1, object obj2);
    //可以使用微软内置委托代替 Func<object,object,bool>

    public delegate T MyDel<T>(T t); //泛型委托
    public delegate bool CompareDelegate2<T>(T obj1, T obj2);
 

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public override string ToString()
        {
            return "Name:" + this.Name + "  Age:" + this.Age;
        }
    }
}
