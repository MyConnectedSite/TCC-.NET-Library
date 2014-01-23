using System;
using System.IO;

namespace TCC2.API.Filesystem
{
    public class GetFile : ApiCallBase
    {
        Stream m_ResultStream;
        bool m_ShouldCloseResultStream;

        protected override Stream CreateResultStream()
        {
#if PocketPC
            if (Response.IsError)
                return new AsyncMemoryStream();
#else
            if (Response.IsError)
                return new MemoryStream();
#endif

            return m_ResultStream;
        }

        protected override string Url
        {
            get { return "getfile"; }
        }

        protected override void LogResponse()
        {
            RequestLogHelper.LogResponseTitle();
            RequestLogHelper.LogNewLine();
        }

        public GetFile(Session session)
            : base(session)
        {
        }

        public GetFile(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string fileName, string filespaceId, string path, DateTime? versionTime, string mimeType, bool? noAttachment, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentException("File name cannot be null or empty", "fileName");

            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            BeginCall(fileStream, filespaceId, path, true, versionTime, mimeType, noAttachment, callback, state);
        }

        public void BeginCall(Stream result, string filespaceId, string path, bool closeResultStream, DateTime? versionTime, string mimeType, bool? noAttachment, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (result == null)
                throw new ArgumentNullException("result", "Target file stream is not specified");

            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace ID value cannot be null or empty", "filespaceId");

            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Path not specified", "path");

            m_ShouldCloseResultStream = closeResultStream;
#if PocketPC
            m_ResultStream = new AsyncStream(result);
#else
            m_ResultStream = result;
#endif
            AddParameter("filespaceid", filespaceId);
            AddParameter("path", path);
            AddParameter("versiontime", versionTime);
            AddParameter("mimetype", mimeType);
            AddParameter("noattachment", noAttachment);
            BeginCall(callback, state);
        }

        public void EndCall()
        {
            try
            {
                End();

                if (Response.IsError)
                {
                    ApiCallResult result = ProcessResponseAsText<ApiCallResult>();
                    Validate(result);
                }
            }
            catch (TccException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new TccException("GetFile API call is failed", e);
            }
            finally
            {
                if (m_ShouldCloseResultStream)
                    m_ResultStream.Close();
            }
        }

        public void Call(Stream result, string filespaceId, string path, bool closeResultStream, DateTime? versionTime, string mimeType, bool? noAttachment)
        {
            BeginCall(result, filespaceId, path, closeResultStream, versionTime, mimeType, noAttachment, null, null);
            EndCall();
        }

        public void Call(string fileName, string filespaceId, string path, DateTime? versionTime, string mimeType, bool? noAttachment)
        {
            BeginCall(fileName, filespaceId, path, versionTime, mimeType, noAttachment, null, null);
            EndCall();
        }
    }
}