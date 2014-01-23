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
            class FakeWaitHandle : WaitHandle
            {
                public override IntPtr Handle
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                    set
                    {
                        throw new NotImplementedException();
                    }
                }

                public override bool WaitOne()
                {
                    return true;
                }

                public override bool WaitOne(int millisecondsTimeout, bool exitContext)
                {
                    return true;
                }
            }
        }
    }
}

#endif