using System;

namespace OnlineVideo.Utils.Engine
{
    public class ThreadCounter
    {
        private readonly Object thisLock = new Object();
        int threadNumber = 0;

        public ThreadCounter(int num)
        {
            threadNumber = num;
        }

        public int Read()
        {
            lock (thisLock)
            {
                return threadNumber;
            }
        }

        public void Add()
        {
            lock (thisLock)
            {
                threadNumber++;
            }
        }

        public int Minus()
        {
            lock (thisLock)
            {
                threadNumber--;

                if (threadNumber <= 0) return 0;

                return threadNumber;
            }
        }
    }
}
