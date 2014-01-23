using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading;

namespace TCC2.API
{
    public sealed partial class Session
    {
        abstract class Request : AsyncResult, IRequest
        {
            protected internal IRequestDataProvider m_DataProvider;
            protected internal Session m_Session;
            protected internal HttpWebRequest m_WebRequest;
            IResponse m_Response;
            int? m_Timeout;

            void SetSessionDependentRequestSettings()
            {
                string cookies = m_Session.GetCookies();
                if (!String.IsNullOrEmpty(cookies))
                    m_WebRequest.Headers["Cookie"] = cookies;

                IWebProxy proxy = m_Session.Proxy;
                if (proxy != null)
                    m_WebRequest.Proxy = proxy;

                m_WebRequest.Headers.Add("Cache-Control", "no-cache");
            }

            void RegisterWaitForTimeout(WaitHandle waitHandle, int timeout)
            {
#if !PocketPC
                ThreadPool.RegisterWaitForSingleObject(waitHandle, (state, timedOut) =>
                    {
                        if (timedOut)
                            Abort();
                    }, null, timeout, true);
#else
                if (!waitHandle.WaitOne(0, false))
                {
                    ThreadPool.QueueUserWorkItem((state) =>
                        {
                            if (!waitHandle.WaitOne(timeout, false))
                                Abort();
                        });
                }
#endif
            }

            protected internal void RequestSent(IAsyncResult state)
            {
                try
                {
                    m_Response = new Response((HttpWebResponse)m_WebRequest.EndGetResponse(state), false);
                }
                catch (WebException exception)
                {
                    HttpWebResponse response = exception.Response as HttpWebResponse;

                    // process only HTTP 500 errors
                    if (response != null && response.StatusCode == HttpStatusCode.InternalServerError)
                        m_Response = new Response(response, true);
                    else
                        throw;
                }

                Complete(null);
            }

            protected internal abstract HttpWebRequest CreateWebRequest();

            protected Request(Session session)
            {
                if (session == null)
                    throw new ArgumentNullException("session");

                m_Session = session;
            }

            public void BeginGetResponse(AsyncCallback callback, object state)
            {
                m_WebRequest = CreateWebRequest();
                SetSessionDependentRequestSettings();

                int timeout = m_Timeout ?? m_Session.Timeout;
                //Previously RegisterWaitForTimeout was called after Begin(..)
                //But after last reorganization of work with async operations fo .NET CF
                //we should call it _before_ Begin(..), because in case of errors (e.g. wrong server url) 
                //Begin finishes (and releases AsyncWaitHandle) earlier than RegisterWaitForTimeout is called (at least
                //earlier than thread starts)
                if (timeout > -2)
                    RegisterWaitForTimeout(((IAsyncResult)this).AsyncWaitHandle, timeout);

                Begin(callback, state);
            }

            public IResponse EndGetResponse()
            {
                End();
                return m_Response;
            }

            public void SetDataProvider(IRequestDataProvider dataProvider)
            {
                if (dataProvider == null)
                    throw new ArgumentNullException("dataProvider");

                m_DataProvider = dataProvider;
            }

            public void Abort()
            {
                if (m_WebRequest != null)
                    m_WebRequest.Abort();
            }

            public int Timeout
            {
                get { return m_Timeout ?? m_Session.Timeout; }

                set
                {
                    if (value < -1)
                        throw new ArgumentOutOfRangeException("value", "Timeout must be greater than or equal to -1");

                    m_Timeout = value;
                }
            }

            public virtual event EventHandler<ProgressEventArgs> UploadProgressChanged
            {
                add { throw new NotImplementedException(); }
                remove { throw new NotImplementedException(); }
            }

            public static string EncodeUrlParameters(IEnumerable<ApiParameter> parameters)
            {
                StringBuilder result = new StringBuilder();

                bool first = true;
                foreach (ApiParameter parameter in parameters)
                {
                    if (first)
                        first = false;
                    else
                        result.Append('&');

                    result.Append(Uri.EscapeDataString(parameter.Name))
                        .Append('=')
                        .Append(Uri.EscapeDataString(parameter.Value));
                }

                return result.ToString();
            }
        }
    }
}