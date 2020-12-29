using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OnlineVideo.Utils.Common
{
    public class AESHelper
    {
        public byte[] AESEncrypt(byte[] bOriginalData, string key, string vector)
        {
            byte[] bKey = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(vector.PadRight(bVector.Length)), bVector, bVector.Length);
            byte[] bEncryptData = null;
            Rijndael aes = Rijndael.Create();

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream encryptor = new CryptoStream(memoryStream, aes.CreateEncryptor(bKey, bVector), CryptoStreamMode.Write))
                    {
                        encryptor.Write(bOriginalData, 0, bOriginalData.Length);
                        encryptor.FlushFinalBlock();
                        bEncryptData = memoryStream.ToArray();
                    }
                }
            }
            catch
            {
                bEncryptData = null;
            }

            return bEncryptData;
        }

        public byte[] AESDecrypt(byte[] bEncryptData, string key, string vector)
        {
            byte[] bKey = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(vector.PadRight(bVector.Length)), bVector, bVector.Length);
            byte[] bOriginalData = null;
            Rijndael aes = Rijndael.Create();

            try
            {
                using (MemoryStream memoryStream = new MemoryStream(bEncryptData))
                {
                    using (CryptoStream decryptor = new CryptoStream(memoryStream, aes.CreateDecryptor(bKey, bVector), CryptoStreamMode.Read))
                    {
                        using (MemoryStream originalMemory = new MemoryStream())
                        {
                            byte[] bBuffer = new byte[1024];
                            int readBytes = 0;

                            while ((readBytes = decryptor.Read(bBuffer, 0, bBuffer.Length)) > 0)
                            {
                                originalMemory.Write(bBuffer, 0, readBytes);
                            }

                            bOriginalData = originalMemory.ToArray();
                        }
                    }
                }
            }
            catch
            {
                bOriginalData = null;
            }

            return bOriginalData;
        }
    }
}
