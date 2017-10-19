using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yungs.Novel.Source
{
  public  class NovelInfo
    {
        public NovelInfo()
        {
            chapterAddressList = new List<string>();
            chapterList = new List<string>();
        }
        private string novelName;
        /// <summary>
        /// 小说名字
        /// </summary>
        public string NovelName
        {
            get
            {
                return novelName;
            }

            set
            {
                novelName = value;
            }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }
        /// <summary>
        /// 类型。
        /// </summary>
        public string Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
            }
        }
        /// <summary>
        /// 状态，连载  完结
        /// </summary>
        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
        /// <summary>
        /// 最新章节
        /// </summary>
        public string NewChapter
        {
            get
            {
                return newChapter;
            }

            set
            {
                newChapter = value;
            }
        }
        /// <summary>
        /// 小说来源
        /// 来自哪个网站
        /// </summary>
        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }
        /// <summary>
        /// 小说章节目录列表
        /// </summary>
        public List<string> ChapterList
        {
            get
            {
                return chapterList;
            }

            set
            {
                chapterList = value;
            }
        }
        /// <summary>
        /// 小说章节地址列表
        /// </summary>
        public List<string> ChapterAddressList
        {
            get
            {
                return chapterAddressList;
            }

            set
            {
                chapterAddressList = value;
            }
        }

        public BaseSource downloadSource;

        private string author;
        private string style;
        private string state;
        private string newChapter;
        private string source;
        private List<string> chapterList;
        private List<string> chapterAddressList;
    }
}
