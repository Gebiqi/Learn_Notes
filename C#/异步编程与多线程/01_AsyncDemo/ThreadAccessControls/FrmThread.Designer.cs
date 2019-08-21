namespace ThreadAccessControls
{
    partial class FrmThread
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTask2 = new System.Windows.Forms.Button();
            this.btnTask1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTask1Result = new System.Windows.Forms.Label();
            this.lblTask2Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTask2
            // 
            this.btnTask2.Location = new System.Drawing.Point(220, 129);
            this.btnTask2.Name = "btnTask2";
            this.btnTask2.Size = new System.Drawing.Size(75, 23);
            this.btnTask2.TabIndex = 4;
            this.btnTask2.Text = "执行";
            this.btnTask2.UseVisualStyleBackColor = true;
            this.btnTask2.Click += new System.EventHandler(this.btnTask2_Click);
            // 
            // btnTask1
            // 
            this.btnTask1.Location = new System.Drawing.Point(71, 129);
            this.btnTask1.Name = "btnTask1";
            this.btnTask1.Size = new System.Drawing.Size(75, 23);
            this.btnTask1.TabIndex = 5;
            this.btnTask1.Text = "执行";
            this.btnTask1.UseVisualStyleBackColor = true;
            this.btnTask1.Click += new System.EventHandler(this.btnTask1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "任务【二】";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "任务【一】";
            // 
            // lblTask1Result
            // 
            this.lblTask1Result.AutoSize = true;
            this.lblTask1Result.Location = new System.Drawing.Point(106, 89);
            this.lblTask1Result.Name = "lblTask1Result";
            this.lblTask1Result.Size = new System.Drawing.Size(11, 12);
            this.lblTask1Result.TabIndex = 3;
            this.lblTask1Result.Text = "0";
            // 
            // lblTask2Result
            // 
            this.lblTask2Result.AutoSize = true;
            this.lblTask2Result.Location = new System.Drawing.Point(243, 89);
            this.lblTask2Result.Name = "lblTask2Result";
            this.lblTask2Result.Size = new System.Drawing.Size(11, 12);
            this.lblTask2Result.TabIndex = 2;
            this.lblTask2Result.Text = "0";
            // 
            // FrmThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 204);
            this.Controls.Add(this.btnTask2);
            this.Controls.Add(this.btnTask1);
            this.Controls.Add(this.lblTask2Result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTask1Result);
            this.Controls.Add(this.label1);
            this.Name = "FrmThread";
            this.Text = "通过线程访问控件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTask2;
        private System.Windows.Forms.Button btnTask1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTask1Result;
        private System.Windows.Forms.Label lblTask2Result;
    }
}

