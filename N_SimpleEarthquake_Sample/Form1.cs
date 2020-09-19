using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_SimpleEarthquake_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
            string wc_content = wc.DownloadString("https://data.narikakun.net/earthquake_easy.json?time=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            var json = JObject.Parse(wc_content);
            string main = $"タイトル: {json["title"].Value<string>()}\r\n時間: {json["time"].Value<string>()}\r\n震源地名: {json["name"].Value<string>()}\r\n深さ: {json["depth"].Value<string>()}km\r\n規模: {json["depth"].Value<string>()}\r\n震度: {json["maxint"].Value<string>()}\r\nコメント:\r\n{json["comment"].Value<string>()}";
            textBox1.Text = main;
        }
    }
}
