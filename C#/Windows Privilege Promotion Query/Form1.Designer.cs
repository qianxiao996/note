namespace Windows_Privilege_Promotion_Query
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_in = new System.Windows.Forms.TextBox();
            this.label_tishi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_result = new System.Windows.Forms.Label();
            this.radioButton_exp = new System.Windows.Forms.RadioButton();
            this.radioButton_all = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_out = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_in
            // 
            this.textBox_in.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_in.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox_in.Location = new System.Drawing.Point(16, 72);
            this.textBox_in.Multiline = true;
            this.textBox_in.Name = "textBox_in";
            this.textBox_in.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_in.Size = new System.Drawing.Size(440, 552);
            this.textBox_in.TabIndex = 1;
            // 
            // label_tishi
            // 
            this.label_tishi.AutoSize = true;
            this.label_tishi.Location = new System.Drawing.Point(16, 48);
            this.label_tishi.Name = "label_tishi";
            this.label_tishi.Size = new System.Drawing.Size(177, 15);
            this.label_tishi.TabIndex = 2;
            this.label_tishi.Text = "请输入systeminfo信息：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(336, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(762, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Windows Privilege Promotion Query                 ";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.ForeColor = System.Drawing.Color.Black;
            this.label_result.Location = new System.Drawing.Point(464, 48);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(61, 15);
            this.label_result.TabIndex = 4;
            this.label_result.Text = "可用exp";
            // 
            // radioButton_exp
            // 
            this.radioButton_exp.AutoSize = true;
            this.radioButton_exp.Location = new System.Drawing.Point(136, 634);
            this.radioButton_exp.Name = "radioButton_exp";
            this.radioButton_exp.Size = new System.Drawing.Size(127, 19);
            this.radioButton_exp.TabIndex = 6;
            this.radioButton_exp.Text = "仅查询提权exp";
            this.radioButton_exp.UseVisualStyleBackColor = true;
            // 
            // radioButton_all
            // 
            this.radioButton_all.AutoSize = true;
            this.radioButton_all.Checked = true;
            this.radioButton_all.Location = new System.Drawing.Point(16, 632);
            this.radioButton_all.Name = "radioButton_all";
            this.radioButton_all.Size = new System.Drawing.Size(112, 19);
            this.radioButton_all.TabIndex = 7;
            this.radioButton_all.TabStop = true;
            this.radioButton_all.Text = "查询所有exp";
            this.radioButton_all.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.更新ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "清空";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.更新ToolStripMenuItem.Text = "更新";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // textBox_out
            // 
            this.textBox_out.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_out.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox_out.Location = new System.Drawing.Point(464, 72);
            this.textBox_out.Multiline = true;
            this.textBox_out.Name = "textBox_out";
            this.textBox_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_out.Size = new System.Drawing.Size(440, 552);
            this.textBox_out.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Windows 7",
            "Windows 8",
            "Windows 10",
            "Windows Server 2003",
            "Windows Server 2008",
            "Windows Server 2012",
            "Windows Server 2016",
            "Windows RT",
            "Windows Vista",
            "Microsoft Exchange",
            "Microsoft Excel",
            "Microsoft SharePoint",
            "Microsoft Office",
            "Microsoft Lync",
            "Microsoft Word",
            "Microsoft Live",
            "Microsoft Silverlight",
            "Microsoft Edge",
            "Microsoft Internet",
            "Microsoft Internet",
            "Microsoft AutoUpdate",
            "Microsoft SQL Server",
            "Microsoft .NET Framework",
            "Microsoft Dynamics",
            "Skype for Business"});
            this.comboBox1.Location = new System.Drawing.Point(719, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 23);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "Windows 7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 663);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox_out);
            this.Controls.Add(this.radioButton_all);
            this.Controls.Add(this.radioButton_exp);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_tishi);
            this.Controls.Add(this.textBox_in);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Privilege Promotion Query   by qianxiao996";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_in;
        private System.Windows.Forms.Label label_tishi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.RadioButton radioButton_exp;
        private System.Windows.Forms.RadioButton radioButton_all;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_out;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

