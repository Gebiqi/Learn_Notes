using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t1 = typeof(Person);
            Console.WriteLine(t1.BaseType);
            Console.WriteLine(t1.FullName);
            Console.WriteLine(t1.Namespace);
            Console.WriteLine(t1.Name);
            Type t2 = typeof(Gender);
            Console.WriteLine(t2.IsEnum);
            ConstructorInfo c1 = t1.GetConstructor(new Type[0]);
            ConstructorInfo c2 = t1.GetConstructor(new Type[1] {typeof(string) });
            ConstructorInfo c3 = t1.GetConstructor(new Type[2] {typeof(string),typeof(int) });
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);

           FieldInfo[] fields= t1.GetFields(BindingFlags.NonPublic|BindingFlags.Instance);//获取非public字段
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field);
            }

            MethodInfo[] methods = t1.GetMethods();//默认只返回public的
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method);
            }
            MethodInfo method1 = t1.GetMethod("SayHi",new Type[0]);
            MethodInfo method2 = t1.GetMethod("SayHi", new Type[] {typeof(string) });
            Console.WriteLine(method1);
            Console.WriteLine(method2);

            PropertyInfo[] propertys = t1.GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                Console.WriteLine(property);
            }

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

        }
        public Person(string name,int age)
        {

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

    public enum Gender { male,female};
}
