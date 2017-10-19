using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yungs.Novel.Follow;
using Yungs.Novel;

namespace Yungs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Net.ServicePointManager.DefaultConnectionLimit = GlobalData.DefaultConnectionLimit;
            n_si_rtb.Text = "";
            Initialize();
        }

        void Initialize()
        {
            DownloadNovelFollow();
        }

        void DownloadNovelFollow()
        {
            DownloadNovelFollow follow = new DownloadNovelFollow();
            follow.n_search_btn = n_search_btn;
            follow.n_norvalName_tbx = n_norvalName_tbx;
            follow.n_show_tlp = n_show_tlp;
            follow.n_si_rtb = n_si_rtb;
            follow.OnLoad();
        }
    }
}
