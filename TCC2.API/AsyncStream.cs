#if PocketPC

using System;
using System.IO;
using System.Threading;

namespace TCC2.API
{
    public partial class AsyncStream : StreamWrapper
    {
        AsyncResultImpl ValidateAsyncResult(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
                throw new ArgumentNullException();

            AsyncResultImpl ar = asyncResult as AsyncResultImpl;
            if (ar == null)
                throw new ArgumentException("Invalid argument type", "asyncResult");

            if (ar.Owner != this)
                throw new ArgumentException("Attempt to end different async operation");

            return ar;
        }

        public AsyncStream(Stream baseStream)
            : base(baseStream)
        {
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            AsyncResultImpl ar = new AsyncResultImpl(this, callback, state);

            ThreadPool.QueueUserWorkItem(obj =>
                {
                    AsyncResultImpl asyncResult = obj as AsyncResultImpl;
                    try
                    {
                        asyncResult.CustomData = Read(buffer, offset, count);
                    }
                    catch (Exception e)
                    {
                        asyncResult.Complete(false, e);
                    }
                    asyncResult.Complete(false, null);
                }, ar);

            return ar;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            AsyncResultImpl ar = new AsyncResultImpl(this, callback, state);

            ThreadPool.QueueUserWorkItem(obj =>
                {
                    AsyncResultImpl asyncResult = obj as AsyncResultImpl;
                    try
                    {
                        Write(buffer, offset, count);
                    }
                    catch (Exception e)
                    {
                        asyncResult.Complete(false, e);
                    }
                    asyncResult.Complete(false, null);
                }, ar);

            return ar;
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            AsyncResultImpl ar = ValidateAsyncResult(asyncResult);
            ar.WaitForCompletion();
            return (int)ar.CustomData;
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            AsyncResultImpl ar = ValidateAsyncResult(asyncResult);
            ar.WaitForCompletion();
        }
    }
}

#endif