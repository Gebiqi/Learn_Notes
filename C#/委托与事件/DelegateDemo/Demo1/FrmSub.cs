using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1
{
    public partial class FrmSub : Form
    {
        //3定义委托对象
        public ShowCountDelegate showCount;
        private int count = 0;
        public FrmSub()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if (showCount!=null)
            {
                //使用委托对象调用方法
                showCount(count.ToString());
            }
        }
    }
}
