using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using SharpCompress;
using SharpCompress.Archive;
using SharpCompress.Common;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Windows_Privilege_Promotion_Query
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); 
            form2.Show();

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_in.Clear();
            textBox_out.Clear();
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            DialogResult diagorel = MessageBox.Show("确认重新下载数据文件？", "更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (diagorel == DialogResult.Yes)
            {
                Form3 form3 = new Form3();
                form3.Show();
                form3.Visible = true;
                form3.DownloadFile("https://raw.githubusercontent.com/bitsadmin/wesng/master/definitions.zip", @"definitions.zip");
                //form3.DownloadFile("http://127.0.0.1/definitions.zip", @"definitions.zip");
                var archive = ArchiveFactory.Open(@"definitions.zip");
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        //   Console.WriteLine(entry.FilePath);
                        entry.WriteToDirectory(path + @"\CVE", ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                    }
                }
                MessageBox.Show("文件解压成功,程序正在重启...");
                Reboot();  //重启程序
                //Close();
            }


        }

        private void Reboot()
        {

            Application.ExitThread();
            Application.Exit();
            Application.Restart();
            Process.GetCurrentProcess().Kill();
        }

        public DataTable dt = new DataTable();//文件写入的数据表
        public String file_path = "";
        private void Form1_Load(object sender, EventArgs e)
        {

      
            List<string> CSVfile = new List<String>();//创建了一个空列表 存放解压的CSV文件

            string path = System.IO.Directory.GetCurrentDirectory();
            if (System.IO.Directory.Exists(path + @"\CVE")) //判断文件是否存在
            {
                DirectoryInfo TheFolder = new DirectoryInfo(path + @"\CVE");
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    //Console.WriteLine(NextFile.ToString());
                    CSVfile.Add(NextFile.ToString());
                }
                for (int i = 0; i < CSVfile.Count; i++)
                {

                    //找到数据文件 CVEs_20190817.csv 
                    if (CSVfile[i].Substring(0, 4) == "CVEs")
                    {
                        file_path = path + @"\CVE\" + CSVfile[i];
                        //System.Console.WriteLine(CSVdata);  //输出的是CSV数据文件路径
                    }
                    //System.Console.WriteLine(CSVfile[i]);
                }
                if (file_path == "")
                {
                    MessageBox.Show("数据文件丢失，请更新或者手动下载！");
                    更新ToolStripMenuItem_Click(null,null);
                    Reboot();  //重启程序


                }
                //进行文件读取
                else
                {
                    //遍历CSV文件
                    StreamReader sr = new StreamReader(file_path, System.Text.Encoding.UTF8);

                    string strLine;
                    string[] aryLine = null;
                    string[] tableHead = null;
                    //标示列数
                    int columnCount = 0;
                    //标示是否是读取的第一行
                    bool IsFirst = true;
                    //逐行读取CSV中的数据
                    while ((strLine = sr.ReadLine()) != null)
                    {

                        if (IsFirst == true)
                        {
                            tableHead = strLine.Split(',');

                            IsFirst = false;
                            columnCount = tableHead.Length;
                            //创建列
                            for (int i = 0; i < columnCount; i++)
                            {
                                //System.Console.WriteLine(tableHead[i]);
                                DataColumn dc = new DataColumn(tableHead[i]);
                                dt.Columns.Add(dc);
                            }
                        }
                        else
                        {
                            aryLine = strLine.Split(',');
                            DataRow dr = dt.NewRow();
                            for (int j = 0; j < columnCount; j++)
                            {
                                //  System.Console.WriteLine(aryLine[j]);
                                dr[j] = aryLine[j];
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                    if (aryLine != null && aryLine.Length > 0)
                    {
                        dt.DefaultView.Sort = tableHead[0] + " " + "asc";
                    }
                    sr.Close();

                }
            }
            else
            {
                MessageBox.Show("数据文件不存在，尝试解压文件...");
                if (System.IO.File.Exists("definitions.zip"))
                {
                    try
                    {
                        var archive = ArchiveFactory.Open(@"definitions.zip");
                        foreach (var entry in archive.Entries)
                        {
                            if (!entry.IsDirectory)
                            {
                                //   Console.WriteLine(entry.FilePath);
                                entry.WriteToDirectory(path + @"\CVE", ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                                CSVfile.Add(entry.FilePath);

                            }
                        }
                        MessageBox.Show("文件解压成功！");

                    }
                    catch 
                    {
                        MessageBox.Show("文件已损坏，请手动删除definitions.zip文件！");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("压缩文件不存在，尝试下载文件...");
                    Form3 form3 = new Form3();
                    form3.Visible = true;
                    form3.Show();
                    form3.DownloadFile("https://raw.githubusercontent.com/bitsadmin/wesng/master/definitions.zip", @"definitions.zip");
                    //form3.DownloadFile("http://127.0.0.1/definitions.zip", @"definitions.zip");
                    var archive = ArchiveFactory.Open(@"definitions.zip");
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            //   Console.WriteLine(entry.FilePath);
                            entry.WriteToDirectory(path + @"\CVE", ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                    }
                    MessageBox.Show("文件解压成功！");

                }

            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_out.Clear();
            List<string> buding = new List<String>();//创建了一个空列表 存放已打的补丁
            string in_data = textBox_in.Text;
            //提取已经打的补丁号
            MatchCollection matches = Regex.Matches(in_data, @"\[[0-9]{2}\]: KB[0-9]{7}");
            foreach (Match item in matches)
            {
                buding.Add(item.Groups[0].Value);  //提取后的值
            }
            //遍历不等于补丁号

            if (buding.Count>0)
            {
                DataTable dt22 = new DataTable();//所有可用exp数据表
                dt22 = dt;
                //读取表中某一列 
                for (int i = 0; i < dt22.Rows.Count; i++)
                {
                    String columens = dt22.Rows[i][2].ToString();  //第2列，KB号
                    foreach (String j in buding)
                    {

                        String num = j.Replace("[08]:KB", "");

                        if (num == columens && radioButton_exp.Checked)  //删除相同的行
                        {
                            dt22.Rows.RemoveAt(i);
                        }
                        if (num == columens && !radioButton_exp.Checked && (dt22.Rows[i][7].ToString()) != "Elevation of Privilege")//删除相同的行
                        {
                            dt22.Rows.RemoveAt(i);  //移除行
                        }

                    }
                    //Console.WriteLine(dt.Columns[1].ColumnName.ToString());得到列名
                }

                //遍历dt22写入数据
                String choose = comboBox1.Text;
                //Console.WriteLine(choose);
           
                for (int i = 0; i < dt22.Rows.Count; i++)
                {
                    String windwos_type = dt22.Rows[i][4].ToString().Replace("\"","");  //第4列，windwos系统
                    //如果包含字符串写入，否则不写入

                    bool isContains = windwos_type.Contains(choose);


                    if (isContains)
                    {
                        for (int j = 0; j < dt22.Columns.Count; j++)
                        {

                            textBox_out.AppendText((dt22.Columns[j].ColumnName.ToString() + ":" + dt22.Rows[i][j].ToString() + "\r\n").Replace("\"", ""));  //输出到窗口  列名+值
                        }
                        textBox_out.AppendText("\r\n");
                    }


                }
            }

        }
    }


}
    

    

