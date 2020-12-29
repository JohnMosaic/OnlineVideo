using System.Net;

namespace OnlineVideo.Utils.Common
{
    public class Networker
    {
        public byte[] DownloadFile2ByteArray(string uri)
        {
            byte[] bNetworkData = null;
            int i = 0;

            while (i < 10)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        bNetworkData = client.DownloadData(uri);
                    }

                    if (bNetworkData != null) break;
                    else i++;
                }
                catch
                {
                    bNetworkData = null;
                    i++;
                }
            }

            return bNetworkData;
        }
    }
}
