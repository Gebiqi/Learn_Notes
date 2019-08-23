using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDataPager
{
    public partial class FrmMain : Form
    {
        private CommonDataPager objPager = null;
        public FrmMain()
        {
            InitializeComponent();
            objPager = new CommonDataPager()
            {
                FieldsName = "StudentId,StudentName,Gender,Birthday,PhoneNumber",
                TableName = "Students",
                Sort = "StudentId ASC",
                PrimaryKey = "StudentId"
            };
            //初始化每页显示10条
            cboRecordList.SelectedIndex = 1;
            //禁用datagridview的自动生成列
            dgvLogList.AutoGenerateColumns = false;
            //禁用按钮
            btnToPage.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
            btnNext.Enabled = false;
            btnPre.Enabled = false;
            //初始化日期选择框
            dtpBirthday.Text = "1988-01-01";

        }

        private void QueryData()
        {
            objPager.PageSize = Convert.ToInt32(this.cboRecordList.Text.Trim());
            objPager.Condition = string.Format("birthday>'{0}'",dtpBirthday.Text);
            this.dgvLogList.DataSource = objPager.GetPageData();
            //显示记录总数、总页数、当前页码
            this.lblRecordsCount.Text = objPager.RecordCount.ToString();
            this.lblPageCount.Text = objPager.TotalPages.ToString();
            if (objPager.RecordCount==0)
            {
                this.lblCurrentPageIndex.Text = "0";
            }
            else
            {
                this.lblCurrentPageIndex.Text = objPager.CurrentPageNo.ToString();
            }

            //按钮的启用与禁用
            if (objPager.TotalPages>objPager.CurrentPageNo)
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
            if (objPager.CurrentPageNo>=2)
            {
                this.btnFirst.Enabled = true;
                this.btnPre.Enabled = true;
            }
            else
            {
                this.btnFirst.Enabled = false;
                this.btnPre.Enabled = false;
            }
            if (objPager.TotalPages>1)
            {
                this.btnToPage.Enabled = true;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageNo = 1;
            QueryData();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageNo = 1;
            QueryData();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageNo--;
            QueryData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageNo++;
            QueryData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            objPager.CurrentPageNo = objPager.TotalPages;
            QueryData();
        }

        private void btnToPage_Click(object sender, EventArgs e)
        {
            if (txtToPage.Text.Trim().Length==0)//增加对跳转页码文本框的验证
            {
                MessageBox.Show("请输入要跳转的页码!");
                txtToPage.Focus();
                return;
            }
            if (Convert.ToInt32(txtToPage.Text.Trim())>objPager.TotalPages)
            {
                MessageBox.Show("跳转的页码不能超过总页数!");
                txtToPage.SelectAll();
                txtToPage.Focus();
                return;
            }
                objPager.CurrentPageNo = Convert.ToInt32(txtToPage.Text.Trim());
                QueryData();
                txtToPage.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
