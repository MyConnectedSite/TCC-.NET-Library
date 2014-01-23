using System;
using System.Threading;

namespace TCC2.API
{
    public abstract class AsyncResult : IAsyncResult, IDisposable
    {
        AsyncCallback m_Callback;
        object m_State;
        bool m_IsCompleted;
        ManualResetEvent m_Event = new ManualResetEvent(false);
        Exception m_Error;
        AsyncCallback m_SafeCallback;
        int m_Ended;

        protected AsyncResult()
        {
            CompletedSynchronously = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected bool CompletedSynchronously { get; set; }

        protected AsyncCallback GetSafeCallback(AsyncCallback callback)
        {
            if (callback == null)
                return null;

            m_SafeCallback = callback;
            return SafeCallbackProc;
        }

        protected void Complete(Exception error)
        {
            if (m_IsCompleted)
                return;

            m_Error = error;
            OnComplete();
            m_IsCompleted = true;
            m_Event.Set();

            if (m_Callback != null)
                m_Callback(this);
        }

        protected virtual void OnComplete()
        {
        }

        protected void Begin(AsyncCallback callback, object state)
        {
            m_Callback = callback;
            m_State = state;
            Begin();
        }

        protected abstract void Begin();

        protected void End()
        {
            if (Interlocked.Exchange(ref m_Ended, 1) == 1)
                throw new InvalidOperationException("Asynchronous call already ended");

            m_Event.WaitOne();
            m_Event.Close();

            if (m_Error != null)
                throw m_Error;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                m_Event.Close();
        }

        void SafeCallbackProc(IAsyncResult state)
        {
            try
            {
                if (state != null)
                    CompletedSynchronously &= state.CompletedSynchronously;

                m_SafeCallback(state);
            }
            catch (Exception exception)
            {
                Complete(exception);
            }
        }

        object IAsyncResult.AsyncState
        {
            get { return m_State; }
        }

        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return m_Event; }
        }

        bool IAsyncResult.CompletedSynchronously
        {
            get { return CompletedSynchronously; }
        }

        bool IAsyncResult.IsCompleted
        {
            get { return m_IsCompleted; }
        }
    }
}