using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Homework8
{
    public partial class Form1 : Form
    {
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wd = textBox1.Text;
            Thread thread1 = new Thread(() => Search("textBox2", wd));
            Thread thread2 = new Thread(() => Search("textBox3", wd));
            thread1.Start();
            thread2.Start();
        }

        public void Print(string boxName, List<string> list)
        {
            if (boxName == "textBox2")
            {
                foreach (string item in list)
                {
                    this.Invoke(new Action(() =>
                    {
                        textBox2.AppendText(item);
                        textBox2.AppendText(System.Environment.NewLine);
                    }));
                }
            }
            else
            {
                foreach (string item in list)
                {
                    this.Invoke(new Action(() =>
                    {
                        textBox3.AppendText(item);
                        textBox3.AppendText(System.Environment.NewLine);
                    }));
                }
            }
        }

        public void Search(string boxName, string wd)
        {
            string url = "https://www.baidu.com/s?wd=" + wd;
            string html = string.Empty;
            string xpathDetectRegex = @"<h3(\s|\S)*?>(\s|\S)*?</h3>";
            string xpathURLRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
            string xpathTitleRegex = @"<a[\s\S]*>(?<title>[\s\S]*)</a>";

            try
            {
                WebClient webClient = new WebClient();          
                //webClient.Headers.Add("User-Agent", "Mozilla / 5.0(Android; Mobile; rv: 58.0) Gecko / 58.0 Firefox / 58.0");
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36");
                webClient.Encoding = Encoding.UTF8;
                html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

            MatchCollection matches = new Regex(xpathDetectRegex).Matches(html);
            string title = string.Empty;
            string href = string.Empty;
            List<string> list = new List<string>();
            foreach (Match match in matches)
            {
                title = Regex.Match(match.Value, xpathTitleRegex).Groups["title"].Value;
                href = Regex.Match(match.Value, xpathURLRegex).Groups["url"].Value;
                list.Add(title);
                list.Add(href);
            }
            Print(boxName, list);
        }
    }
}
