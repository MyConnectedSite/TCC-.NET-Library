using System;

using TCC2.API;

namespace TCC2.API.Filesystem
{
    public class DeleteFilespace : ApiCallBase<ApiCallResult>
    {
        protected override string Url
        {
            get { return "deletefilespace"; }
        }

        public DeleteFilespace(Session session)
            : base(session)
        {
        }

        public DeleteFilespace(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace Id cannot be null or empty", "filespaceId");

            AddParameter("filespaceId", filespaceId);
            BeginCall(callback, state);
        }

        public void Call(string filespaceId)
        {
            BeginCall(filespaceId, null, null);
            EndCall();
        }
    }
}