using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t1 = typeof(Person);
            object obj = Activator.CreateInstance(t1);
            //object obj = t1.GetConstructor(new Type[0]).Invoke(new object[0]);
            object obj2 = t1.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { "ABC" });
            PropertyInfo ProName = t1.GetProperty("Name");
            ProName.SetValue(obj, "haha");
            PropertyInfo ProAge = t1.GetProperty("Age");
            ProAge.SetValue(obj,20);
            MethodInfo methodSayHi = t1.GetMethod("SayHi", new Type[0]);
            methodSayHi.Invoke(obj, new object[0]);

            MethodInfo methodSayHi2 = t1.GetMethod("SayHi", new Type[1] {typeof(string)});
            methodSayHi2.Invoke(obj2,new object[1] { "zzzzzzzzzzzzzzz"});
            Console.ReadLine();
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
