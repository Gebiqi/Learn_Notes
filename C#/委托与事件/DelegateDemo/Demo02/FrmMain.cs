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
    public partial class FrmMain : Form
    {
        //3创建委托对象
        private ShowCountDelegate objShowCountDelegate;
        private int count = 0;
        public FrmMain()
        {
            InitializeComponent();
            FrmSub1 objFrmSub1 = new FrmSub1();
            FrmSub2 objFrmSub2 = new FrmSub2();
            FrmSub3 objFrmSub3 = new FrmSub3();

            //4委托对象关联方法
            objShowCountDelegate += objFrmSub1.ShowCount;
            objShowCountDelegate += objFrmSub2.ShowCount;
            objShowCountDelegate += objFrmSub3.ShowCount;

            objFrmSub1.Show();
            objFrmSub2.Show();
            objFrmSub3.Show();
        }

        private void btn_ClickMe_Click(object sender, EventArgs e)
        {
            //5通过委托对象调用方法
            count++;
            if (objShowCountDelegate!=null)
            {
                objShowCountDelegate.Invoke(count.ToString());
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            count = 0;
            if (objShowCountDelegate!=null)
            {
                objShowCountDelegate(count.ToString());
            }
        }
    }

    //声明委托
    public delegate void ShowCountDelegate(string s);
}
