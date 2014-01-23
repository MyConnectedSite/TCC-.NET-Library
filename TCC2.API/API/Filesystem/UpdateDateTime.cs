using System;

namespace TCC2.API.Filesystem
{
    public class UpdateDateTime : FilesystemApiCall<ApiCallResult>
    {
        protected override string Url
        {
            get { return "updatedatetime"; }
        }

        public UpdateDateTime(Session session)
            : base(session)
        {
        }

        public UpdateDateTime(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, string path, DateTime? createTime, DateTime? modifyTime, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            AddFilesystemParams(filespaceId, path);
            if (!createTime.HasValue && !modifyTime.HasValue)
                throw new InvalidOperationException("Timestamps not specified");

            AddParameter("filespaceid", filespaceId);
            AddParameter("path", path);
            AddParameter("createDate", createTime);
            AddParameter("modifyDate", modifyTime);
            BeginCall(callback, state);
        }

        public void Call(string filespaceId, string path, DateTime? createTime, DateTime? modifyTime)
        {
            BeginCall(filespaceId, path, createTime, modifyTime, null, null);
            EndCall();
        }
    }
}