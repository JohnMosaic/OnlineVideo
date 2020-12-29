using OnlineVideo.Utils.Engine;
using System;
using System.Threading;

namespace OnlineVideo.Utils.OrderedTS
{
    public class Mode4Cycler
    {
        public void WorkCycle(string uri, int[] indexArray, string key, string filePath, int maxThreads, int mode)
        {
            CoreWorker coreWorker = new CoreWorker();
            Console.WriteLine("[INFO] Mode " + mode.ToString() + " work start.");
            coreWorker.logManager.RecordLogInfo("INFO", "Mode " + mode.ToString() + " work start.", "Work cycle");

            foreach (int index in indexArray)
            {
                int length = index.ToString().Length;

                try
                {
                    string indexStr = coreWorker.converter.IndexConverter(index, length);

                    if (indexStr != "ERRO")
                    {
                        string newURI = uri.Substring(0, uri.Length - length - 3) + indexStr + ".ts";

                        while (true)
                        {
                            int count = coreWorker.threadCounter.Read();

                            if (count < maxThreads)
                            {
                                coreWorker.threadCounter.Add();

                                if (mode == 2)
                                {
                                    Thread t = new Thread(() => coreWorker.DoWork(indexStr, "", newURI, filePath, 2));
                                    t.Start();
                                }
                                else if (mode == 4)
                                {
                                    string vector = newURI.Substring(newURI.LastIndexOf("/") + 1);
                                    Thread t = new Thread(() => coreWorker.DoWork(indexStr, "", newURI, key, vector, filePath, 4));
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
    }
}
