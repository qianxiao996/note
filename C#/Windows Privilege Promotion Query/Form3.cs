using SharpCompress.Archive;
using SharpCompress.Common;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
           
            //
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        public void DownloadFile(string URL, string filename)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (progressBar1 != null)
                {
                    progressBar1.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (progressBar1 != null)
                    {
                        progressBar1.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    label1.Text = "当前文件下载进度" + percent.ToString() + "%";
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                    if ((int)percent == 100)
                    {
                        Close();
                        MessageBox.Show("文件下载完成！");
                        break;


                    }
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                Close();
                MessageBox.Show("文件下载失败，请联系作者或手动下载！");
            }
        }
        

    }

    
}
