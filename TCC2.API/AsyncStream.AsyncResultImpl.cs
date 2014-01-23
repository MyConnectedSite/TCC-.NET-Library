#if PocketPC

using System;

namespace TCC2.API
{
    public partial class AsyncStream : StreamWrapper
    {
        class AsyncResultImpl : AsyncResult
        {
            public AsyncResultImpl(object owner, AsyncCallback callback, object state)
            {
                Owner = owner;
                Begin(callback, state);
            }

            protected override void Begin()
            {
            }

            public void Complete(bool asyncCompletion, Exception error)
            {
                CompletedSynchronously = asyncCompletion;
                Complete(error);
            }

            public void WaitForCompletion()
            {
                End();
            }

            public object Owner { get; private set; }

            public object CustomData { get; set; }
        }
    }
}

#endif