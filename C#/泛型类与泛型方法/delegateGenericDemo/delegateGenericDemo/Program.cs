using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateGenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //1使用委托
            delegateGeneric<int> objDelegate1 = Add;
            delegateGeneric<double> objDelegate2 = Sub;
            Console.WriteLine(objDelegate1(20, 30));
            Console.WriteLine(objDelegate2(9.5, 4.22));
            Console.WriteLine("---------------------");
            //使用匿名方法
            delegateGeneric<int> objDelegate3 = delegate (int a, int b) { return a + b; };
            delegateGeneric<double> objDelegate4 = delegate (double a, double b) { return a - b; };
            Console.WriteLine(objDelegate3(20, 30));
            Console.WriteLine(objDelegate4(9.5, 4.22));
            Console.WriteLine("---------------------");
            //使用Lambda表达式
            //如果方法只需要使用一次，则使用Lambda表达式将非常简洁完成任务
            delegateGeneric<int> objDelegate5 = (a, b) =>a + b;
            delegateGeneric<double> objDelegate6 = (a, b) => a - b;
            Console.WriteLine(objDelegate5(20, 30));
            Console.WriteLine(objDelegate6(9.5, 4.22));
            Console.WriteLine("---------------------");

            //Test
            delegateGenericNew<int, double> objDelegate7 = AddNew;

            Console.ReadLine();


        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Sub(double a, double b)
        {
            return a - b;
        }

        static double AddNew(int a, int b)
        {
            return a + b;
        }
    }

    //定义泛型委托
    public delegate T delegateGeneric<T>(T a, T b);
    public delegate TResult delegateGenericNew<T, TResult>(T a,T b);
}
