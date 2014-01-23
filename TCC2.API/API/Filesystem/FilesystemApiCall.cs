using System;

namespace TCC2.API.Filesystem
{
    public abstract class FilesystemApiCall<T> : ApiCallBase<T> where T : IApiCallResult
    {
        protected FilesystemApiCall(Session session)
            : base(session)
        {
        }

        protected FilesystemApiCall(Session session, IRequest request)
            : base(session, request)
        {
        }

        protected void AddFilesystemParams(string filespaceId, string path)
        {
            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace ID value cannot be null or empty", "filespaceId");

            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Path not specified", "path");

            AddParameter("filespaceid", filespaceId);
            AddParameter("path", path);
        }
    }
}