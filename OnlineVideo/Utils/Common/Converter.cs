namespace OnlineVideo.Utils.Common
{
    public class Converter
    {
        public string IndexConverter(int index, int length)
        {
            string ret;

            switch (length)
            {
                case 1:
                    if (index >= 0 && index < 10) ret = index.ToString();
                    else ret = "ERRO";
                    break;
                case 2:
                    if (index >= 0 && index < 10) ret = "0" + index.ToString();
                    else if (index >= 10 && index < 100) ret = index.ToString();
                    else ret = "ERRO";
                    break;
                case 3:
                    if (index >= 0 && index < 10) ret = "00" + index.ToString();
                    else if (index >= 10 && index < 100) ret = "0" + index.ToString();
                    else if (index >= 100 && index < 1000) ret = index.ToString();
                    else ret = "ERRO";
                    break;
                case 4:
                    if (index >= 0 && index < 10) ret = "000" + index.ToString();
                    else if (index >= 10 && index < 100) ret = "00" + index.ToString();
                    else if (index >= 100 && index < 1000) ret = "0" + index.ToString();
                    else if (index >= 1000 && index < 10000) ret = index.ToString();
                    else ret = "ERRO";
                    break;
                case 5:
                    if (index >= 0 && index < 10) ret = "0000" + index.ToString();
                    else if (index >= 10 && index < 100) ret = "000" + index.ToString();
                    else if (index >= 100 && index < 1000) ret = "00" + index.ToString();
                    else if (index >= 1000 && index < 10000) ret = "0" + index.ToString();
                    else if (index >= 10000 && index < 100000) ret = index.ToString();
                    else ret = "ERRO";
                    break;
                case 6:
                    if (index >= 0 && index < 10) ret = "00000" + index.ToString();
                    else if (index >= 10 && index < 100) ret = "0000" + index.ToString();
                    else if (index >= 100 && index < 1000) ret = "000" + index.ToString();
                    else if (index >= 1000 && index < 10000) ret = "00" + index.ToString();
                    else if (index >= 10000 && index < 100000) ret = "0" + index.ToString();
                    else if (index >= 100000 && index < 1000000) ret = index.ToString();
                    else ret = "ERRO";
                    break;
                default:
                    ret = "ERRO";
                    break;
            }

            return ret;
        }
    }
}
