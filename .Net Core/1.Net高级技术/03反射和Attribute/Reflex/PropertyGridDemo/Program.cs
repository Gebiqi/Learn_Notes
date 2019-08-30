using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyGridDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "HuHu";
            p1.Age = 18;
            ShowProperty(p1);

            object obj = MyClone(p1);
            ShowProperty(obj);

            Console.WriteLine(object.ReferenceEquals(p1,obj));

            Console.ReadKey();
        }
        static void ShowProperty(Object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo item in props)
            {
                if (item.CanRead)
                {
                    Console.WriteLine($"Property={item.Name},Value={item.GetValue(obj)}");
                }
            }
        }

        static object MyClone(object obj)
        {
            Type type = obj.GetType();
            object newObj = Activator.CreateInstance(type);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo item in props)
            {
                if (item.CanRead&&item.CanWrite)
                {
                    item.SetValue(newObj, item.GetValue(obj));
                }           
            }
            return newObj;
        }
    }



    public class Person
    {
        public Person()
        {

        }
        public Person(string name)
        {
            this.Name = name;
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public void SayHi()
        {
            Console.WriteLine($"大家好，我的姓名是{this.Name},我的年龄是{this.Age}.");
        }
        public void SayHi(string s)
        {
            Console.WriteLine($"{s}，我的姓名是{this.Name},我的年龄是{this.Age}.");
        }
    }
}
