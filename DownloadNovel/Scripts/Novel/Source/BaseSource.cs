using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
namespace Yungs.Novel.Source
{
    public class BaseSource
    {
        /// <summary>
        /// 是否搜索到小说
        /// </summary>
        public bool Exist
        {
            get
            {
                return exist;
            }
            protected set
            {
                exist = value;
            }
        }
        /// <summary>
        /// 小说源
        /// </summary>
        public string novelSource = "";
        private bool exist = true;
        private string addr;

        protected string Addr
        {
            get
            {
                return addr;
            }

            set
            {
                addr = value;
            }
        }

        protected NovelInfo novelInfo;

        TaskFactory taskFactory = null;
        List<Task> downloadTask;
        #region UI事件

        /// <summary>
        /// 显示进度
        /// </summary>
        private event Action<string> doShowProgress;
        public void SetDoShowProgressEvent(Action<string> a)
        {
            doShowProgress = a;
        }
        private void RunDoShowProgressEvent(string s)
        {
            doShowProgress?.Invoke(s);
        }
        #endregion
        public NovelInfo Search(string novelName)
        {
            novelInfo = GetNorvalInfo(novelName);
            return novelInfo;
        }
        public void Download()
        {
            taskFactory = new TaskFactory();
            downloadTask = new List<Task>();
        }

        void DownloadChapters()
        {
            int currDownloadCount = 0;
            int max = novelInfo.ChapterAddressList.Count;
            int dur = GlobalData.configData.MaxThread;
            if (dur < max)
            {
                dur = (int)Math.Ceiling(novelInfo.ChapterAddressList.Count / (float)GlobalData.configData.MaxThread);
                for (int i = 0; i < dur - 1; i++)
                {
                    taskFactory.StartNew(()=>
                    {
                        var tmpName = GlobalData.configData.novelPath.TmpPath + "/" + novelInfo.NovelName + ".tmp" + i.ToString();
                        if (File.Exists(tmpName))
                        {
                            File.Delete(tmpName);
                        }
                        using (var fs = new FileStream(tmpName,FileMode.Create))
                        {
                            using (var sw = new StreamWriter(fs))
                            {
                                for (int j = dur * i; j < dur * (i + 1); j++)
                                {
                                    var cha = AnalysisChapter(novelInfo.ChapterAddressList[j]);
                                    sw.WriteLine("");
                                    sw.WriteLine("          " + cha[0]);
                                    sw.WriteLine("");
                                    sw.WriteLine(cha[1]);
                                    currDownloadCount++;
                                    RunDoShowProgressEvent(currDownloadCount.ToString() + "/" + max.ToString());
                                }
                            }
                        }
                    });
                }
            }
            else
            {
                for (int i = 0; i < dur; i++)
                {
                    taskFactory.StartNew(() =>
                    {
                        var tmpName = GlobalData.configData.novelPath.TmpPath + "/" + novelInfo.NovelName + ".tmp" + i.ToString();
                        if (File.Exists(tmpName))
                        {
                            File.Delete(tmpName);
                        }
                        using (var fs = new FileStream(tmpName, FileMode.Create))
                        {
                            using (var sw = new StreamWriter(fs))
                            {
                                for (int j = dur * i; j < dur * (i + 1); j++)
                                {
                                    var cha = AnalysisChapter(novelInfo.ChapterAddressList[j]);
                                    sw.WriteLine("");
                                    sw.WriteLine("          " + cha[0]);
                                    sw.WriteLine("");
                                    sw.WriteLine(cha[1]);
                                    currDownloadCount++;
                                    RunDoShowProgressEvent(currDownloadCount.ToString() + "/" + max.ToString());
                                }
                            }
                        }
                    });
                }
            }
            
            Task.WaitAll(downloadTask.ToArray());
        }

        string GetChapterContent(string url)
        {
            var wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            var data = wc.DownloadData(url);
            var con = Encoding.UTF8.GetString(data);
            wc.Dispose();
            return con;
        }
        protected virtual NovelInfo GetNorvalInfo(string novelName) { return new NovelInfo(); }
        /// <summary>
        /// 返回 章节名和章节内容
        /// </summary>
        /// <param name="chapter"></param>
        /// <returns></returns>
        protected virtual string[] AnalysisChapter(string chapter)
        {
            return new string[] { "" };
        }

        protected virtual string WebClientDownload(string uri,Encoding e)
        {
            bool sucess = false;
            string html = "";
            var wc = new WebClient();
            //wc.Credentials = 
            wc.Headers.Add("User", "Mozilla / 4.0(compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            while(!sucess)
            {
                try
                {
                    html = e.GetString(wc.DownloadData(uri));
                    sucess = true;
                }
                catch(Exception ex)
                {
                    sucess = false;
                }
                wc.Dispose();
            }
            return html;
        }
    }
}
