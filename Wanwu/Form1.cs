using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        //API URL
        private static readonly string apiUrl = "https://api.lingyiwanwu.com/v1/chat/completions";
        private static string apiKey = "";

        //消息列表
        private static List<Dictionary<string, string>> messageHistory = new List<Dictionary<string, string>>();

        //创建一个用于检测鼠标是否停留在btnCopy按钮上的Timer对象
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            txtInput.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13) //判断是否按下回车键
                {
                    //禁止回车键产生换行
                    e.Handled = true; //设置为true来阻止默认换行行为
                    btnSendRequest.PerformClick(); //模拟按钮点击事件
                }
            };

            txtAPIKey.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13) //判断是否按下回车键
                {
                    //禁止回车键产生换行
                    e.Handled = true; //设置为true来阻止默认换行行为
                    btnSettings.PerformClick(); //模拟按钮点击事件
                }
            };

            //订阅MouseMove事件
            txtShow.MouseMove += txtShow_MouseMove;  

            //初始化Timer设置为每隔100毫秒触发一次
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //将上次有效的APIKey初始化到窗口中
            txtAPIKey.Text= Wanwu.Properties.Settings.Default.APIKey;
        }

        private void txtShow_MouseMove(object sender, MouseEventArgs e)
        {
            //检查鼠标是否停留在特定位置
            if (e.X >= btnCopy.Location.X - txtShow.Location.X && e.X <= btnCopy.Location.X - txtShow.Location.X + btnCopy.Size.Width && e.Y >= btnCopy.Location.Y - txtShow.Location.Y && e.Y <= btnCopy.Location.Y - txtShow.Location.Y + btnCopy.Size.Height)
            {
                //显示按钮
                btnCopy.Visible = true;
                timer.Start(); //启动 Timer
            }
        }

        //定时器触发时执行隐藏按钮
        private void Timer_Tick(object sender, EventArgs e)
        {

            //获取鼠标位置
            Point mousePos = Control.MousePosition;
            //将鼠标位置转换为按钮的客户端坐标
            Point clientMousePos = btnCopy.PointToClient(mousePos);
            //判断鼠标是否离开按钮区域
            if (!btnCopy.ClientRectangle.Contains(clientMousePos))
            {
                //隐藏复制按钮
                btnCopy.Visible = false;
                timer.Stop();
            }
        }


        //发送请求
        private async void btnSendRequest_Click(object sender, EventArgs e)
        {
            //光标移动到输入框
            txtInput.Focus();
            //禁用按钮，防止连点
            btnSendRequest.Enabled = false;
            btnSettings.Enabled = false;
            btnReset.Enabled = false;
            txtShow.Text = "";
            if (apiKey != "")
            {
                //获取文本框中的输入内容
                string userInput = txtInput.Text;
                if (userInput == "")
                {
                    txtShow.Text = "请输入内容";
                }
                else
                {
                    txtShow.Text = "正在获取响应，请稍后......";
                    // 调用异步方法获取结果
                    string result = await SendRequestAsync(userInput);
                    // 显示返回结果
                    txtShow.Text = result;
                }
            }
            else
            {
                txtShow.Text = "请设置正确的API Key";
            }
            btnSendRequest.Enabled = true;
            btnSettings.Enabled = true;
            btnReset.Enabled = true;
        }

        //发送请求的方法
        public static async Task<string> SendRequestAsync(string str)
        {
            //控制历史消息数量
            if(messageHistory.Count >= 10)
            {
                messageHistory.RemoveRange(0, 2);
            }
            using (var client = new HttpClient())
            {
                //设置请求头
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                //添加消息到历史消息列表
                Dictionary<string, string> mesUser = new Dictionary<string, string>
                    {
                        { "role", "user" },
                        { "content", str }
                    };
                messageHistory.Add(mesUser);

                // 构建请求体
                var jsonData = new
                {
                    model = "yi-large",
                    messages = messageHistory,
                    temperature = 0.3
                };

                //使用JsonConvert将对象转为JSON字符串
                string jsonString = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

                //使用StringContent将JSON数据传入请求
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                try
                {
                    //发送POST请求
                    var response = await client.PostAsync(apiUrl, content);
                    //确保请求成功
                    response.EnsureSuccessStatusCode();
                    //读取并输出响应内容
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseObject = JObject.Parse(responseContent);
                    //访问嵌套字段
                    var messageContent = responseObject?["choices"]?.FirstOrDefault()?["message"]?["content"]?.ToString();
                    if (messageContent != null)
                    {
                        Dictionary<string, string> mesAssistant = new Dictionary<string, string>
                    {
                        { "role", "assistant" },
                        { "content", messageContent }
                    };
                        messageHistory.Add(mesAssistant);
                        return messageContent;
                    }
                    else
                    {
                        return "没有有效内容返回......";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return "Error: " + ex.Message;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAPIKey.Text = "";
            apiKey = "";
            Wanwu.Properties.Settings.Default.APIKey = apiKey;
            Wanwu.Properties.Settings.Default.Save();
            txtShow.Text = "API Key重置成功";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //验证APIKey的正则表达式
            string pattern = "^[a-z0-9]{32}$";
            //创建Regex对象
            Regex regex = new Regex(pattern);
            //使用IsMatch方法检查输入字符串是否匹配
            bool isMatch = regex.IsMatch(this.txtAPIKey.Text);
            if (isMatch)
            {
                apiKey = this.txtAPIKey.Text.ToString();
                Wanwu.Properties.Settings.Default.APIKey = apiKey;
                Wanwu.Properties.Settings.Default.Save();
                txtShow.Text = "API Key设置成功";
            }
            else
            {
                apiKey = "";
                txtShow.Text = "请设置正确的API Key";
            }
        }

        private void APIKeylink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://platform.lingyiwanwu.com/";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //将展示框的内容复制到剪贴板
            Clipboard.SetText(txtShow.Text);
        }
    }
}