using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWhere
{
    class Program
    {
        static void Main(string[] args)
        {
            ////9 集合的常用高级扩展方法
            //int[] nums = new int[] { 2,44,2,211,23,4,44,3,3,2};
            //IEnumerable<int> result = nums.MyWhere(i => i >= 10);
            //foreach (int item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //string[] ss = new string[] { "lily","tom","jame","lucy","jacky","dudu"};
            //foreach (string item in ss.MyWhere(s=>s.Contains("a")))
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerable<int> result2= nums.Select(i => i * i);
            //foreach (int item in result2)
            //{
            //    Console.WriteLine(item);
            //}

            //int[] nums1 = new int[] {1,2,3,4,5 };
            //List<int> list1 = nums1.OrderBy(i => i).ToList();//使用linq扩展方法将数组集合转为List集合
            //int[] nums2 = list1.ToArray();//使用linq扩展方法将List集合转为数组集合

            //10 委托的组合
            MyDelegate objDel1 = new MyDelegate(F1);
            MyDelegate objDel2 = new MyDelegate(F2);
            MyDelegate objDel3 = new MyDelegate(F3);
            MyDelegate objDel4 = objDel1 + objDel2 + objDel3;
            MyDelegate objDel5 = new MyDelegate(F1) + new MyDelegate(F2) + new MyDelegate(F3);

            objDel4(9);
            Console.WriteLine("-----------");
            objDel5(5);

            Console.ReadKey();
        }

        static void F1(int i)
        {
            Console.WriteLine(i);
        }
        static void F2(int i)
        {
            Console.WriteLine(i*2);
        }
        static void F3(int i)
        {
            Console.WriteLine(i*i);
        }
    }

    public delegate void MyDelegate(int i);
}
