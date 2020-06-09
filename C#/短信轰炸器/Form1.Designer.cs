namespace 短信轰炸器
{
    partial class Form1
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
            this.phone_num = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zhuangtai = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // phone_num
            // 
            this.phone_num.Location = new System.Drawing.Point(16, 40);
            this.phone_num.Name = "phone_num";
            this.phone_num.Size = new System.Drawing.Size(160, 25);
            this.phone_num.TabIndex = 1;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(16, 72);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(72, 47);
            this.start.TabIndex = 2;
            this.start.Text = "开始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(96, 72);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(80, 47);
            this.stop.TabIndex = 3;
            this.stop.Text = "停止";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "手机号码";
            // 
            // zhuangtai
            // 
            this.zhuangtai.AutoSize = true;
            this.zhuangtai.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.zhuangtai.ForeColor = System.Drawing.Color.Red;
            this.zhuangtai.Location = new System.Drawing.Point(83, 16);
            this.zhuangtai.Name = "zhuangtai";
            this.zhuangtai.Size = new System.Drawing.Size(91, 15);
            this.zhuangtai.TabIndex = 5;
            this.zhuangtai.Text = "等待开始...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(191, 133);
            this.Controls.Add(this.zhuangtai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.phone_num);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox phone_num;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label zhuangtai;
    }
}

