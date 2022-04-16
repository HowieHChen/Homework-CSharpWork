using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework7
{
    public class Crawler
    {
        public delegate void PrintLog(string log);
        public event PrintLog PrintLogDelegate;
        public event PrintLog PrintDoneDelegate;
        public event PrintLog PrintErrorDelegate;

        private int count = 0;
        public Hashtable urls = new Hashtable();

        private string baseUrl;
        private string baseHost;

        private readonly string urlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        private readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";

        public Crawler(string bUrl)
        {
            baseUrl = bUrl;
            baseHost = Regex.Match(baseUrl, urlParseRegex).Groups["host"].Value;
            urls.Clear();
            urls.Add(baseUrl,false);
        }

        public void Crawl()
        {
            PrintLogDelegate("开始爬行");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null || count > 10) break;
                PrintLogDelegate("爬行" + current + "页面!");
                string html = Download(current);
                Regex ishtml = new Regex(@"^<!DOCTYPE html>");
                urls[current] = true;
                count++;
                if (ishtml.IsMatch(html))
                {
                    PrintLogDelegate(current + "是html，爬行成功！");
                    PrintDoneDelegate(current);
                    Parse(html);
                }
                else
                {
                    PrintErrorDelegate(current);
                }
            }
            PrintLogDelegate("爬行结束");
        }

        private string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html)
        {
            MatchCollection matches = new Regex(urlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") continue;
                if (Regex.IsMatch(linkUrl, @"^/")) linkUrl = baseUrl + linkUrl;
                string host = Regex.Match(linkUrl, urlParseRegex).Groups["host"].Value;
                if (urls[linkUrl] == null && host == baseHost) urls[linkUrl] = false;
            }
        }


    }
}
