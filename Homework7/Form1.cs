using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        private readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";

        private readonly string idRegex = @"\d{17}(\d|X|x)";
        private readonly int[] idWeight = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        private readonly char[] idChar = { '1', '0', 'x', '9', '8', '7', '6', '5', '4', '3', '2' };


        public Form1()
        {
            InitializeComponent();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            string strHTML = textBox_URL.Text;
            if (strHTML == string.Empty || !Regex.IsMatch(strHTML,urlParseRegex))
            {
                MessageBox.Show("输入链接有误", "错误");
                return;
            }
            Crawler crawler = new Crawler(strHTML);
            crawler.PrintLogDelegate += new Crawler.PrintLog(PrintLog);
            crawler.PrintDoneDelegate += new Crawler.PrintLog(PrintDone);
            crawler.PrintErrorDelegate += new Crawler.PrintLog(PrintError);
            new Thread(crawler.Crawl).Start();
        }

        public void PrintLog(string log)
        {
            string time = DateTime.Now.ToString();
            this.Invoke(new Action(() =>
            {
                textBox_Log.AppendText(time + " " + log);
                textBox_Log.AppendText(System.Environment.NewLine);
            }));
        }

        public void PrintDone(string log)
        {
            this.Invoke(new Action(() =>
            {
                textBox_Done.AppendText(log);
                textBox_Done.AppendText(System.Environment.NewLine);
            }));
        }

        public void PrintError(string log)
        {
            this.Invoke(new Action(() =>
            {
                textBox_Error.AppendText(log);
                textBox_Error.AppendText(System.Environment.NewLine);
            }));
        }

        private void button_Check_Click(object sender, EventArgs e)
        {
            string idString = textBox_ID.Text.Replace('X', 'x');
            if(idString.Length != 18 || !Regex.IsMatch(idString,idRegex))
            {
                MessageBox.Show("身份证号不合法", "错误");
                textBox_ID.Text = string.Empty;
                return;
            }
            int sum = 0;
            for (int i = 0; i < idString.Length - 1; i++)
            {
                sum += idWeight[i] * int.Parse(idString[i].ToString());
            }
            if (idChar[sum % 11] == idString.Last())
            {
                MessageBox.Show("身份证号合法", "注意");
                return;
            }
            else
            {
                MessageBox.Show("身份证号不合法", "注意");
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
