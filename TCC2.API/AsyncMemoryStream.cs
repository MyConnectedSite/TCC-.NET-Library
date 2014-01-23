#if PocketPC

using System;
using System.IO;

namespace TCC2.API
{
    public partial class AsyncMemoryStream : MemoryStream
    {
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            int bytesRead = Read(buffer, offset, count);
            AsyncResultReadImpl result = new AsyncResultReadImpl(this, state, bytesRead);
            if (callback != null) callback(result);
            return result;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            Write(buffer, offset, count);
            AsyncResultImpl result = new AsyncResultImpl(this, state);
            if (callback != null) callback(result);
            return result;
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            AsyncResultReadImpl result = asyncResult as AsyncResultReadImpl;

            if (result == null)
                throw new ArgumentException("Invalid argument type", "asyncResult");

            return result.BytesRead;
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            AsyncResultImpl result = asyncResult as AsyncResultImpl;

            if (result == null)
                throw new ArgumentException("Invalid argument type", "asyncResult");
        }
    }
}

#endif