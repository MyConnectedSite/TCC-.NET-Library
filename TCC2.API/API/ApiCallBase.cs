using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TCC2.API
{
    public abstract class ApiCallBase : AsyncResult, IRequestDataProvider
    {
        byte[] m_Buffer;
        StreamReadNotifier m_Downloader;
        List<ApiParameter> m_Parameters = new List<ApiParameter>();
        List<BinaryAttachment> m_Attachments = new List<BinaryAttachment>();
        IRequest m_Request;
        Session m_Session;
        int? m_Timeout;
        bool m_AlreadyCalled;

        public const string TccDateTimeFormat = "yyyy-MM-dd-HH:mm:ss.fff";

        protected ApiCallBase(Session session)
        {
            InitializeInstance(session);
        }

        protected ApiCallBase(Session session, IRequest request)
        {
            InitializeInstance(session);
            Request = request;
        }

        public int Timeout
        {
            get { return m_Timeout ?? m_Session.Timeout; }

            set
            {
                if (value < System.Threading.Timeout.Infinite)
                    throw new ArgumentOutOfRangeException("value");

                m_Timeout = value;
            }
        }

        public void Abort()
        {
            if (Request != null)
            {
                UnsubscribeUploadNotifications();
                Request.Abort();
            }
        }

        public event EventHandler<ProgressEventArgs> DownloadProgressChanged;
        public event EventHandler<ProgressEventArgs> UploadProgressChanged;

        protected IResponse Response { get; private set; }
        protected Stream ResultStream { get; private set; }

        protected IRequest Request
        {
            get { return m_Request; }

            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (value == m_Request)
                    return;

                UnsubscribeUploadNotifications();
                m_Request = value;
                SubscribeUploadNotifications();
            }
        }

        protected Session Session
        {
            get { return m_Session; }

            private set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                m_Session = value;
            }
        }

        protected abstract Stream CreateResultStream();
        protected abstract string Url { get; }

        protected override void OnComplete()
        {
            LogResponse();
            m_Downloader.Close();
            m_Downloader.ProgressChanged -= OnDownloadProgressChanged;
        }

        protected virtual void LogResponse()
        {
            if (ResultStream != null)
            {
                RequestLogHelper.LogResponseTitle();

                ResultStream.Seek(0, SeekOrigin.Begin);
                byte[] buffer = new byte[ResultStream.Length];
                ResultStream.Read(buffer, 0, buffer.Length);
                RequestLogHelper.LogBytes(buffer, 0, buffer.Length);

                RequestLogHelper.LogNewLine();
            }
        }

        protected sealed override void Begin()
        {
            m_Request.BeginGetResponse(GetSafeCallback(ResponseIsGot), null);
        }

        #region AddParameter overloads

        protected void AddParameter(string name, string value)
        {
            if (value == null)
                return;

            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Parameter name cannot be null or empty string");

            m_Parameters.Add(new ApiParameter(name, value));
        }

        protected void AddParameter(string name, DateTime value)
        {
            AddParameter(name, value.ToString(TccDateTimeFormat, CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, bool value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, double value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, float value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, long value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, ulong value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, int value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, uint value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, short value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, ushort value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, byte value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, sbyte value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, decimal value)
        {
            AddParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        protected void AddParameter(string name, DateTime? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, bool? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, double? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, float? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, long? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, ulong? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, int? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, uint? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, short? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, ushort? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, byte? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, sbyte? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameter(string name, decimal? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
        }

        protected void AddParameters(IEnumerable<ApiParameter> parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            m_Parameters.AddRange(parameters);
        }

        #endregion

        #region AddParameterOrEmptyPlaceholder overloads

        protected void AddParameterOrEmptyPlaceholder(string name, string value)
        {
            AddParameter(name, value ?? String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, DateTime? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, bool? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, double? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, float? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, long? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, ulong? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, int? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, uint? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, short? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, ushort? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, byte? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, sbyte? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        protected void AddParameterOrEmptyPlaceholder(string name, decimal? value)
        {
            if (value.HasValue)
                AddParameter(name, value.Value);
            else
                AddParameter(name, String.Empty);
        }

        #endregion

        protected void AddAttachment(string name, BinaryAttachment attachment)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Attachment name cannot be null or empty");

            if (attachment == null)
                throw new ArgumentNullException("attachment");

            m_Attachments.Add(attachment);
        }

        protected virtual bool LoginRequired
        {
            get { return true; }
        }

        protected void Validate(IApiCallResult apiCallResult)
        {
            try
            {
                apiCallResult.Validate(this);
            }
            catch (JsonSerializationException e)
            {
                string message = String.Format(CultureInfo.InvariantCulture,
                    "Invalid response returned for {0} API call", GetType().Name);
                throw new TccException(message, e);
            }
        }

        protected T ProcessResponseAsText<T>()
        {
            return JsonConvert.DeserializeObject<T>(GetResponseAsText());
        }

        protected string GetResponseAsText()
        {
            MemoryStream ms = (MemoryStream)ResultStream;
            string text = Response.GetDataEncoding().GetString(ms.GetBuffer(), 0, (int)ms.Length);
            ResultStream.Close();

            if (String.IsNullOrEmpty(text))
                throw new TccException("No response returned from server", false);

            return text;
        }

        protected void BeginCall(AsyncCallback callback, object state)
        {
            m_AlreadyCalled = true;
            if (LoginRequired && !m_Session.IsOpened)
                throw new InvalidOperationException("Session must be opened prior to call this API");

            if (Request == null)
                Request = GetDefaultRequest();

            Request.Timeout = Timeout;
            Request.SetDataProvider(this);
            Begin(callback, state);
        }

        protected void CheckAlreadyCalled()
        {
            if (m_AlreadyCalled)
                throw new InvalidOperationException("Already called");
        }

        protected virtual IRequest GetDefaultRequest()
        {
            return m_Session.CreateGetRequest();
        }

        void ResponseIsGot(IAsyncResult state)
        {
            Response = Request.EndGetResponse();
            UnsubscribeUploadNotifications();
            m_Downloader.BytesToProceed = ParseContentLength(Response);
            m_Downloader.SourceStream = Response.Data;
            ResultStream = CreateResultStream();
            m_Buffer = new byte[8192];

            ReadResponseChunk(null);
        }

        void InitializeInstance(Session session)
        {
            Session = session;
            m_Downloader = new StreamReadNotifier();
            m_Downloader.ProgressChanged += OnDownloadProgressChanged;
        }

        static long ParseContentLength(IResponse response)
        {
            try
            {
                return Int64.Parse(response.Headers["Content-Length"], NumberStyles.Integer, CultureInfo.InvariantCulture);
            }
            catch
            {
                return StreamNotifier.MaxProgressIsUndefined;
            }
        }

        void WriteResultChunk(IAsyncResult state)
        {
            int bytesRead = m_Downloader.EndRead(state);
            if (bytesRead == 0)
            {
                Complete(null);
                return;
            }

            ResultStream.BeginWrite(m_Buffer, 0, bytesRead, GetSafeCallback(ReadResponseChunk), null);
        }

        void ReadResponseChunk(IAsyncResult state)
        {
            if (state != null)
                ResultStream.EndWrite(state);

            m_Downloader.SourceStream.BeginRead(m_Buffer, 0, m_Buffer.Length, GetSafeCallback(WriteResultChunk), null);
        }

        void SubscribeUploadNotifications()
        {
            IUploader uploader = Request as IUploader;
            if (uploader != null)
                uploader.UploadProgressChanged += OnUploadProgressChanged;
        }

        void UnsubscribeUploadNotifications()
        {
            IUploader uploader = Request as IUploader;
            if (uploader != null)
                uploader.UploadProgressChanged -= OnUploadProgressChanged;
        }

        void OnDownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            if (DownloadProgressChanged != null)
                DownloadProgressChanged(this, e);
        }

        void OnUploadProgressChanged(object sender, ProgressEventArgs e)
        {
            if (UploadProgressChanged != null)
                UploadProgressChanged(this, e);
        }

        string IRequestDataProvider.Url
        {
            get { return Url; }
        }

        IEnumerable<ApiParameter> IRequestDataProvider.Parameters
        {
            get { return m_Parameters; }
        }

        IEnumerable<BinaryAttachment> IRequestDataProvider.Attachments
        {
            get { return m_Attachments; }
        }
    }
}
