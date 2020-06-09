using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Privilege_Promotion_Query
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.link_blog.Links[0].LinkData = "https://blog.qianxiao996.cn";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void link_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.link_github.Links[0].LinkData = "https://github.com/qianxiao996";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            
        }
    }
}
