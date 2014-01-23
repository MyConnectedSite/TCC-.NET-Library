using System;
using System.IO;

namespace TCC2.API
{
    internal class StreamReadNotifier : StreamNotifier
    {
        public int EndRead(IAsyncResult ar)
        {
            int bytesRead = SourceStream.EndRead(ar);
            m_BytesProceeded += bytesRead;

            if (bytesRead > 0 && m_ProgressChanged != null)
                m_ProgressChanged(null, new ProgressEventArgs(m_BytesToProceed, m_BytesProceeded));

            return bytesRead;
        }
    }
}