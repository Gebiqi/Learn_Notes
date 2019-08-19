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
    public partial class FrmClient1 : Form
    {
        public FrmClient1()
        {
            InitializeComponent();
        }
        //2定义事件
        public event SendMsgDelegate SendMsgEvent;

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            //3激发事件
            SendMsgEvent("客户端1发送的消息："+textBoxMsg.Text.Trim());
        }
    }
}
