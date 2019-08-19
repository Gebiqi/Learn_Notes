using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventDemo
{
    public partial class FrmClient1 : Form
    {
        public FrmClient1()
        {
            InitializeComponent();
        }

        //4定义与事件相关联的方法
        public void ReceiveMsg(string s)
        {
            this.textBoxMsg.Text = s;
        }
    }
}
