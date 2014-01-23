#if PocketPC

using System;
using System.IO;

namespace TCC2.API
{
    public class StreamWrapper : Stream
    {
        protected readonly Stream m_BaseStream;

        public StreamWrapper(Stream baseStream)
        {
            if (baseStream == null)
                throw new ArgumentNullException();

            m_BaseStream = baseStream;
        }

        public override bool CanRead
        {
            get { return m_BaseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return m_BaseStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return m_BaseStream.CanWrite; }
        }

        public override void Flush()
        {
            m_BaseStream.Flush();
        }

        public override long Length
        {
            get { return m_BaseStream.Length; }
        }

        public override long Position
        {
            get { return m_BaseStream.Position; }
            set { m_BaseStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return m_BaseStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return m_BaseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            m_BaseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            m_BaseStream.Write(buffer, offset, count);
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return m_BaseStream.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return m_BaseStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public override bool CanTimeout
        {
            get { return m_BaseStream.CanTimeout; }
        }

        public override void Close()
        {
            m_BaseStream.Close();
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return m_BaseStream.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            m_BaseStream.EndWrite(asyncResult);
        }

        public override int ReadByte()
        {
            return m_BaseStream.ReadByte();
        }

        public override void WriteByte(byte value)
        {
            m_BaseStream.WriteByte(value);
        }

        public override int ReadTimeout
        {
            get { return m_BaseStream.ReadTimeout; }
            set { m_BaseStream.ReadTimeout = value; }
        }

        public override int WriteTimeout
        {
            get { return m_BaseStream.WriteTimeout; }
            set { m_BaseStream.WriteTimeout = value; }
        }
    }
}

#endif