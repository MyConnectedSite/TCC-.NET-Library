using System;
using System.Collections.Generic;

namespace TCC2.API.Groups
{
    public class DeleteGroup : ApiCallBase<ApiCallResult>
    {
        public DeleteGroup(Session session)
            : base(session)
        {
        }

        public DeleteGroup(Session session, IRequest request)
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

        public void Call(string groupId)
        {
            BeginCall(groupId, null, null);
            EndCall();
        }

        protected override string Url
        {
            get { return "deletegroup"; }
        }
    }
}