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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            FrmSub objfrmSub = new FrmSub();
            //4 将委托对象与方法关联
            objfrmSub.showCount = ShowCount;
            objfrmSub.Show();
        }


        //2根据委托定义方法
        private void ShowCount(string c)
        {
            lblCount.Text = c;
        }
    }

    //1定义委托
    public delegate void ShowCountDelegate(string c);
}
