namespace OnlineVideo.Utils.UnorderedTS
{
    public class Mode6Cycler
    {
        public void WorkCycle(string logFile, string filePath, int maxThreads)
        {
            new Mode8Cycler().WorkCycle(logFile, "", filePath, maxThreads, 6);
        }
    }
}
