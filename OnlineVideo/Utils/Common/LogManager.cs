using System;
using System.IO;
using System.Text;

namespace OnlineVideo.Utils.Common
{
    public class LogManager
    {
        private readonly string logDir = Environment.CurrentDirectory + "\\log\\";

        private void CreateLogDirectory()
        {
            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
        }

        public void RecordLogInfo(string logType, string logInfo, string logMark)
        {
            CreateLogDirectory();
            DateTime dt = DateTime.Now;
            string logFileName = logDir + dt.ToString("yyyy_MM") + "_OnlineVideo.log";
            FileStream fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            StringBuilder sb = new StringBuilder();
            sb.Append(dt.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
            sb.Append("[").Append(logType).Append("] ").Append(logInfo);
            sb.Append(" --> ").Append(logMark).Append("\r\n\r\n");
            sw.Write(sb.ToString());
            sw.Close();
            fs.Close();
        }
    }
}
