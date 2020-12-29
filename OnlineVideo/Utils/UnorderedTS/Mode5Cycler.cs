namespace OnlineVideo.Utils.UnorderedTS
{
    public class Mode5Cycler
    {
        public void WorkCycle(string urlLeftPart, string m3u8File, string filePath, int maxThreads)
        {
            new Mode7Cycler().WorkCycle(urlLeftPart, m3u8File, "", filePath, maxThreads, 5);
        }
    }
}
