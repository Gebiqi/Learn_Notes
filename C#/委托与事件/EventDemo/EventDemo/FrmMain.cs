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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            FrmClient1 objFrmClient1 = new FrmClient1();
            FrmClient2 objFrmClient2 = new FrmClient2();

            //5关联事件关联的处理方法
            //SendMsgEvent += objFrmClient1.ReceiveMsg;
            //SendMsgEvent += objFrmClient2.ReceiveMsg;
            SendMsgEvent += new SendMsgDelegate(objFrmClient1.ReceiveMsg);
            SendMsgEvent += new SendMsgDelegate(objFrmClient2.ReceiveMsg);

            objFrmClient1.Show();
            objFrmClient2.Show();
        }
        //2定义事件
        private event SendMsgDelegate SendMsgEvent;

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            //3激发事件
            SendMsgEvent(textBoxMsg.Text.Trim());
        }
    }

    //1定义委托
    public delegate void SendMsgDelegate(string s);

    
}
