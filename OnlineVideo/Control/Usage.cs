using System;

namespace OnlineVideo.Control
{
    public class Usage
    {
        public void ShowUsage()
        {
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download ordered online *.ts videos using mode -d and arguments below.                   |");
            Console.WriteLine("| [this app] [mode_1 <-d>] [url] [max-limit <int>] [download max-threads <int>]                 |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -d http(s)://www.test.com/videos/temp/xOAgLH9076000.ts 617 10           |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download specified online *.ts videos using mode -sd and arguments below.                |");
            Console.WriteLine("| [this app] [mode_2 <-sd>] [url] [index array <int[]>] [download max-threads <int>]            |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -sd http(s)://tmp.com/videos/xOAgLH9076000.ts [13,23,44,139,...] 10     |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download ordered AES encrypted online *.ts videos using mode -ad and arguments below.    |");
            Console.WriteLine("| [this app] [mode_3 <-ad>] [url] [max-limit <int>] [AES key] [download max-threads <int>]      |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -ad http(s)://www.test.com/xOAgLH9076000.ts 864 912342018ea9a9ca 10     |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download specified AES encrypted online *.ts videos using mode -sad and arguments below. |");
            Console.WriteLine("| [this app] [mode_4 <-sad>] [url] [index array <int[]>] [AES key] [download max-threads <int>] |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -sad http(s)://tmp.com/xOAgLH9076000.ts [13,23,...] 912342018ea9a9ca 10 |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download unordered online *.ts videos using mode -u and arguments below.                 |");
            Console.WriteLine("| [this app] [mode_5 <-u>] [url left part] [m3u8 file] [download max-threads <int>]             |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -u http(s)://www.test.com/hls/ D:\\Downloads\\index.m3u8 10               |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download specified online *.ts videos using mode -su and arguments below.                |");
            Console.WriteLine("| [this app] [mode_6 <-su>] [log file] [download max-threads <int>]                             |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -su D:\\Downloads\\crawler\\OnlineVideo.log 10                             |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download unordered AES encrypted online *.ts videos using mode -au and arguments below.  |");
            Console.WriteLine("| [this app] [mode_7 <-au>] [url left part] [m3u8 file] [AES key] [download max-threads <int>]  |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -au http(s)://www.test.com/ D:\\Downloads\\index.m3u8 912342018ea9a9ca 10 |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| >->> Download specified AES encrypted online *.ts videos using mode -sau and arguments below. |");
            Console.WriteLine("| [this app] [mode_8 <-sau>] [log file] [AES key] [download max-threads <int>]                  |");
            Console.WriteLine("| e.g.: OnlineVideo.exe -sau D:\\Downloads\\crawler\\OnlineVideo.log 912342018ea9a9ca 10           |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");
        }
    }
}
