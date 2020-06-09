namespace 自定义发包器
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
            this.texturl = new System.Windows.Forms.TextBox();
            this.URL = new System.Windows.Forms.Label();
            this.Cookie = new System.Windows.Forms.Label();
            this.datalabel = new System.Windows.Forms.Label();
            this.textxfx = new System.Windows.Forms.TextBox();
            this.textcookie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkua = new System.Windows.Forms.CheckBox();
            this.checkip = new System.Windows.Forms.CheckBox();
            this.send = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.zairu = new System.Windows.Forms.Button();
            this.sendtext = new System.Windows.Forms.TextBox();
            this.checkchongdingxiang = new System.Windows.Forms.CheckBox();
            this.file_path_button = new System.Windows.Forms.Button();
            this.textua = new System.Windows.Forms.TextBox();
            this.UserAgent = new System.Windows.Forms.Label();
            this.radioget = new System.Windows.Forms.RadioButton();
            this.radiopost = new System.Windows.Forms.RadioButton();
            this.textdata = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.renurn_len = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.return_time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // texturl
            // 
            this.texturl.ForeColor = System.Drawing.Color.DarkViolet;
            this.texturl.Location = new System.Drawing.Point(18, 32);
            this.texturl.Name = "texturl";
            this.texturl.Size = new System.Drawing.Size(404, 25);
            this.texturl.TabIndex = 0;
            this.texturl.Text = "http://qianxiao996.cn";
            // 
            // URL
            // 
            this.URL.AutoSize = true;
            this.URL.Location = new System.Drawing.Point(16, 12);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(31, 15);
            this.URL.TabIndex = 1;
            this.URL.Text = "URL";
            // 
            // Cookie
            // 
            this.Cookie.AutoSize = true;
            this.Cookie.Location = new System.Drawing.Point(15, 224);
            this.Cookie.Name = "Cookie";
            this.Cookie.Size = new System.Drawing.Size(55, 15);
            this.Cookie.TabIndex = 2;
            this.Cookie.Text = "Cookie";
            // 
            // datalabel
            // 
            this.datalabel.AutoSize = true;
            this.datalabel.Location = new System.Drawing.Point(15, 375);
            this.datalabel.Name = "datalabel";
            this.datalabel.Size = new System.Drawing.Size(39, 15);
            this.datalabel.TabIndex = 3;
            this.datalabel.Text = "data";
            // 
            // textxfx
            // 
            this.textxfx.ForeColor = System.Drawing.Color.DarkViolet;
            this.textxfx.Location = new System.Drawing.Point(17, 83);
            this.textxfx.Name = "textxfx";
            this.textxfx.Size = new System.Drawing.Size(491, 25);
            this.textxfx.TabIndex = 4;
            // 
            // textcookie
            // 
            this.textcookie.ForeColor = System.Drawing.Color.DarkViolet;
            this.textcookie.Location = new System.Drawing.Point(17, 242);
            this.textcookie.Multiline = true;
            this.textcookie.Name = "textcookie";
            this.textcookie.Size = new System.Drawing.Size(491, 72);
            this.textcookie.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "X-Forwarded-For";
            // 
            // checkua
            // 
            this.checkua.AutoSize = true;
            this.checkua.Location = new System.Drawing.Point(19, 349);
            this.checkua.Name = "checkua";
            this.checkua.Size = new System.Drawing.Size(105, 19);
            this.checkua.TabIndex = 13;
            this.checkua.Text = "启用随机UA";
            this.checkua.UseVisualStyleBackColor = true;
            // 
            // checkip
            // 
            this.checkip.AutoSize = true;
            this.checkip.Location = new System.Drawing.Point(140, 320);
            this.checkip.Name = "checkip";
            this.checkip.Size = new System.Drawing.Size(105, 19);
            this.checkip.TabIndex = 14;
            this.checkip.Text = "启用随机IP";
            this.checkip.UseVisualStyleBackColor = true;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(433, 321);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 44);
            this.send.TabIndex = 16;
            this.send.Text = "发送";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(342, 321);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 43);
            this.clear.TabIndex = 17;
            this.clear.Text = "清空";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // zairu
            // 
            this.zairu.Location = new System.Drawing.Point(251, 321);
            this.zairu.Name = "zairu";
            this.zairu.Size = new System.Drawing.Size(75, 43);
            this.zairu.TabIndex = 18;
            this.zairu.Text = "载入";
            this.zairu.UseVisualStyleBackColor = true;
            this.zairu.Click += new System.EventHandler(this.zairu_Click);
            // 
            // sendtext
            // 
            this.sendtext.ForeColor = System.Drawing.Color.DarkViolet;
            this.sendtext.Location = new System.Drawing.Point(18, 393);
            this.sendtext.Multiline = true;
            this.sendtext.Name = "sendtext";
            this.sendtext.Size = new System.Drawing.Size(490, 183);
            this.sendtext.TabIndex = 6;
            // 
            // checkchongdingxiang
            // 
            this.checkchongdingxiang.AutoSize = true;
            this.checkchongdingxiang.Location = new System.Drawing.Point(140, 349);
            this.checkchongdingxiang.Name = "checkchongdingxiang";
            this.checkchongdingxiang.Size = new System.Drawing.Size(104, 19);
            this.checkchongdingxiang.TabIndex = 22;
            this.checkchongdingxiang.Text = "跟踪重定向";
            this.checkchongdingxiang.UseVisualStyleBackColor = true;
            // 
            // file_path_button
            // 
            this.file_path_button.Location = new System.Drawing.Point(434, 30);
            this.file_path_button.Name = "file_path_button";
            this.file_path_button.Size = new System.Drawing.Size(75, 30);
            this.file_path_button.TabIndex = 27;
            this.file_path_button.Text = "多URL";
            this.file_path_button.UseVisualStyleBackColor = true;
            this.file_path_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // textua
            // 
            this.textua.BackColor = System.Drawing.SystemColors.Window;
            this.textua.ForeColor = System.Drawing.Color.DarkViolet;
            this.textua.Location = new System.Drawing.Point(17, 135);
            this.textua.Multiline = true;
            this.textua.Name = "textua";
            this.textua.Size = new System.Drawing.Size(491, 80);
            this.textua.TabIndex = 28;
            this.textua.Text = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0";
            // 
            // UserAgent
            // 
            this.UserAgent.AutoSize = true;
            this.UserAgent.Location = new System.Drawing.Point(15, 117);
            this.UserAgent.Name = "UserAgent";
            this.UserAgent.Size = new System.Drawing.Size(79, 15);
            this.UserAgent.TabIndex = 29;
            this.UserAgent.Text = "UserAgent";
            // 
            // radioget
            // 
            this.radioget.AutoSize = true;
            this.radioget.Checked = true;
            this.radioget.Location = new System.Drawing.Point(18, 320);
            this.radioget.Name = "radioget";
            this.radioget.Size = new System.Drawing.Size(52, 19);
            this.radioget.TabIndex = 30;
            this.radioget.TabStop = true;
            this.radioget.Text = "GET";
            this.radioget.UseVisualStyleBackColor = true;
            // 
            // radiopost
            // 
            this.radiopost.AutoSize = true;
            this.radiopost.Location = new System.Drawing.Point(73, 320);
            this.radiopost.Name = "radiopost";
            this.radiopost.Size = new System.Drawing.Size(60, 19);
            this.radiopost.TabIndex = 31;
            this.radiopost.Text = "POST";
            this.radiopost.UseVisualStyleBackColor = true;
            // 
            // textdata
            // 
            this.textdata.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textdata.Font = new System.Drawing.Font("幼圆", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textdata.ForeColor = System.Drawing.Color.Black;
            this.textdata.Location = new System.Drawing.Point(531, 32);
            this.textdata.Multiline = true;
            this.textdata.Name = "textdata";
            this.textdata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textdata.Size = new System.Drawing.Size(595, 544);
            this.textdata.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "返回数据包";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(879, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "返回长度:";
            // 
            // renurn_len
            // 
            this.renurn_len.AutoSize = true;
            this.renurn_len.Location = new System.Drawing.Point(957, 14);
            this.renurn_len.Name = "renurn_len";
            this.renurn_len.Size = new System.Drawing.Size(15, 15);
            this.renurn_len.TabIndex = 24;
            this.renurn_len.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(995, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "使用时间：";
            // 
            // return_time
            // 
            this.return_time.AutoSize = true;
            this.return_time.Location = new System.Drawing.Point(1070, 14);
            this.return_time.Name = "return_time";
            this.return_time.Size = new System.Drawing.Size(31, 15);
            this.return_time.TabIndex = 26;
            this.return_time.Text = "0ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 588);
            this.Controls.Add(this.radiopost);
            this.Controls.Add(this.radioget);
            this.Controls.Add(this.UserAgent);
            this.Controls.Add(this.textua);
            this.Controls.Add(this.file_path_button);
            this.Controls.Add(this.return_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.renurn_len);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkchongdingxiang);
            this.Controls.Add(this.sendtext);
            this.Controls.Add(this.zairu);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.send);
            this.Controls.Add(this.checkip);
            this.Controls.Add(this.checkua);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textdata);
            this.Controls.Add(this.textcookie);
            this.Controls.Add(this.textxfx);
            this.Controls.Add(this.datalabel);
            this.Controls.Add(this.Cookie);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.texturl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "自定义发包助手 by qianxiao996";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox texturl;
        private System.Windows.Forms.Label URL;
        private System.Windows.Forms.Label Cookie;
        private System.Windows.Forms.Label datalabel;
        private System.Windows.Forms.TextBox textxfx;
        private System.Windows.Forms.TextBox textcookie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkua;
        private System.Windows.Forms.CheckBox checkip;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button zairu;
        public System.Windows.Forms.TextBox sendtext;
        private System.Windows.Forms.CheckBox checkchongdingxiang;
        private System.Windows.Forms.Button file_path_button;
        private System.Windows.Forms.TextBox textua;
        private System.Windows.Forms.Label UserAgent;
        private System.Windows.Forms.RadioButton radioget;
        private System.Windows.Forms.RadioButton radiopost;
        public System.Windows.Forms.TextBox textdata;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label renurn_len;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label return_time;
    }
}

