using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yungs.Novel
{
    public class NovelPath
    {
        /// <summary>
        /// 下载时的缓存路径
        /// </summary>
        public string TmpPath
        {
            get { return tmpPath; }
            set { tmpPath = value;  }
        }
        private string tmpPath = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "/Yungs";
    }
}
