using System;

namespace TCC2.API.Filesystem
{
    public class GetFilespace : ApiCallBase<GetFilespaceResult>
    {
        protected override string Url
        {
            get { return "getfilespace"; }
        }

        public GetFilespace(Session session)
            : base(session)
        {
        }

        public GetFilespace(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(filespaceId))
                throw new ArgumentException("Filespace ID value cannot be null or empty", "filespaceId");

            AddParameter("filespaceId", filespaceId);
            BeginCall(callback, state);
        }

        public void BeginCall(string filespaceShortName, string orgShortName, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(filespaceShortName))
                throw new ArgumentException("Filespace short name cannot be null or empty", "filespaceShortName");

            if (String.IsNullOrEmpty(orgShortName))
                throw new ArgumentException("Organization short name cannot be null or empty", "orgShortName");

            AddParameter("filespaceshortname", filespaceShortName);
            AddParameter("orgshortname", orgShortName);
            BeginCall(callback, state);
        }

        public GetFilespaceResult Call(string filespaceId)
        {
            BeginCall(filespaceId, null, null);
            return EndCall();
        }

        public GetFilespaceResult Call(string filespaceShortName, string orgShortName)
        {
            BeginCall(filespaceShortName, orgShortName, null, null);
            return EndCall();
        }
    }
}