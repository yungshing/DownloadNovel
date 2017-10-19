using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;
namespace Yungs.Novel.Source
{
    public class MingYueZhongWen : BaseSource
    {
        public MingYueZhongWen()
        {
            Addr = "http://so.365if.com/cse/search?q=#*书名*#&s=2556979918274449445&nsid=0";
            novelSource = "明月中文";
        }
        protected override NovelInfo GetNorvalInfo(string novelName)
        {
            NovelInfo n = new NovelInfo();

            n.Source = novelSource;
            
            string html = WebClientDownload(Addr.Replace("#*书名*#", novelName),Encoding.UTF8);
            
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var node = doc.GetElementbyId("results").SelectSingleNode("//div[@class='result-list gameblock-result-list']");
            var w = node.SelectSingleNode("//a[@cpos='title']").GetAttributeValue("href", "15");
            if (w == "15")
            {
                Exist = false;
                return n;
            }

            html = WebClientDownload(w, Encoding.Default);
            doc.LoadHtml(html);
            node = doc.DocumentNode.SelectSingleNode("//div[@class='main']");
            var v1 = node.SelectSingleNode("h1").InnerText.Trim().Replace("\r\n", "");
            var v2 = v1.Split(new string[] { "作者" }, StringSplitOptions.RemoveEmptyEntries);
            n.NovelName = v2[0];
            var a = node.SelectSingleNode("//div[@class='mohe-summary']");
            var p = a.SelectNodes("p");
            n.Author = p[0].ChildNodes[1].InnerText.Trim();
            n.Style = p[1].ChildNodes[1].InnerText.Trim();
            n.State = p[2].ChildNodes[1].InnerText.Trim();
            n.NewChapter = p[4].SelectSingleNode("a").InnerText.Trim();

            var list = node.SelectSingleNode("table").SelectNodes("tr");
            foreach (var item in list)
            {
                var td = item.SelectNodes("td");
                if (td != null)
                {
                    foreach (var item1 in td)
                    {
                        if (item1.SelectSingleNode("a") != null)
                        {
                            n.ChapterList.Add(item1.SelectSingleNode("a").InnerText.Trim());
                            var addr = item1.SelectSingleNode("a").GetAttributeValue("href", "");
                            addr = "http://www.365if.com" + addr;
                            n.ChapterAddressList.Add(addr);
                        }
                    }
                }
            }
            return n;
        }

        protected override string[] AnalysisChapter(string chapter)
        {
            string[] cha = new string[] { "1","2"};

            var doc = new HtmlDocument();
            doc.LoadHtml(chapter);
            var node = doc.DocumentNode.SelectSingleNode("//div[@class='block_02']");
            cha[0] = node.SelectSingleNode("h1").InnerText;
            cha[1] = node.SelectSingleNode("div[@id='content']").InnerText;
            return cha;
        }
    }
}
