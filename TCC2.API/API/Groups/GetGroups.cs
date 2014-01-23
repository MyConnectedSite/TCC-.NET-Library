using System;
using System.Collections.Generic;

namespace TCC2.API.Groups
{
    public class GetGroups : ApiCallBase<GetGroupsResult>
    {
        public GetGroups(Session session)
            : base(session)
        {
        }

        public GetGroups(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string orgId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(orgId))
                throw new ArgumentException("Invalid organization ID");

            AddParameter("orgid", orgId);
            BeginCall(callback, state);
        }

        public GetGroupsResult Call(string orgId)
        {
            BeginCall(orgId, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getgroups"; }
        }
    }
}