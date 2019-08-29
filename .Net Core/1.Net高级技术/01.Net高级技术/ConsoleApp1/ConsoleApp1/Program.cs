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
            ////4密闭类和静态类及扩展方法（静态方法）
            //Person p1 = new Person();
            //p1[1, 2] = "abc";
            //string result = p1[3, 5];
            //Console.WriteLine(result);

            Console.WriteLine("----------------");
            Dog d1 = new Dog(); 
            d1["wangwang"] = 12;
            int resultDog = d1["hahaha"];
            Console.WriteLine(resultDog);

            //Console.WriteLine("aa@aa.com".IsEmail());
            //Console.WriteLine("ABC".Repeat(10));
            ////等价于Console.WriteLine(Helper.Repeat("ABC",5));

            ////5深copy和浅copy
            //PersonTest p1 = new PersonTest();
            //p1.Name = "ABC";
            //p1.Age = 10;
            //PersonTest p2 = p1;//让p2指向当前p1对象  只有一个对象
            //PersonTest p3 = new PersonTest(); //复制了一份   两个对象，互相不影响
            //p3.Name = p1.Name;
            //p3.Age = p1.Age;


            //PersonTest p4 = new PersonTest();
            //p4.Name = "abc";
            //p4.Age = 3;

            //DogTest dog1 = new DogTest();
            //dog1.Name = "wangcai";

            //p4.dog = dog1;

            //PersonTest p5 = new PersonTest();
            //p5.Name = p4.Name;
            //p5.Age = p5.Age;

            //p5.dog = p4.dog;//浅copy

            //DogTest dog2 = new DogTest();//深copy
            //dog2.Name = dog1.Name;
            //p5.dog = dog2;

            ////6结构体、值类型及引用类型
            //DogTest objDog1 = new DogTest();
            //objDog1.Name = "aaa";
            //DogTest objDog2 = objDog1;
            //objDog1.Name = "bbb";
            //Console.WriteLine(objDog2.Name);

            //DogStruct objdog1s = new DogStruct();
            //objdog1s.Name = "aaa";
            //DogStruct objdog2s = objdog1s;
            //objdog1s.Name = "bbb";
            //Console.WriteLine(objdog2s.Name);

            //int[] nums = { 1, 3, 5, 7, 9 };
            //Test(nums);
            //Console.WriteLine(nums[1]);

            ////9关于相等
            //DogTest dog1 = new DogTest();
            //dog1.Name = "wangwang";
            //DogTest dog2 = dog1;
            //DogTest dog3 = new DogTest();
            //dog3.Name = "wangwang";
            //DogTest dog4 = new DogTest();
            //dog4.Name = "wangwang";
            //Console.WriteLine(object.ReferenceEquals(dog1,dog2));
            //Console.WriteLine(object.ReferenceEquals(dog1, dog3));
            //Console.WriteLine(dog1.Equals(dog4));//重载Equal方法
            //Console.WriteLine(dog1==dog4);//重载==运算符和!=运算符

            //Console.WriteLine(dog1==dog2);
            //Console.WriteLine(dog1==dog3);

            //string s1 = "abc";
            //string s2 = s1;
            //string s3 = new string(new char[] { 'a','b','c'});
            //Console.WriteLine(object.ReferenceEquals(s1,s2));
            //Console.WriteLine(object.ReferenceEquals(s1,s3));

            //Console.WriteLine(s1==s2);
            //Console.WriteLine(s1==s2);


            ////10字符串缓冲池
            //string s1 = "abc";
            //string s2 = "abc";
            //string s3 = "a" + "b" + "c";
            //string s4 = new string(new char[] { 'a', 'b', 'c' });
            //Console.WriteLine(object.ReferenceEquals(s1, s2));
            //Console.WriteLine(object.ReferenceEquals(s1, s3));
            //Console.WriteLine(object.ReferenceEquals(s1, s4));

            //ref和out关键字
            PersonTest p = new PersonTest();
            p.Name = "abc";
            int i = 5;
            Test2(p, i);//引用类型和值类型在方法内部传参调用时的不同           
            Console.WriteLine(p.Name);          
            Console.WriteLine(i);

            Test3(ref p, ref i);
            Console.WriteLine(p.Name);
            Console.WriteLine(i);

            int ii;
            Test4(out ii);
            Console.WriteLine(ii);

            Console.ReadLine();
        }

        public class Person
        {
            public string this[int x, int y]
            {
                get
                {
                    return "hahaha";
                }
                set
                {
                    Console.WriteLine("x=" + x + "y=" + y);
                }
            }
        }

        public class Dog
        {
            public int this[string s]//索引器
            {
                get
                {
                    return 888;
                }
                set
                {
                    Console.WriteLine($"Hello,{s},value={value}");
                }
            }
        }

        public class PersonTest
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DogTest dog { get; set; }

        }
        public class DogTest
        {
            public string Name { get; set; }
            public override bool Equals(object obj) //Equal方法重载
            {
                if (!(obj is DogTest))
                {
                    return false;
                }
                else
                {
                    DogTest that = (DogTest)obj;
                    if (this.Name == that.Name)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public static bool operator ==(DogTest left, DogTest right)  //运算符重载
            {
                return left.Equals(right);
            }

            public static bool operator !=(DogTest left, DogTest right)
            {
                return !left.Equals(right);
            }
        }

        public struct DogStruct
        {
            public string Name { get; set; }
        }

        static void Test(int[] n)
        {
            n[1] = 123;
        }
        static void Test2(PersonTest p,int i)
        {
            p.Name = "zzz";
            i = 100;
        }
        static void Test3(ref PersonTest p, ref int i)
        {
            p = new PersonTest();
            p.Name = "ttt";
            i = 100;
        }
        static void Test4(out int i)
        {
            i = 6;
        }
    }
}
