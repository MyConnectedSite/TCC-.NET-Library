using System;
using System.IO;

namespace TCC2.API.Filesystem
{
    public class Files : ApiCallBase
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
            get { return "files"; }
        }

        protected override bool LoginRequired
        {
            get { return false; }
        }

        public Files(Session session)
            : base(session)
        {
        }

        public Files(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(Stream result, string orgShortName, string filespaceShortName, string path, bool closeResultStream, bool? noAttachment, AsyncCallback callback, object state)
        {
            ValidateOrgNameAndFilespaceName(orgShortName, filespaceShortName);
            BeginCall(result, orgShortName, filespaceShortName, null, path, closeResultStream, noAttachment, callback, state);
        }

        public void BeginCall(string fileName, string orgShortName, string filespaceShortName, string path, bool? noAttachment, AsyncCallback callback, object state)
        {
            ValidateOrgNameAndFilespaceName(orgShortName, filespaceShortName);
            BeginCall(fileName, orgShortName, filespaceShortName, null, path, noAttachment, callback, state);
        }

        public void BeginCall(Stream result, string filespaceId, string path, bool closeResultStream, bool? noAttachment, AsyncCallback callback, object state)
        {
            ValidateFilespaceId(filespaceId);
            BeginCall(result, null, null, filespaceId, path, closeResultStream, noAttachment, callback, state);
        }

        public void BeginCall(string fileName, string filespaceId, string path, bool? noAttachment, AsyncCallback callback, object state)
        {
            ValidateFilespaceId(filespaceId);
            BeginCall(fileName, null, null, filespaceId, path, noAttachment, callback, state);
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
                throw new TccException("Files API call is failed", e);
            }
            finally
            {
                if (m_ShouldCloseResultStream)
                    m_ResultStream.Close();
            }
        }

        public void Call(Stream result, string orgShortName, string filespaceShortName, string path, bool closeResultStream, bool? noAttachment)
        {
            BeginCall(result, orgShortName, filespaceShortName, path, closeResultStream, noAttachment, null, null);
            EndCall();
        }

        public void Call(string fileName, string orgShortName, string filespaceShortName, string path, bool? noAttachment)
        {
            BeginCall(fileName, orgShortName, filespaceShortName, path, noAttachment, null, null);
            EndCall();
        }

        public void Call(Stream result, string filespaceId, string path, bool closeResultStream, bool? noAttachment)
        {
            BeginCall(result, filespaceId, path, closeResultStream, noAttachment, null, null);
            EndCall();
        }

        public void Call(string fileName, string filespaceId, string path, bool? noAttachment)
        {
            BeginCall(fileName, filespaceId, path, noAttachment, null, null);
            EndCall();
        }

        void BeginCall(Stream result, string orgShortName, string filespaceShortName, string filespaceId, string path, bool closeResultStream, bool? noAttachment, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (result == null)
                throw new ArgumentNullException("result");

            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Path not specified", "path");

            m_ShouldCloseResultStream = closeResultStream;
#if PocketPC
            m_ResultStream = new AsyncStream(result);
#else
            m_ResultStream = result;
#endif

            AddParameter("orgshortname", orgShortName);
            AddParameter("filespaceshortname", filespaceShortName);
            AddParameter("filespaceid", filespaceId);
            AddParameter("path", path);
            AddParameter("noattachment", noAttachment);
            BeginCall(callback, state);
        }

        void BeginCall(string fileName, string orgShortName, string filespaceShortName, string filespaceId, string path, bool? noAttachment, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentException("File name cannot be null or empty", "fileName");

            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
            BeginCall(fileStream, orgShortName, filespaceShortName, filespaceId, path, true, noAttachment, callback, state);
        }

        static void ValidateFilespaceId(string filespaceId)
        {
            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace ID value cannot be null or empty", "filespaceId");
        }

        static void ValidateOrgNameAndFilespaceName(string orgShortName, string filespaceShortName)
        {
            if (String.IsNullOrEmpty(orgShortName))
                throw new ArgumentException("Org shortname value cannot be null or empty", "orgShortName");

            if (String.IsNullOrEmpty(filespaceShortName))
                throw new ArgumentException("Filespace shortname value cannot be null or empty", "filespaceShortName");
        }
    }
}