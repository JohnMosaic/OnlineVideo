using OnlineVideo.Utils.Engine;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OnlineVideo.Utils.UnorderedTS
{
    public class Mode8Cycler
    {
        public void WorkCycle(string logFile, string key, string filePath, int maxThreads, int mode)
        {
            Dictionary<string, string> urlDict = new M3u8Parser().GetURLArrayFromLogFile(logFile, mode);
            int urlCount = urlDict.Count;

            if (urlCount > 0)
            {
                CoreWorker coreWorker = new CoreWorker();
                Console.WriteLine("[INFO] Mode " + mode.ToString() + " work start.");
                coreWorker.logManager.RecordLogInfo("INFO", "Mode " + mode.ToString() + " work start.", "Work cycle");

                foreach (string indexStr in urlDict.Keys)
                {
                    try
                    {
                        string uri = urlDict[indexStr];
                        string name = indexStr + ".ts";

                        while (true)
                        {
                            int count = coreWorker.threadCounter.Read();

                            if (count < maxThreads)
                            {
                                coreWorker.threadCounter.Add();

                                if (mode == 6)
                                {
                                    Thread t = new Thread(() => coreWorker.DoWork(indexStr, name, uri, filePath, 6));
                                    t.Start();
                                }
                                else if (mode == 8)
                                {
                                    string vector = uri.Substring(uri.LastIndexOf("/") + 1);
                                    Thread t = new Thread(() => coreWorker.DoWork(indexStr, name, uri, key, vector, filePath, 8));
                                    t.Start();
                                }

                                break;
                            }
                            else Thread.Sleep(500);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[ERRO] Mode " + mode.ToString() + " cycle error: " + ex.Message + " index " + indexStr + " work failed...");
                        coreWorker.logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " cycle error: " + ex.Message, "Work cycle " + indexStr);
                    }
                }

                coreWorker.isCycleDone = true;
            }
            else Console.WriteLine("[WARN] Mode " + mode.ToString() + " found none *.ts file's url in the log file...");
        }
    }
}
