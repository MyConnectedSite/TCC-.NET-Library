using System;
using System.IO;

namespace TCC2.API
{
    internal class StreamNotifier
    {
        protected long m_BytesToProceed;
        protected long m_BytesProceeded;
        protected EventHandler<ProgressEventArgs> m_ProgressChanged;
    
        public const long MaxProgressIsUndefined = -1L;

        public event EventHandler<ProgressEventArgs> ProgressChanged
        {
            add { m_ProgressChanged += value; }
            remove { m_ProgressChanged -= value; }
        }

        public Stream SourceStream { get; set; }

        public long BytesToProceed
        {
            get { return m_BytesToProceed; }

            set
            {
                if (value < 0)
                    value = MaxProgressIsUndefined;

                m_BytesToProceed = value;
            }
        }

        public void Close()
        {
            if (SourceStream != null)
                SourceStream.Close();
        }
    }
}