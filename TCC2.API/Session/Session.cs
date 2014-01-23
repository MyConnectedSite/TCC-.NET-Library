using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

namespace TCC2.API
{
    public enum SessionOpenMode
    {
        Redirect,
        NoRedirect
    }

    public partial class Session : IDisposable
    {
#if PocketPC
        //Required for correct work of HTTPS connections
        class AcceptAllCerts : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvPoint, System.Security.Cryptography.X509Certificates.X509Certificate certificate, WebRequest request, int certificateProblem)
            {
                return true;
            }
        }

        static Session()
        {
            ServicePointManager.CertificatePolicy = new AcceptAllCerts();
        }
#endif

        string m_Url;
        SynchronizedDictionary<string, string> m_Cookies = new SynchronizedDictionary<string,string>();
        int m_Timeout = DefaultTimeoutMilliseconds;

        const string TicketCookieName = "ticket";

        public const int DefaultTimeoutMilliseconds = 100000;

        public Session(string url)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("URL cannot be null or empty");

            m_Url = url;
        }

        public void Dispose()
        {
            if (IsOpened)
                Close();
        }

        public static bool LoggingEnabled
        {
            get { return Log.Instance.Enabled; }
        }

        public static void EnableLogging()
        {
            Log.Instance.Enable();
        }

        public static void DisableLogging()
        {
            Log.Instance.Disable();
        }

        string GetCookies()
        {
            if (m_Cookies.Count == 0)
                return null;

            StringBuilder sb = new StringBuilder();
            string separator = String.Empty;
            lock (m_Cookies.SyncRoot)
            {
                foreach (KeyValuePair<string, string> cookie in m_Cookies)
                {
                    sb.Append(separator).Append(cookie.Key).Append('=').Append(cookie.Value);
                    separator = "; ";
                }
            }
            return sb.ToString();
        }

        public void SetCookie(string name, string value)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Cookie name cannot be null or empty string");

            if (name == TicketCookieName)
            {
                throw new ArgumentException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Cookie name \"{0}\" is reserved for internal usage", TicketCookieName));
            }

            if (value == null)
                m_Cookies.Remove(name);
            else
                m_Cookies[name] = value;
        }

        public IAsyncResult BeginOpen(string userName, string orgName, string password, string appKey, SessionOpenMode? mode, string redirUrl, bool? forceGmt, AsyncCallback callback, object state)
        {
            if (IsOpened)
                throw new InvalidOperationException("Session already opened");

            Login logon = new Login(this);
            logon.BeginCall(userName, orgName, password, appKey, mode, redirUrl, forceGmt, callback, state);
            return logon;
        }

        public IAsyncResult BeginOpen(string userName, string orgName, string password, AsyncCallback callback, object state)
        {
            return BeginOpen(userName, orgName, password, null, null, null, null, callback, state);
        }

        public void EndOpen(IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            LogonResult result = ((Login)ar).EndCall();
            m_Cookies.Add(TicketCookieName, result.Ticket);
        }

        public void Open(string userName, string orgName, string password, string appKey, SessionOpenMode? mode, string redirUrl, bool? forceGmt)
        {
            EndOpen(BeginOpen(userName, orgName, password, appKey, mode, redirUrl, forceGmt, null, null));
        }

        public void Open(string userName, string orgName, string password)
        {
            Open(userName, orgName, password, null, null, null, null);
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            if (!IsOpened)
                throw new InvalidOperationException("Session is not opened");

            Logoff logoff = new Logoff(this);
            logoff.BeginCall(callback, state);
            return logoff;
        }

        public void EndClose(IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");

            ((Logoff)ar).EndCall();
            m_Cookies.Remove(TicketCookieName);
        }

        public void Close()
        {
            EndClose(BeginClose(null, null));
        }

        public IRequest CreateGetRequest()
        {
            return new GetRequest(this);
        }

        public IRequest CreatePostRequest()
        {
            return new PostRequest(this);
        }

        public bool IsOpened
        {
            get { return m_Cookies.ContainsKey(TicketCookieName); }
        }

        public string SessionId
        {
            get
            {
                string id;
                if (!m_Cookies.TryGetValue(TicketCookieName, out id))
                    id = null;

                return id;
            }

            internal set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid session ID", "value");

                m_Cookies[TicketCookieName] = value;
            }
        }

        public IWebProxy Proxy { get; set; }

        public int Timeout
        {
            get { return m_Timeout; }

            set
            {
                if (value < -1)
                    throw new ArgumentOutOfRangeException("value", "Timeout must be greater than or equal to -1");

                m_Timeout = value;
            }
        }
    }
}
