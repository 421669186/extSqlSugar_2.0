using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJ.Common.Log
{
    public static class ExecuteLog
    {
        private static string _logPath = AppDomain.CurrentDomain.BaseDirectory + "ExecuteLog";

        public static void WriteExecuteLog(DateTime startDate, DateTime endDate, string drgsName)
        {
            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
            string byteData = string.Format("单病种名称:{0}, 时间区间为:{1}--{2}, 抽取状态:成功!\r\n\r\n", drgsName, startDate, endDate);
            FileStream file = null;
            byte[] bytes = Encoding.UTF8.GetBytes(byteData);
            file = File.OpenWrite(_logPath + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".log");
            file.Position = file.Length;
            file.Write(bytes, 0, bytes.Length);
            file.Close();
        }

        //private static ConcurrentQueue<string> SecureQueue = SecureQueueFactory.GetConcurrentQueue<string>();
    }
}
