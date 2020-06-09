using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace 自定义发包器
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            //窗口居中
            AutoResize(this);//函数调用
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void AutoResize(Form frm)
        {
            frm.Tag = frm.Width.ToString() + "," + frm.Height.ToString();
            frm.SizeChanged += new EventHandler(Form1_SizeChanged);
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            string[] tmp = ((Form)sender).Tag.ToString().Split(',');
            float width = (float)((Form)sender).Width / (float)Convert.ToInt16(tmp[0]);
            float heigth = (float)((Form)sender).Height / (float)Convert.ToInt16(tmp[1]);

            ((Form)sender).Tag = ((Form)sender).Width.ToString() + "," + ((Form)sender).Height;

            foreach (Control control in ((Form)sender).Controls)
            {
                control.Scale(new SizeF(width, heigth));
            }
        }

        private void clear_Click(object sender, EventArgs e)
        { //清空所有文字
            foreach (Control Ctrol in this.Controls)
            {
                if (Ctrol is TextBox)
                {
                    Ctrol.Text = "";
                }
            }
    
            sendtext.Text = "";   //清空POST数据

    

        }
        public static string postdata, getdata, hostdata,xfxdata,xridata,uadata, cookiedata, getdata2,ua,xfx;

        private void button1_Click(object sender, EventArgs e)
        {
            texturl.Text = Open_url_file();
        }
        public  static  string Open_url_file()
        {
            //新建一个文件对话框
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();

            //设置对话框标题
            pOpenFileDialog.Title = "打开shp文件";

            //设置打开文件类型
            pOpenFileDialog.Filter = "文本文件（*.txt）|*.txt";

            //监测文件是否存在
            pOpenFileDialog.CheckFileExists = true;

            //文件打开后执行以下程序
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                return System.IO.Path.GetFullPath(pOpenFileDialog.FileName);
                //System.IO.Path.GetFullPath(pOpenFileDialog.FileName);                             //绝对路径
                //System.IO.Path.GetExtension(pOpenFileDialog.FileName);                           //文件扩展名
                //System.IO.Path.GetFileNameWithoutExtension(pOpenFileDialog.FileName);//文件名没有扩展名
                //System.IO.Path.GetFileName(pOpenFileDialog.FileName);                          //得到文件
                //System.IO.Path.GetDirectoryName(pOpenFileDialog.FileName);                  //得到路径
            }
            else
            {
                return null;
            }
        }
        public static bool chongdingxiang;
      
        private void send_Click(object sender, EventArgs e)
        {
            string host = (texturl.Text);
            if (!host.Contains("http://") && !host.Contains("https://"))
            {
                if (File.Exists(host) && host != null)
                {
                    //按行读取文件
                    StreamReader sr = new StreamReader(host, Encoding.UTF8);
                    String line;
                    Form2 myForm = new Form2();//构建B窗体的一个实例
                    myForm.Show(this);//显示B窗体

                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if ((line.ToString().Contains("http://") || line.ToString().Contains("https://")) && (line.ToString() != "\r\n") && (line.ToString() != "\n") && (line.ToString() != "\r"))
                        {
                            List<string> data = new List<string>();
                            data = Send_request(line.ToString());

                           // Console.WriteLine(line.ToString());
                            ListViewItem item = new ListViewItem();      //先实例化ListViewItem这个类
                          //  item.Text = "1";                             
                            item.SubItems.Add((i++).ToString());                     
                            item.SubItems.Add(line.ToString());
                            item.SubItems.Add(data[0]);
                            item.SubItems.Add(data[1]);                    
                            item.SubItems.Add(data[2]);
                            item.SubItems.Add(data[3]);
                            item.SubItems.Add(data[4]);
                            item.SubItems.Add(data[5]);
                            myForm.listView1.Items.Add(item);                   //添加集体进去
               




                        }
                    }
                    sr.Close();

                }
                else
                {
                    MessageBox.Show("未获取到URL！");
                }
            }
            else
            {
                List<string> data = new List<string>();
                data = Send_request(host);
                
                textdata.Text = data[5];
                renurn_len.Text = data[2];
                return_time.Text = data[4];
            }

        }
        public  List<string> Send_request(string host)
        {

            List<string> all_Data = new List<string>();//创建了一个空列表
            string cookie = textcookie.Text;
            string senddata = sendtext.Text;

            //检查是否选中跟踪重定向
            if (checkchongdingxiang.Checked == true)
            {
                chongdingxiang = true;

            }
            else
            {
                chongdingxiang = false;
            }
            //检查是否启用随机UA
            if (checkua.Checked == true)
            {
                var ualist = new List<string>();

                ualist.Add("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0");
                ualist.Add("Mozilla/5.0 (X11; Linux x86_64; rv:65.0) Gecko/20100101 Firefox/65.0");
                ualist.Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_3) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/11.1.1 Safari/605.1.15");
                ualist.Add("Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko");
                ualist.Add("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");
                ualist.Add("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.47 Safari/537.36");
                ualist.Add("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:60.5) Gecko/20100101 Firefox/60.5");
                ualist.Add("Mozilla/5.0 (Android 9.0; Mobile; rv:65.0) Gecko/65.0 Firefox/65.0");
                ualist.Add("Mozilla/5.0 (Linux; Android 9.0; Z832 Build/MMB29M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.47 Mobile Safari/537.36");
                ualist.Add("Mozilla/5.0 (Linux; Android 9.0; SAMSUNG-SM-T377A Build/NMF26X) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.47 Mobile Safari/537.36");
                ualist.Add("Mozilla/5.0 (iPhone; CPU OS 10_14_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/11.1.1 Mobile/14E304 Safari/605.1.15");
                ualist.Add("Mozilla/5.0 (iPad; CPU OS 10_14_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/11.1.1 Mobile/15E148 Safari/605.1.15");
                ualist.Add("Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)");
                ualist.Add("Mozilla/5.0 (PlayStation 4 4.71) AppleWebKit/601.2 (KHTML, like Gecko)");
                ualist.Add("curl/7.64.0");
                ualist.Add("Wget/1.20.1 (linux-gnu)");
                ualist.Add("Mozilla/5.0 (iPhone; CPU iPhone OS 8_0 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Mobile/12A365 MicroMessenger/5.4.1 NetType/WIFI");
                ualist.Add("Dalvik/2.1.0 (Linux; U; Android 9; MI 8 MIUI/9.3.14)");
                ualist.Add("IE/6.5 (Windows: U; Windows NT 5.1; zh-HK;rv:1.7.5)");
                ualist.Add("Opera/9.80 (Macintosh; Intel Mac OS X 10.6.8; U; en) Presto/2.8.131 Version/11.11");
                Random rm = new Random();
                int i = rm.Next(ualist.Count); //随机数最大值不能超过list的总数
                ua = ualist[i];

            }
            else
            {
                ua = textua.Text;
            }

            //是否启用随机ip

            if (checkip.Checked == true)
            {

                Random ran = new Random();
                int ip1 = ran.Next(1, 255);
                int ip2 = ran.Next(1, 255);
                int ip3 = ran.Next(1, 255);
                int ip4 = ran.Next(1, 255);
                xfx = ip1 + "." + ip2 + "." + ip3 + "." + ip4;

            }
            else
            {
                xfx = textxfx.Text;
            }
            string strResult = "";
            string huafei_time;
            string renurn_len;
            if (radioget.Checked == true) //get请求
            {
                string url;
                if (senddata != "")
                {
                    url = host + "?" + senddata;
                }
                else
                {
                    url = host;
                }

                //GET请求
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException("url");
                }
                
                try
                {
                    DateTime startTime = DateTime.Now;
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                    request.Method = "GET";
                    request.AllowAutoRedirect = chongdingxiang;  //是否跟随302
                    if (!string.IsNullOrEmpty(ua))  //ua
                    {
                        request.UserAgent = ua;
                    }
                    request.Timeout = 2000; //超时2s

                    if (!string.IsNullOrEmpty(cookie))  //cookie 
                    {
                        request.Headers.Add("Cookie", cookie);
                    }
                    if (!string.IsNullOrEmpty(xfx))  //xfx
                    {
                        request.Headers.Add("X-Forword-For", xfx);
                    }
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.KeepAlive = false;  //关闭连接 Connection: close
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    DateTime endTime = DateTime.Now;
                    huafei_time = Convert.ToInt32((endTime - startTime).TotalMilliseconds).ToString() + "ms";//获取相应时间
                    all_Data.Add("GET");
                    //Console.WriteLine(url);
                    if (url.Split('?').Length == 2)
                    {
                        all_Data.Add(url.Split('?')[1].ToString());
                    }
                    else
                    {
                        all_Data.Add("");
                    }
                    //renurn_len.Text = (retString.Length).ToString(); 

                    string returncode = Convert.ToInt32(response.StatusCode) + " " + response.StatusCode.ToString();//Statuscode 为枚举类型，200为正常，其他输出异常，需要转为int型才会输出状态码
                    var HeaderList = new List<string>(); ////返回头
                    renurn_len = response.Headers["Content-Length"];
                    
                    
                    all_Data.Add(renurn_len);
                    all_Data.Add((Convert.ToInt32(response.StatusCode)).ToString());
                    all_Data.Add(huafei_time);
                    foreach (string HeaderKey in response.Headers)
                    {
                        HeaderList.Add(HeaderKey + ": " + response.Headers[HeaderKey]);
                    }
                    //foreach (string HeaderKey in response.Headers)
                    //  HeaderList.Add(HeaderKey + ": " + response.Headers[HeaderKey]);
                    response.Close();
                    strResult = "HTTP/1.1 " + returncode;
                    foreach (string HeaderKey in HeaderList)
                        strResult += "\r\n" + HeaderKey;
                    strResult = strResult + "\r\n\r\n" + (retString.Replace("\n", "\r\n"));
                    all_Data.Add(strResult);
                }
                catch (System.Exception ex)
                {

                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        strResult = "error：" + ex.Message;//返回异常信息
                        all_Data.Add(strResult);

                }

                

            }
            
            if (radiopost.Checked == true)//POST请求
            {
                try
                {
                    System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(host);
                    Encoding encoding = Encoding.UTF8;
                    string responseData = System.String.Empty;
                    if (!string.IsNullOrEmpty(ua))  //ua
                    {
                        req.UserAgent = ua;
                    }
                    req.Timeout = 2000; //超时1s

                    if (!string.IsNullOrEmpty(cookie))  //cookie 
                    {
                        req.Headers.Add("Cookie", cookie);
                    }
                    if (!string.IsNullOrEmpty(xfx))  //xfx
                    {
                        req.Headers.Add("X-Forword-For", xfx);
                    }
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.KeepAlive = false;  //关闭连接 Connection: close
                    req.Method = "POST";
                    req.AllowAutoRedirect = chongdingxiang;  //是否跟随302
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = senddata.Length;
                    try
                    {
                        DateTime startTime = DateTime.Now;
                        using (System.IO.Stream reqStream = req.GetRequestStream())
                        {

                            StreamWriter myStreamWriter = new StreamWriter(reqStream, Encoding.GetEncoding("gb2312"));
                            myStreamWriter.Write(senddata);
                            myStreamWriter.Close();


                        }
                        using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)req.GetResponse())
                        {
                            DateTime endTime = DateTime.Now;
                            all_Data.Add("POST");
                            all_Data.Add(senddata);
                            huafei_time = Convert.ToInt32((endTime - startTime).TotalMilliseconds).ToString() + "ms";//获取相应时间
                            
                            using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8))
                            {

                                responseData = reader.ReadToEnd().ToString();
                                // renurn_len.Text = (responseData.Length).ToString();

                                //得到请求头
                                string returncode = Convert.ToInt32(response.StatusCode) + " " + response.StatusCode.ToString();//Statuscode 为枚举类型，200为正常
                                var HeaderList = new List<string>(); ////返回头
                                renurn_len = response.Headers["Content-Length"];

                                all_Data.Add(renurn_len);
                                all_Data.Add((Convert.ToInt32(response.StatusCode)).ToString());
                                all_Data.Add(huafei_time);
                                foreach (string HeaderKey in response.Headers)
                                {
                                    HeaderList.Add(HeaderKey + ": " + response.Headers[HeaderKey]);
                                }
                                response.Close();
                                strResult = "HTTP/1.1 " + returncode;
                                foreach (string HeaderKey in HeaderList)
                                    strResult += "\r\n" + HeaderKey;
                                strResult = strResult + "\r\n\r\n" + responseData.Replace("\n", "\r\n");
                                all_Data.Add(strResult);
                                //textdata.Text = strResult;
                                //在这里对接收到的页面内容进行处理 
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {

                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        all_Data.Add("0");
                        strResult = "error：" + ex.Message;//返回异常信息
                        all_Data.Add(strResult);
                    }
                }
                catch (System.Exception ex)
                {

                    all_Data.Add("0");
                    all_Data.Add("0");
                    all_Data.Add("0");
                    all_Data.Add("0");
                    all_Data.Add("0");
                    all_Data.Add("0");
                    all_Data.Add("0");
                    strResult = "error：" + ex.Message;//返回异常信息
                    all_Data.Add(strResult);
                }
            }
            return all_Data;
        }
        private void zairu_Click(object sender, EventArgs c)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "文本文件|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.Directory.Exists(openFileDialog.FileName)) //判断路径是否存在
                {
                    MessageBox.Show("您选择的路径不存在！");
                }
                else {
                    //读取文件
                    try
                    {
                        // 创建一个 StreamReader 的实例来读取文件 

                        StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
                        var data = new List<string>(); //存放整个数据包
                        string line;
           
                        while ((line = sr.ReadLine()) != null)// 从文件读取一行
                        {
                            if (line != "")
                            {

                                //Console.WriteLine(line);

                                if (line.Length >= 4 && line.Substring(0, 4) == "POST")
                                {
                                    postdata = (line.Remove(0, 5)).Replace("HTTP/1.1", ""); //去掉前n个字符,移除http/1.1
                                    string[] sArray = postdata.Split('?');
                                    radiopost.Checked = true;
                                    postdata = sArray[0];
                                }

                                if (line.Length >= 3 && line.Substring(0, 3) == "GET")
                                {
                                    getdata = (line.Remove(0, 4)).Replace("HTTP/1.1", ""); //去掉前n个字符,移除http/1.1

                                    string[] sArray = getdata.Split('?');
                                    radioget.Checked = true;
                                    getdata = sArray[0];

                                    if (getdata2 != null)
                                        getdata2 = sArray[1];
                                    else
                                        getdata = "";

                                }
                                if (line.Length >= 5 && line.Substring(0, 5) == "Host:")
                                {
                                    hostdata = (line.Remove(0, 6)).Replace(" ", "");
                                    hostdata = "http://" + hostdata + getdata + postdata;




                                }
                                if ((line.Length >= 16 )&&( line.Substring(0, 16) == "X-Forwarded-For:" || line.Substring(0, 16) == "x-forwarded-for:"))
                                {
                                    xfxdata = (line.Remove(0, 16)).Replace(" ", "");

                                }
                                if (line.Length >= 10 && (line.Substring(0, 10) == "X-Real-IP:" || line.Substring(0, 10) == "x-real-ip:"))
                                {
                                    xridata = (line.Remove(0, 11)).Replace(" ", "");

                                }

                                if (line.Length >= 11 && line.Substring(0, 11) == "User-Agent:")
                                {
                                    uadata = (line.Remove(0, 11)).Replace(" ", "");

                                }
                                if (line.Length >= 7 && line.Substring(0, 7) == "Cookie:")
                                {
                                    cookiedata = (line.Remove(0, 7)).Replace(" ", "");

                                }
                                data.Add(line);  //存放完整的数据包
                            }

                        }
                        sr.Close(); //关闭文件
                   
                        if (getdata != null)
                            sendtext.Text = getdata2;

                        else
                            sendtext.Text = data[data.Count()-1];  //设置post数据

                    }
                    catch (Exception e)
                    {
                        // 向用户显示出错消息
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }
                }
                texturl.Text = hostdata; //设置url
                textua.Text = uadata; //设置ua
                textxfx.Text = xfxdata + xridata; //设置x-forword-for 或者x-r-i
                xfxdata = "";
                xridata = "";
                textcookie.Text = cookiedata; //设置cookie

            }
          

        }
    }
}
