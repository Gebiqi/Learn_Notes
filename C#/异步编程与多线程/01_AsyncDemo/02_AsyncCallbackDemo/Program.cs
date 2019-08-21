using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AsyncCallbackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            objCalculatorDelegate = new CalculatorDelegate(GetMulti);
            for (int i = 1; i <=10; i++)
            {
                //4 开始发布任务并同时执行多个任务
                objCalculatorDelegate.BeginInvoke(10 * i, 1000 * i, MyCallback, i);
            }
            Console.ReadLine();
        }
        //3将委托变量定义为成员变量
        static CalculatorDelegate objCalculatorDelegate = null;
        //2根据委托定义方法
        static int GetMulti(int n,int ms)
        {
            System.Threading.Thread.Sleep(ms);
            return n * n;
        }
        /// <summary>
        /// 5 回调函数 需要异步结果接口作为参数，以区分多个异步任务时区分各个该异步方法的执行结果
        /// </summary>
        /// <param name="result"></param>
        static private void MyCallback(IAsyncResult result)
        {
            int r = objCalculatorDelegate.EndInvoke(result);
            Console.WriteLine("第{0}个计算结果为{1}", result.AsyncState.ToString(),r);
            /* 特此说明
             * BeginInvoke的第三个参数是回调函数的参数，可以是多种类型=异步结果接口对象中
             * 的.AsyncState字段，类型需要从object进行转换
             * 特此说明
             */
        }

        //1定义委托
        public delegate int CalculatorDelegate(int num,int ms);
    }
}
