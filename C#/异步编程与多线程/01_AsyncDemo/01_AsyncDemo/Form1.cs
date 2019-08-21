using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_AsyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 同步执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask1_Click(object sender, EventArgs e)
        {
            lblResult1.Text = ExecTask1(35).ToString();
            lblResult2.Text = ExecTask2(55).ToString();
            //...
        }
        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask2_Click(object sender, EventArgs e)
        {
            //3实例化委托对象 并赋值需要引用的方法
            CalculatorDelegate objCalculatorDelegate = ExecTask1;
            //1开始异步调用
            //通过委托的BeginInvoke方法进行异步调用
            //BeginInvoke是异步调用的核心
            IAsyncResult result = objCalculatorDelegate.BeginInvoke(35, null, null);
            //2并行执行其他任务
            lblResult1.Text = "正在计算，请稍等...";
            lblResult2.Text = ExecTask2(55).ToString();

            //3获取异步执行结果 借助IAsyncResult接口对象 不断查询异步调用是否结束
            //该接口对象有异步调用方法的所有参数，调用结束后取出结果作为返回值
            int r = objCalculatorDelegate.EndInvoke(result);
            lblResult1.Text = r.ToString();
        }

        private int ExecTask1(int a)
        {
            System.Threading.Thread.Sleep(5000);
            return a * a;
        }
        //2根据委托实现方法
        private int ExecTask2(int a)
        {
           // System.Threading.Thread.Sleep(5000);
            return a * a;
        }
    }
    //1定义委托
    public delegate int CalculatorDelegate(int a);
}
