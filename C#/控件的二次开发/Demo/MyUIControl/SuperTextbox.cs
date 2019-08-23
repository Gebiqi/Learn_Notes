using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//引入窗体的命名空间
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MyUIControl
{
    public partial class SuperTextbox : TextBox
    {
        public SuperTextbox()
        {
            InitializeComponent();
        }

        public SuperTextbox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// 非空验证
        /// </summary>
        /// <returns></returns>
        public int CheckEmpty()
        {
            if (this.Text.Trim()=="")
            {
                this.errorProvider.SetError(this, "必填项不得为空");
                return 0;
            }
            else
            {
                this.errorProvider.SetError(this,string.Empty);
                return 1;
            }
        }
        /// <summary>
        /// 基于正则表达式的高级验证
        /// </summary>
        /// <param name="regularExpress"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public int RegCheck(string regularExpress,string errorMessage)
        {
            if (CheckEmpty()==0)
            {
                return 0;
            }
            //定义正则表达式
            Regex objRegex = new Regex(regularExpress, RegexOptions.IgnoreCase);
            if (!objRegex.IsMatch(this.Text.Trim()))
            {
                this.errorProvider.SetError(this, errorMessage);
                return 0;
            }
            else
            {
                this.errorProvider.SetError(this, string.Empty);
                return 1;
            }
            
        }
    }
}
