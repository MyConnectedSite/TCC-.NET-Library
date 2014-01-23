using System;

namespace TCC2.API.Members
{
    public class GetMember : ApiCallBase<GetMemberResult>
    {
        protected override string Url
        {
            get { return "getmember"; }
        }

        public GetMember(Session session)
            : base(session)
        {
        }

        public GetMember(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string memberId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            AddParameter("memberid", memberId);
            BeginCall(callback, state);
        }

        public GetMemberResult Call(string memberId)
        {
            BeginCall(memberId, null, null);
            return EndCall();
        }
    }
}