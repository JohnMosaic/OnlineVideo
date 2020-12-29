using OnlineVideo.Utils.Engine;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OnlineVideo.Utils.UnorderedTS
{
    public class Mode7Cycler
    {
        public void WorkCycle(string urlLeftPart, string m3u8File, string key, string filePath, int maxThreads, int mode)
        {
            Dictionary<int, string> urlDict = new M3u8Parser().GetURLArrayFromM3u8File(urlLeftPart, m3u8File, mode);
            int urlCount = urlDict.Count;

            if (urlCount > 0)
            {
                CoreWorker coreWorker = new CoreWorker();
                Console.WriteLine("[INFO] Mode " + mode.ToString() + " work start.");
                coreWorker.logManager.RecordLogInfo("INFO", "Mode " + mode.ToString() + " work start.", "Work cycle");
                int length = urlCount.ToString().Length;

                foreach (int index in urlDict.Keys)
                {
                    try
                    {
                        string indexStr = coreWorker.converter.IndexConverter(index, length);

                        if (indexStr != "ERRO")
                        {
                            string uri = urlDict[index];
                            string name = indexStr + ".ts";

                            while (true)
                            {
                                int count = coreWorker.threadCounter.Read();

                                if (count < maxThreads)
                                {
                                    coreWorker.threadCounter.Add();

                                    if (mode == 5)
                                    {
                                        Thread t = new Thread(() => coreWorker.DoWork(indexStr, name, uri, filePath, 5));
                                        t.Start();
                                    }
                                    else if (mode == 7)
                                    {
                                        string vector = uri.Substring(uri.LastIndexOf("/") + 1);
                                        Thread t = new Thread(() => coreWorker.DoWork(indexStr, name, uri, key, vector, filePath, 7));
                                        t.Start();
                                    }

                                    break;
                                }
                                else Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            Console.WriteLine("[ERRO] Mode " + mode.ToString() + " index " + index + " convert failed...");
                            coreWorker.logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " index " + index + " convert failed...", "Work cycle " + index);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[ERRO] Mode " + mode.ToString() + " cycle error: " + ex.Message + " index " + index + " work failed...");
                        coreWorker.logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " cycle error: " + ex.Message, "Work cycle " + index);
                    }
                }

                coreWorker.isCycleDone = true;
            }
            else Console.WriteLine("[WARN] Mode " + mode.ToString() + " found none *.ts file's url in the m3u8 file...");
        }
    }
}
