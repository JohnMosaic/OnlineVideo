namespace OnlineVideo.Utils.OrderedTS
{
    public class Mode1Cycler
    {
        public void WorkCycle(string uri, int maxLimit, string filePath, int maxThreads)
        {
            new Mode3Cycler().WorkCycle(uri, maxLimit, "", filePath, maxThreads, 1);
        }
    }
}
