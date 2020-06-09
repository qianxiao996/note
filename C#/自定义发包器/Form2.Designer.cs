namespace 自定义发包器
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.IDdadasd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HOST = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Methods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Parameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDdadasd,
            this.ID,
            this.HOST,
            this.Methods,
            this.Parameter,
            this.Length,
            this.Code,
            this.Time,
            this.Data});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-1, -1);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1054, 338);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick_1);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // IDdadasd
            // 
            this.IDdadasd.Text = "";
            this.IDdadasd.Width = 0;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HOST
            // 
            this.HOST.Text = "HOST";
            this.HOST.Width = 150;
            // 
            // Methods
            // 
            this.Methods.Text = "Methods";
            this.Methods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Parameter
            // 
            this.Parameter.Text = "Parameter";
            this.Parameter.Width = 100;
            // 
            // Length
            // 
            this.Length.Text = "Length";
            this.Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Code
            // 
            this.Code.Text = "Code";
            this.Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Data
            // 
            this.Data.Text = "Data";
            this.Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Data.Width = 220;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 336);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "数据包列表视图";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader IDdadasd;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader HOST;
        private System.Windows.Forms.ColumnHeader Length;
        private System.Windows.Forms.ColumnHeader Time;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Data;
        private System.Windows.Forms.ColumnHeader Code;
        private System.Windows.Forms.ColumnHeader Methods;
        private System.Windows.Forms.ColumnHeader Parameter;
    }
}