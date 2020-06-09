using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义发包器
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
            //int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度
            //Location = new Point(xWidth / 2, yHeight / 2);//这里需要再减去窗体本身的宽度和高度的一半
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            Form1 f1 = (Form1)this.Owner;
            f1.textdata.Text = listView1.SelectedItems[0].SubItems[8].Text;
            f1.renurn_len.Text = listView1.SelectedItems[0].SubItems[5].Text;
            f1.return_time.Text = listView1.SelectedItems[0].SubItems[7].Text;
            f1.texturl.Text = listView1.SelectedItems[0].SubItems[2].Text;
            f1.sendtext.Text = listView1.SelectedItems[0].SubItems[4].Text;

        }
        private void listView1_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {
            if (this.listView1.Columns[e.Column].Tag == null)
                this.listView1.Columns[e.Column].Tag = true;
            bool flag = (bool)this.listView1.Columns[e.Column].Tag;
            if (flag)
                this.listView1.Columns[e.Column].Tag = false;
            else
                this.listView1.Columns[e.Column].Tag = true;
            this.listView1.ListViewItemSorter = new ListViewSort(e.Column, this.listView1.Columns[e.Column].Tag);
            this.listView1.Sort();//对列表进行自定义排序  

        }
    }

    internal class ListViewSort : IComparer
    {
        private int col;
        private bool descK;
        public ListViewSort()
        {
            col = 0;
        }
        public ListViewSort(int column, object Desc)
        {
            descK = (bool)Desc;
            col = column; //当前列,0,1,2...,参数由ListView控件的ColumnClick事件传递 
        }
        public int Compare(object x, object y)
        {
            int tempInt = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            if (descK) return -tempInt;
            else return tempInt;
        }
    }
}

