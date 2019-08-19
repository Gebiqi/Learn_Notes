using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //3创建委托对象
            CalculatorDelegate objCal = new CalculatorDelegate(Add);
            //4通过使用委托调用方法
            Console.WriteLine("a+b="+objCal(30,20));
            //5通过动态更改委托指针指向的方法，进行方法切换
            objCal = Sub;
            //objCal -= Add;
            //objCal += Sub;
            Console.WriteLine("a-b="+objCal(30,20));
            Console.ReadLine();
        }

        //2根据委托原型创建方法
        static int Add(int a,int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
    }

    //1声明委托
    public delegate int CalculatorDelegate(int a, int b);
}
