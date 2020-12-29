using System;
using System.Diagnostics;
using System.IO;

namespace OnlineVideo.Utils.Common
{
    public class FileOperator
    {
        public byte[] ReadFile2ByteArray(string fileName)
        {
            FileStream fs = null;
            BinaryReader br = null;
            byte[] bReadByte = new byte[0];

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                br = new BinaryReader(fs);
                br.BaseStream.Seek(0, SeekOrigin.Begin);
                bReadByte = br.ReadBytes((int)br.BaseStream.Length);
            }
            catch
            {
                bReadByte = null;
            }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }

            return bReadByte;
        }

        public bool WriteByteArray2File(byte[] bReadByte, string fullPathName)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(fullPathName, FileMode.OpenOrCreate);
                fs.Write(bReadByte, 0, bReadByte.Length);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (fs != null) fs.Close();
            }

            return true;
        }

        public void MergeFiles(string filePath, string name, int mode)
        {
            LogManager logManager = new LogManager();

            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("copy /b " + filePath + "\\*.ts " + filePath + "\\" + name + ".mp4&exit");
                p.StandardInput.AutoFlush = true;
                string strOuput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
                Console.WriteLine("[INFO] Mode " + mode.ToString() + " merge files done!");
                logManager.RecordLogInfo("INFO", "Mode " + mode.ToString() + " merge log:\r\n" + strOuput, "Merge files");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERRO] Mode " + mode.ToString() + " merge error: " + ex.Message + " Merge files failed...");
                logManager.RecordLogInfo("ERRO", "Mode " + mode.ToString() + " merge error: " + ex.Message, "Merge files");
            }
        }
    }
}
