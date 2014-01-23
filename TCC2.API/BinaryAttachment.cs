using System;
using System.IO;

namespace TCC2.API
{
    public class BinaryAttachment : Stream
    {
        long m_Length;
        long m_BytesLeft;
        string m_FileName;
        Stream m_UnderlyingStream;

        public BinaryAttachment(Stream data, long length, string name)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (length < 0)
                throw new ArgumentOutOfRangeException("length");

            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Attachment name cannot be null or empty", "name");

#if PocketPC
            // most of the Stream class descendants in .NET CF has no async methods implementation
            m_UnderlyingStream = new AsyncStream(data);
#else
            m_UnderlyingStream = data;
#endif
            m_Length = length;
            m_BytesLeft = length;
            Name = name;
            FileName = name;
        }

        public string Name { get; private set; }

        public string FileName
        {
            get { return m_FileName; }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("File name cannot be null or empty", "value");

                m_FileName = value;
            }
        }

        public override long Length
        {
            get { return m_Length; }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override long Position
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            CheckBufferRange(buffer, offset, count);

            int bytesRead = m_UnderlyingStream.Read(buffer, offset, Math.Min((int)m_BytesLeft, count));
            m_BytesLeft -= bytesRead;

            return bytesRead;
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CheckBufferRange(buffer, offset, count);

            return m_UnderlyingStream.BeginRead(buffer, offset, Math.Min((int)m_BytesLeft, count), callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
                throw new ArgumentNullException("asyncResult");

            int bytesRead = m_UnderlyingStream.EndRead(asyncResult);
            m_BytesLeft -= bytesRead;

            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (m_UnderlyingStream != null)
                m_UnderlyingStream.Close();

            base.Dispose(disposing);
        }

        static void CheckBufferRange(byte[] buffer, int offset, int count)
        {
            if (offset > buffer.Length)
                throw new ArgumentOutOfRangeException("offset");

            if (buffer.Length < offset + count)
                throw new ArgumentOutOfRangeException("count");
        }
    }
}