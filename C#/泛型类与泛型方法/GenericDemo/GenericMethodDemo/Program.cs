using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add1("我是HuHu","Hello~"));
            Console.WriteLine("20+30={0}",Add1(20,30));
            Console.WriteLine("20.5+18.6={0}", Add1(20.5, 18.6));
            Console.WriteLine("20+18.6={0}", Add1(20, 18.6));
            Console.WriteLine("---------------------");
            Console.WriteLine("20+18.6={0}", Add(20, 18.6));
            Console.WriteLine("20+18.6={0}", Sub(20, 18.6));
            Console.WriteLine("20+18.6={0}", Multiply(20, 18.6));
            Console.WriteLine("20+18.6={0}", Div(20, 18.6));
            Console.WriteLine("-----------计算一个数的求和--------");
            Console.WriteLine(Sum(10));
            Console.ReadLine();
        }

        #region 1实现四则混合运算
        static T Add1<T>(T a,T b)
        {
            dynamic m = a;
            dynamic n = b;
            return m + n;
        }
        static T Add<T>(T a, T b) where T:struct//T必须为值类型
        {
            dynamic m = a;
            dynamic n = b;
            return m + n;
        }
        static T Sub<T>(T a, T b) where T : struct//T必须为值类型
        {
            dynamic m = a;
            dynamic n = b;
            return m - n;
        }
        static T Multiply<T>(T a, T b) where T : struct//T必须为值类型
        {
            dynamic m = a;
            dynamic n = b;
            return m * n;
        }
        static T Div<T>(T a, T b) where T : struct//T必须为值类型
        {
            dynamic m = a;
            dynamic n = b;
            return m/n;
        }
        #endregion

        #region 2编写一个泛型方法实现一个数自求和
        //private static int Sum(int a)
        //{
        //    int result = 0;
        //    for (int i = 0; i <= a; i++)
        //    {
        //        result += i;
        //    }
        //    return result;
        //}
        private static T Sum<T>(T a) where T:struct
        {
            dynamic result = default(T);
            for (dynamic i = default(T); i <= a; i++)
            {
                result += i;
            }
            return (T)result;
        }
        #endregion
    }
}
