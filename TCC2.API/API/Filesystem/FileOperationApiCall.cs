using System;

namespace TCC2.API.Filesystem
{
    public abstract class FileOperationApiCall : FilesystemApiCall<ApiCallResult>
    {
        protected FileOperationApiCall(Session session)
            : base(session)
        {
        }

        protected FileOperationApiCall(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, string path, string clientType, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            AddFilesystemParams(filespaceId, path);
            AddParameter("clienttype", clientType);
            BeginCall(callback, state);
        }

        public void Call(string filespaceId, string path, string clientType)
        {
            BeginCall(filespaceId, path, clientType, null, null);
            EndCall();
        }
    }
}