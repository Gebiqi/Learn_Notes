using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflex
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Person p2 = new Person();
            Person p3 = new Person();
            Type type1 = p1.GetType();//1通过对象获取类的Type
            Type type2 = p2.GetType();//同上
            Type type3 = typeof(Person);//2通过类获取类的Type
            Type type4 = Type.GetType("Reflex.Person");//3通过类的全引用获取类的Type
            Console.WriteLine(type1);
            Console.WriteLine(type2);
            Console.WriteLine(type3);
            Console.WriteLine(type4);
            Console.WriteLine(object.ReferenceEquals(type1,type2));
            Console.WriteLine(object.ReferenceEquals(type2, type3));
            Console.WriteLine(object.ReferenceEquals(type3, type4));

            //通过类的Type对象可以动态创建类的对象
            //Activator.CreateInstance(type1); 该类必须有public且无参构造函数
            object obj1 = Activator.CreateInstance(type1);//CreateInstance返回值是object类型
            Person pp = (Person)obj1;
            pp.Name = "HuHu";
            pp.Say();

            Console.ReadLine();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public void Say()
        {
            Console.WriteLine($"Hello,My Name is {this.Name}.");
        }
    }
}
