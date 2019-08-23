using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int a = stbName.CheckEmpty();
            int b = stbAge.CheckEmpty();

            int c = stbAge.RegCheck(@"^[1-9]\d*$", "年龄必须是正整数！");

            int result = a * b * c;
            if (result != 0)
            {
                //添加到数据库操作
                MessageBox.Show("数据添加成功！", "信息提示");
            }
        }
    }
}
