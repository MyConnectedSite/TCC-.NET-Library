#if PocketPC

using System;
using System.IO;
using System.Threading;

namespace TCC2.API
{
    public partial class AsyncMemoryStream : MemoryStream
    {
        partial class AsyncResultImpl : IAsyncResult
        {
            public AsyncResultImpl(AsyncMemoryStream memoryStream, object state)
            {
                AsyncState = state;
            }

            public object AsyncState { get; private set; }

            public WaitHandle AsyncWaitHandle
            {
                get { return new FakeWaitHandle(); }
            }

            public bool CompletedSynchronously
            {
                get { return true; }
            }

            public bool IsCompleted
            {
                get { return true; }
            }
        }
    }
}

#endif