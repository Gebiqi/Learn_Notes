using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            FrmClient1 objFrmClient1 = new FrmClient1();
            FrmClient2 objFrmClient2 = new FrmClient2();

            //5将发送者的事件关联到接收者的处理方法
            objFrmClient1.SendMsgEvent += new SendMsgDelegate(ReceiveMsg);
            objFrmClient2.SendMsgEvent += new SendMsgDelegate(ReceiveMsg);

            objFrmClient1.Show();
            objFrmClient2.Show();
        }
        //4定义事件对应的处理方法
        private void ReceiveMsg(string s)
        {
            this.textBoxMsg.Text = s;
        }
    }
    //1声明委托
    public delegate void SendMsgDelegate(string s);
}
