namespace Yungs.Novel
{
    public class GlobalData
    {
        public const int DefaultConnectionLimit = 1000;

        /// <summary>
        /// 当前下载线程数
        /// </summary>
        public static int currThreadCount = 0;

        public static ConfigData configData;
       
    }

    public class ConfigData
    {
        /// <summary>
        /// 下载一个文件时同时能开多少线程
        /// 抓取网页时的线程数量
        /// </summary>
        public int MaxThread = 50;

        /// <summary>
        /// 下载文件时，同时开多少线程
        /// 直接通过连接下载文件
        /// </summary>
        public int MaxSingleThread = 8;

        public NovelPath novelPath = new NovelPath ();
    }
}
