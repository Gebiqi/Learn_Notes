using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo02
{
    public partial class FrmSub2 : Form
    {
        public FrmSub2()
        {
            InitializeComponent();
        }
        //2根据委托原型创建方法
        public void ShowCount(string s)
        {
            this.lblCount.Text = s;
        }
    }
}
