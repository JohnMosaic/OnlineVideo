using System;
using System.IO;

namespace OnlineVideo.Control
{
    public class ArgsChecker
    {
        public int CheckMaxLimit(string maxLimitStr)
        {
            try
            {
                return Convert.ToInt32(maxLimitStr);
            }
            catch
            {
                Console.WriteLine("[ERRO] The max-limit arg must be an integer type...");
                return 0;
            }
        }

        public int CheckMaxThreads(string maxThreadsStr)
        {
            try
            {
                return Convert.ToInt32(maxThreadsStr);
            }
            catch
            {
                Console.WriteLine("[ERRO] The download max-threads arg must be an integer type...");
                return 0;
            }
        }

        public int[] CheckIndexArray(string indexArrayStr)
        {
            int[] indexArray = { -1 };

            try
            {
                indexArrayStr = indexArrayStr.Replace("[", "").Replace("]", "");
                string[] indexStrArray = indexArrayStr.Split(',');
                int length = indexStrArray.Length;
                indexArray = new int[length];

                for (int i = 0; i < length; i++)
                {
                    indexArray[i] = Convert.ToInt32(indexStrArray[i]);
                }
            }
            catch
            {
                Console.WriteLine("[ERRO] The index array arg must be an integer array type...");
            }

            return indexArray;
        }

        public string CheckFilePath(int mode)
        {
            string filePath = Environment.CurrentDirectory + "\\ts_files_mode_" + mode.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            return filePath;
        }

        public bool CheckFile(string file, string type)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("[ERRO] The " + type + " file \"" + file + "\" does not exists...");
                return false;
            }

            return true;
        }
    }
}
