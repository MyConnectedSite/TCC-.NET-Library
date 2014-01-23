using System;

namespace TCC2.API.Filesystem
{
    public class CheckOut : FileOperationApiCall
    {
        protected override string Url
        {
            get { return "checkout"; }
        }

        public CheckOut(Session session)
            : base(session)
        {
        }

        public CheckOut(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, string path, string clientType, string comment, AsyncCallback callback, object state)
        {
            AddParameter("comment", comment);
            BeginCall(filespaceId, path, clientType, callback, state);
        }

        public void Call(string filespaceId, string path, string clientType, string comment)
        {
            AddParameter("comment", comment);
            Call(filespaceId, path, clientType);
        }
    }
}