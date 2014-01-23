using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;

namespace TCC2.API
{
    public sealed partial class Session
    {
        sealed partial class PostRequest : Request, IUploader
        {
            abstract class Content
            {
                protected PostRequest m_Request;

                public Content(PostRequest request)
                {
                    Debug.Assert(request != null);
                    m_Request = request;
                }

                public abstract string ContentType { get; }
                public abstract long ContentLength { get; }

                public abstract void Write();
            }

            StreamWriteNotifier m_Uploader;
            Content m_Content;

            void RequestStreamIsGot(IAsyncResult state)
            {
                m_Uploader.SourceStream = m_WebRequest.EndGetRequestStream(state);

                RequestLogHelper.LogRequestURL("POST", m_WebRequest.RequestUri);
                RequestLogHelper.LogRequestParameters(m_WebRequest.Headers);

                m_Content.Write();
            }

            protected internal override HttpWebRequest CreateWebRequest()
            {
                if (m_DataProvider.Attachments.Any())
                    m_Content = new FormDataContent(this);

                Uri uri = new Uri(String.Format(CultureInfo.InvariantCulture, "{0}/{1}", m_Session.m_Url, m_DataProvider.Url));
                HttpWebRequest result = (HttpWebRequest)WebRequest.Create(uri);
                result.AllowWriteStreamBuffering = true;
                result.Method = "POST";
                result.ContentType = m_Content.ContentType;
                m_Uploader.BytesToProceed = result.ContentLength = m_Content.ContentLength;
                return result;
            }

            protected override void Begin()
            {
                m_WebRequest.BeginGetRequestStream(GetSafeCallback(RequestStreamIsGot), null);
            }

            protected override void OnComplete()
            {
                m_Uploader.Close();
            }

            public PostRequest(Session session)
                : base(session)
            {
                m_Uploader = new StreamWriteNotifier();
                m_Content = new UrlEncodedContent(this);
            }

            public override event EventHandler<ProgressEventArgs> UploadProgressChanged
            {
                add { m_Uploader.ProgressChanged += value; }
                remove { m_Uploader.ProgressChanged -= value; }
            }

            void FinishRequest(IAsyncResult state)
            {
                m_Uploader.EndWrite(state);
                m_Uploader.Close();
                m_WebRequest.BeginGetResponse(GetSafeCallback(RequestSent), null);
            }
        }
    }
}