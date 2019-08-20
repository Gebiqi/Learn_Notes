using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegateDemo
{
    class Program
    {
        #region Action方法的使用
        static void Main(string[] args)
        {
            Action<string> act = s => Console.WriteLine("Hello,{0}", s);
            act("HuHu");
            Console.ReadLine();
        }
        #endregion
    }
    ////Action系列泛型委托 注意，没有返回值
    //public delegate void Func();
    //public delegate void Func<T>(T arg);
    //public delegate void Func<T1, T2>(T1 arg1, T2 arg2);
    //public delegate void Func<T1, T2, T3>(T1 arg, T2 arg2, T3 arg3);
    //public delegate void Func<T1, T2, T3, T4>(T1 arg, T2 arg2, T3 arg3, T4 arg4);
    ////...
}
