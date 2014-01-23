using System;
using System.Collections.Generic;

namespace TCC2.API.Groups
{
    public class GetGroup : ApiCallBase<GetGroupResult>
    {
        public GetGroup(Session session)
            : base(session)
        {
        }

        public GetGroup(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string groupId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(groupId))
                throw new ArgumentException("Invalid group ID");

            AddParameter("groupid", groupId);
            BeginCall(callback, state);
        }

        public GetGroupResult Call(string groupId)
        {
            BeginCall(groupId, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getgroup"; }
        }
    }
}