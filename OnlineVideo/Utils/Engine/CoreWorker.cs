using OnlineVideo.Utils.Common;
using System;

namespace OnlineVideo.Utils.Engine
{
    public class CoreWorker
    {
        private readonly AESHelper aesHelper = new AESHelper();
        private readonly Networker networker = new Networker();
        private readonly FileOperator fileOperator = new FileOperator();

        public readonly Converter converter = new Converter();
        public readonly LogManager logManager = new LogManager();
        public readonly ThreadCounter threadCounter = new ThreadCounter(0);

        private bool isErrorOccurred = false;
        public bool isCycleDone = false;

        public void DoWork(string indexStr, string name, string uri, string filePath, int mode)
        {
            try
            {
                byte[] bNetworkData = networker.DownloadFile2ByteArray(uri);

                if (bNetworkData != null) WriteFile(indexStr, name, uri, filePath, bNetworkData, mode);
                else DownloadFailed(indexStr, uri, mode);
            }
            finally
            {
                WorkDone(uri, filePath, mode);
            }
        }

        public void DoWork(string indexStr, string name, string uri, string key, string vector, string filePath, int mode)
        {
            try
            {
                byte[] bNetworkData = networker.DownloadFile2ByteArray(uri);

                if (bNetworkData != null)
                {
                    byte[] bOriginalData = aesHelper.AESDecrypt(bNetworkData, key, vector);

                    if (bOriginalData != null) WriteFile(indexStr, name, uri, filePath, bOriginalData, mode);
                    else DecryptFailed(indexStr, uri, mode);
                }
                else DownloadFailed(indexStr, uri, mode);
            }
            finally
            {
                WorkDone(uri, filePath, mode);
            }
        }

        private void WriteFile(string indexStr, string name, string uri, string filePath, byte[] bData, int mode)
        {
            if (mode == 1 || mode == 2 || mode == 3 || mode == 4) name = uri.Substring(uri.LastIndexOf("/") + 1);

            string fullPathName = filePath + "\\" + name;

            if (!fileOperator.WriteByteArray2File(bData, fullPathName)) WriteFailed(indexStr, uri, mode);
        }

        private void WriteFailed(string indexStr, string uri, int mode)
        {
            isErrorOccurred = true;
            Console.WriteLine("[ERRO] Mode " + mode.ToString() + " write byte array to file failed... #" + indexStr + ">" + uri);
            logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " write byte array to file failed...", "#" + indexStr + ">" + uri);
        }

        private void DecryptFailed(string indexStr, string uri, int mode)
        {
            isErrorOccurred = true;
            Console.WriteLine("[ERRO] Mode " + mode.ToString() + " AES decrypt byte array failed... #" + indexStr + ">" + uri);
            logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " AES decrypt byte array failed...", "#" + indexStr + ">" + uri);
        }

        private void DownloadFailed(string indexStr, string uri, int mode)
        {
            isErrorOccurred = true;
            Console.WriteLine("[ERRO] Mode " + mode.ToString() + " download file to byte array failed... #" + indexStr + ">" + uri);
            logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " download file to byte array failed...", "#" + indexStr + ">" + uri);
        }

        private void WorkDone(string uri, string filePath, int mode)
        {
            int count = threadCounter.Minus();

            if (count == 0 && isCycleDone)
            {
                if ((mode == 1 || mode == 3 || mode == 5 || mode == 7) && !isErrorOccurred)
                {
                    Console.WriteLine("[INFO] Mode " + mode.ToString() + " download files done!");
                    logManager.RecordLogInfo("INFO", "Mode " + mode.ToString() + " download files done!", "Download files");
                    string fileName = uri.Substring(uri.LastIndexOf("/") + 1);
                    fileName = fileName.Substring(0, fileName.Length - 3);
                    fileOperator.MergeFiles(filePath, fileName, mode);
                }
                else
                {
                    Console.WriteLine("[INFO] Mode " + mode.ToString() + " download files done partly!");
                    logManager.RecordLogInfo("INFO", "Mode " + mode.ToString() + " download files done partly!", "Download files");
                }
            }
        }
    }
}
