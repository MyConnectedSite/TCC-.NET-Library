#if PocketPC

using System;
using System.IO;

namespace TCC2.API
{
    public partial class AsyncMemoryStream : MemoryStream
    {
        class AsyncResultReadImpl : AsyncResultImpl
        {
            public AsyncResultReadImpl(AsyncMemoryStream memoryStream, object state, int bytesRead)
                : base(memoryStream, state)
            {
                BytesRead = bytesRead;
            }

            public int BytesRead { get; private set; }
        }
    }
}

#endif