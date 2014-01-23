using System;

namespace TCC2.API
{
    public class ProgressEventArgs : EventArgs
    {
        public const float ProgressUndefined = -1.0f;

        public ProgressEventArgs(long total, long progress)
        {
            Total = total;
            Progress = progress;
        }

        public long Total { get; private set; }
        public long Progress { get; private set; }

        public float Percent
        {
            get
            {
                if (Total <= 0 || Total < Progress)
                    return ProgressUndefined;

                return (float)Progress / (float)Total * 100.0f;
            }
        }
    }
}