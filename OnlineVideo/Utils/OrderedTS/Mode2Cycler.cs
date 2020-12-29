namespace OnlineVideo.Utils.OrderedTS
{
    public class Mode2Cycler
    {
        public void WorkCycle(string uri, int[] indexArray, string filePath, int maxThreads)
        {
            new Mode4Cycler().WorkCycle(uri, indexArray, "", filePath, maxThreads, 2);
        }
    }
}
