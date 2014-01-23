using System;

namespace TCC2.API.Filesystem
{
    public class Del : FileOperationApiCall
    {
        protected override string Url
        {
            get { return "del"; }
        }

        public Del(Session session)
            : base(session)
        {
        }

        public Del(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, string path, bool recursive, string clientType, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            AddParameter("recursive", recursive ? "yes" : "no");
            BeginCall(filespaceId, path, clientType, callback, state);
        }

        public void Call(string filespaceId, string path, bool recursive, string clientType)
        {
            BeginCall(filespaceId, path, recursive, clientType, null, null);
            EndCall();
        }
    }
}