using System;
using System.IO;

namespace TCC2.API
{
    internal class StreamWriteNotifier : StreamNotifier
    {
        int m_BytesToWrite;

        public IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            m_BytesToWrite = count;
            return SourceStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public void EndWrite(IAsyncResult ar)
        {
            SourceStream.EndWrite(ar);
            m_BytesProceeded += m_BytesToWrite;

            if (m_BytesToWrite > 0 && m_ProgressChanged != null)
                m_ProgressChanged(null, new ProgressEventArgs(m_BytesToProceed, m_BytesProceeded));
        }
    }
}