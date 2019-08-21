using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadDemo
{
    public partial class FrmThread : Form
    {
        public FrmThread()
        {
            InitializeComponent();
        }

        private void btnTask1_Click(object sender, EventArgs e)
        {
            int a = 0;
            //使用多线程
            Thread objThread1 = new Thread(() => {     
                for (int i = 0; i < 20; i++)
                {
                    a += i;
                    Console.WriteLine(a);
                    Thread.Sleep(500);
                }
            });
            objThread1.IsBackground = true;
            objThread1.Start();
        }

        private void btnTask2_Click(object sender, EventArgs e)
        {
            int a = 0;
            //使用多线程
            Thread objThread2 = new Thread(() => {
                for (int i = 0; i < 50; i++)
                {
                    a += i;
                    Console.WriteLine("------"+a+"------");
                    Thread.Sleep(200);
                }
            });
            objThread2.IsBackground = true;
            objThread2.Start();
        }
    }
}
