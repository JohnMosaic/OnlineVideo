using OnlineVideo.Utils.OrderedTS;
using OnlineVideo.Utils.UnorderedTS;

namespace OnlineVideo.Control
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            ArgsChecker argsChecker = new ArgsChecker();
            Usage usage = new Usage();
            int argsLen = args.Length;

            if (argsLen == 3)
            {
                string mode = args[0];

                if (mode == "-su")
                {
                    string logFile = args[1];
                    bool b = argsChecker.CheckFile(logFile, "log");

                    if (b)
                    {
                        int maxThreads = argsChecker.CheckMaxThreads(args[2]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(6);
                            new Mode6Cycler().WorkCycle(logFile, filePath, maxThreads);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else usage.ShowUsage();
            }
            else if (argsLen == 4)
            {
                string mode = args[0];

                if (mode == "-d")
                {
                    string uri = args[1];
                    int maxLimit = argsChecker.CheckMaxLimit(args[2]);

                    if (maxLimit != 0)
                    {
                        int maxThreads = argsChecker.CheckMaxThreads(args[3]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(1);
                            new Mode1Cycler().WorkCycle(uri, maxLimit, filePath, maxThreads);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else if (mode == "-sd")
                {
                    string uri = args[1];
                    int[] indexArray = argsChecker.CheckIndexArray(args[2]);

                    if (indexArray[0] != -1)
                    {
                        int maxThreads = argsChecker.CheckMaxThreads(args[3]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(2);
                            new Mode2Cycler().WorkCycle(uri, indexArray, filePath, maxThreads);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else if (mode == "-u")
                {
                    string uri = args[1];
                    string m3u8File = args[2];
                    bool b = argsChecker.CheckFile(m3u8File, "m3u8");

                    if (b)
                    {
                        int maxThreads = argsChecker.CheckMaxThreads(args[3]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(5);
                            new Mode5Cycler().WorkCycle(uri, m3u8File, filePath, maxThreads);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else if (mode == "-sau")
                {
                    string logFile = args[1];
                    bool b = argsChecker.CheckFile(logFile, "log");

                    if (b)
                    {
                        string key = args[2];
                        int maxThreads = argsChecker.CheckMaxThreads(args[3]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(8);
                            new Mode8Cycler().WorkCycle(logFile, key, filePath, maxThreads, 8);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else usage.ShowUsage();
            }
            else if (argsLen == 5)
            {
                string mode = args[0];
                string uri = args[1];

                if (mode == "-ad")
                {
                    int maxLimit = argsChecker.CheckMaxLimit(args[2]);

                    if (maxLimit != 0)
                    {
                        string key = args[3];
                        int maxThreads = argsChecker.CheckMaxThreads(args[4]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(3);
                            new Mode3Cycler().WorkCycle(uri, maxLimit, key, filePath, maxThreads, 3);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else if (mode == "-sad")
                {
                    int[] indexArray = argsChecker.CheckIndexArray(args[2]);

                    if (indexArray[0] != -1)
                    {
                        string key = args[3];
                        int maxThreads = argsChecker.CheckMaxThreads(args[4]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(4);
                            new Mode4Cycler().WorkCycle(uri, indexArray, key, filePath, maxThreads, 4);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else if (mode == "-au")
                {
                    string m3u8File = args[2];
                    bool b = argsChecker.CheckFile(m3u8File, "m3u8");

                    if (b)
                    {
                        string key = args[3];
                        int maxThreads = argsChecker.CheckMaxThreads(args[4]);

                        if (maxThreads != 0)
                        {
                            string filePath = argsChecker.CheckFilePath(7);
                            new Mode7Cycler().WorkCycle(uri, m3u8File, key, filePath, maxThreads, 7);
                        }
                        else usage.ShowUsage();
                    }
                    else usage.ShowUsage();
                }
                else usage.ShowUsage();
            }
            else usage.ShowUsage();
        }
    }
}
