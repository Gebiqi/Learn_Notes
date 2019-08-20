using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegateDemo
{
    class Program
    {

        #region Func委托的基本使用
        //static void Main(string[] args)
        //{
        //Func<int, int, double> objFuncDelegate = Add;
        //Console.WriteLine(objFuncDelegate(20, 30));
        //Console.ReadLine();
        //}

        //static double Add(int a, int b)
        //{
        //    return a + b;
        //}
        #endregion

        #region Func委托的重要作用
        //定义一个数组，要求在数组中指定位置截取指定个数的值进行求和、求积运算

        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //传统方法
            Console.WriteLine(GetSum(nums, 6, 10));
            Console.WriteLine(GetMulti(nums, 6, 10));

            Console.WriteLine("-----------------");
            //使用泛型方法Func
            Console.WriteLine(CommonMethod((a, b) => a + b, nums, 6, 10));
            Console.WriteLine(CommonMethod((a, b) => a * b, nums, 6, 10));


            Console.ReadLine();
        }

        static int GetSum(int[] nums, int from, int to)
        {
            int results = 0;
            for (int i = from; i <= to; i++)
            {
                results += nums[i];
            }
            return results;
        }
        static int GetMulti(int[] nums, int from, int to)
        {
            int results = 1;
            for (int i = from; i <= to; i++)
            {
                results *= nums[i];
            }
            return results;
        }
        static int CommonMethod(Func<int, int, int> operation, int[] nums, int from, int to)//将运算本身作为参数传递给方法，这个参数是有返回值的泛型方法，所以使用Func来作为形参
        {
            int results = nums[from];
            for (int i = from + 1; i <= to; i++)
            {
                results = operation(results, nums[i]);
            }
            return results;
        }

        #endregion





    }

    ////Func系列泛型委托 注意，最后一个参数是方法的返回值类型
    //public delegate TResult Func<TResult>();
    //public delegate TResult Func<T, TResult>(T arg);
    //public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);
    //public delegate TResult Func<T1, T2, T3, TResult>(T1 arg, T2 arg2, T3 arg3);
    //public delegate TResult Func<T1, T2, T3, T4, TResult>(T1 arg, T2 arg2, T3 arg3, T4 arg4);
    ////...


}
