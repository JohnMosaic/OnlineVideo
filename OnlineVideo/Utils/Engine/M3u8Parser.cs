using OnlineVideo.Utils.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineVideo.Utils.Engine
{
    public class M3u8Parser
    {
        public Dictionary<int, string> GetURLArrayFromM3u8File(string urlLeftPart, string m3u8File, int mode)
        {
            LogManager logManager = new LogManager();
            FileStream fs = new FileStream(m3u8File, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            Dictionary<int, string> urlDict = new Dictionary<int, string>();

            try
            {
                Console.WriteLine("[INFO] Mode " + mode.ToString() + " is parsing m3u8 file.");
                string s = string.Empty;
                int sn = 0;

                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains(".ts")) urlDict.Add(sn++, urlLeftPart + s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERRO] Mode " + mode.ToString() + " parse error: " + ex.Message + " Parse m3u8 file failed...");
                logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " parse error: " + ex.Message, "Parse m3u8 file");
            }
            finally
            {
                if (sr != null) { sr.Close(); }
                if (fs != null) { fs.Close(); }
            }

            return urlDict;
        }

        public Dictionary<string, string> GetURLArrayFromLogFile(string logFile, int mode)
        {
            LogManager logManager = new LogManager();
            FileStream fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            Dictionary<string, string> urlDict = new Dictionary<string, string>();

            try
            {
                Console.WriteLine("[INFO] Mode " + mode.ToString() + " is parsing log file.");
                string s = string.Empty;

                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains("#") && s.Contains(">") && s.Contains(".ts"))
                    {
                        string tmp = s.Remove(0, s.IndexOf("#") + 1);
                        string indexStr = tmp.Substring(0, tmp.IndexOf(">"));
                        string uri = tmp.Substring(tmp.IndexOf(">") + 1, tmp.IndexOf(".ts") - tmp.IndexOf(">") + 2);

                        if (!urlDict.ContainsKey(indexStr)) urlDict.Add(indexStr, uri);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERRO] Mode " + mode.ToString() + " parse error: " + ex.Message + " Parse log file failed...");
                logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " parse error: " + ex.Message, "Parse log file");
            }
            finally
            {
                if (sr != null) { sr.Close(); }
                if (fs != null) { fs.Close(); }
            }

            return urlDict;
        }
    }
}
