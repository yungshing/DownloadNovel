using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yungs.Novel.Source;
using System.Threading;
using System.Windows.Forms;
namespace Yungs.Novel.Follow
{
    public class DownloadNovelFollow : BaseFollow
    {
        public Button n_search_btn;
        public TextBox n_norvalName_tbx;
        public TableLayoutPanel n_show_tlp;
        public RichTextBox n_si_rtb;
        private string novelName = "";

        public override void OnLoad()
        {
            SetDoCreateTitleControl(CreateTitleControl);
            SetDoCreateControls(CreateControls);
            SetDoShowSearchInfo(ShowSearchInfo);
            Search();
        }
        /// <summary>
        /// 点击搜索按钮
        /// </summary>
        private void Search()
        {
            n_search_btn.Click += (d, z) =>
              {
                  if (n_norvalName_tbx.Text == null || n_norvalName_tbx.Text.Replace(" ","")=="")
                  {
                      return;
                  }
                  n_show_tlp.Controls.Clear();
                  novelName = n_norvalName_tbx.Text;
                  Thread t = new Thread(() =>
                  {
                      var v = GetNorvalInfoList();
                      RunDoCreateTitleControl();
                      foreach (var item in v)
                      {
                          ///显示每一个源的搜索结果
                          RunDoCreateControls(item);
                      }
                      RunDoShowSearchInfo("");
                  });
                  t.Start();
              };
        }
        /// <summary>
        /// 创建行
        /// </summary>
        /// <param name="t"></param>
        /// <param name="n"></param>
        void CreateControls(NovelInfo n)
        {
            if (n_show_tlp.InvokeRequired)
            {
                n_show_tlp.Invoke(new Action<NovelInfo>(CreateControls), n);
            }
            else
            {
                var t = n_show_tlp;
                n_show_tlp.RowCount++;
                for (int i = 0; i < 5; i++)
                {
                    Label l1 = new Label();
                    l1.BorderStyle = BorderStyle.FixedSingle;
                    t.Controls.Add(l1);
                    t.SetRow(l1, t.RowCount - 1);
                    t.SetColumn(l1, i);
                    l1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    l1.Margin = new Padding(0, 0, 0, 0);
                    switch (i)
                    {
                        case 0: l1.Text = n.NovelName; break;
                        case 1: l1.Text = n.Author; break;
                        case 2: l1.Text = n.NewChapter; break;
                        case 3: l1.Text = n.State; break;
                        case 4: l1.Text = n.Source; break;
                    }
                }
                Button b = new Button();
                b.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                b.Text = "下载";
                t.Controls.Add(b);
                t.SetRow(b, t.RowCount - 1);
                t.SetColumn(b, 5);
                SetDownloadBtnEvent(b, n);
            }
        }
        /// <summary>
        /// 创建标题
        /// </summary>
        /// <param name="t"></param>
       private void CreateTitleControl()
        {
            if (n_show_tlp.InvokeRequired)
            {
                n_show_tlp.Invoke(new Action(CreateTitleControl));
            }
            else
            {
                var t = n_show_tlp;
                for (int i = 0; i < 6; i++)
                {
                    Label l1 = new Label();
                    t.Controls.Add(l1);
                    t.SetRow(l1, 0);
                    t.SetColumn(l1, i);
                    l1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    switch (i)
                    {
                        case 0: l1.Text = "书名"; break;
                        case 1: l1.Text = "作者"; break;
                        case 2: l1.Text = "最新章节"; break;
                        case 3: l1.Text = "状态"; break;
                        case 4: l1.Text = "来源"; break;
                        case 5: l1.Text = "下载"; break;
                    }
                }
            }
        }
        /// <summary>
        /// 从不同的源获取小说信息
        /// </summary>
        /// <returns></returns>
        List<NovelInfo> GetNorvalInfoList()
        {
            List<NovelInfo> n = new List<Source.NovelInfo>();
            #region 小说源
            //MingYueZhongWen n1 = new Source.MingYueZhongWen();
            //var myz = n1.Search(novelName);
            //if (n1.Exist)
            //{
            //    n.Add(myz);
            //}
            AddNovelInfo(n, new MingYueZhongWen());
            #endregion
            return n;
        }
        void AddNovelInfo(List<NovelInfo> n,BaseSource bs)
        {
            RunDoShowSearchInfo(bs.novelSource);
            var m = bs.Search(novelName);
            if (bs.Exist)
            {
                m.downloadSource = bs;
                n.Add(m);
            }
        }
        void SetDownloadBtnEvent(Button b,NovelInfo n)
        {
            b.Click += (d, z) =>
              {
                  n.downloadSource.Download();
              };
        }

        #region UI Event
        private event Action doCreateTitleControl;
        private void SetDoCreateTitleControl(Action a)
        {
            doCreateTitleControl = a;
        }
        private void RunDoCreateTitleControl()
        {
            doCreateTitleControl?.Invoke();
        }


        private event Action<NovelInfo> doCreateControls;
        private void SetDoCreateControls(Action<NovelInfo> a)
        {
            doCreateControls = a;
        }
        private void RunDoCreateControls(NovelInfo n)
        {
            doCreateControls?.Invoke(n);
        }


        private event Action<string> doShowSearchInfo;
        private void SetDoShowSearchInfo(Action <string > a)
        {
            doShowSearchInfo = a;
        }
        private void RunDoShowSearchInfo(string s)
        {
            doShowSearchInfo?.Invoke(s);
        }
        private void ShowSearchInfo(string s)
        {
            if (n_si_rtb.InvokeRequired)
            {
                n_si_rtb.Invoke(new Action<string>(RunDoShowSearchInfo), s);
            }
            else
            {
                if (s=="")
                {
                    n_si_rtb.Text = "";
                    return;
                }
                n_si_rtb.Text = "正在从源: ";
                n_si_rtb.AppendText(s);
                n_si_rtb.SelectionStart = 6;
                n_si_rtb.SelectionLength = s.Length;
                n_si_rtb.SelectionColor = System.Drawing.Color.Red;
                n_si_rtb.AppendText("加载数据");
                n_si_rtb.SelectionStart = n_si_rtb.Text.Length - 4;
                n_si_rtb.SelectionLength = 4;
                n_si_rtb.SelectionColor = System.Drawing.Color.Black;



            }
        }
        #endregion
    }
}
