using System;
using Newtonsoft.Json;

namespace TCC2.API.Organizations
{
    public class GetOrganization : ApiCallBase<GetOrganizationResult>
    {
        public GetOrganization(Session session)
            : base(session)
        {
        }

        public GetOrganization(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string orgId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(orgId))
                throw new ArgumentException("Organization ID cannot be null or empty", "orgId");

            AddParameter("orgid", orgId);
            BeginCall(callback, state);
        }

        public GetOrganizationResult Call(string orgId)
        {
            BeginCall(orgId, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getorganization"; }
        }
    }
}