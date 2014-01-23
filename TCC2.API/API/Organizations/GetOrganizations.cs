using System;
using Newtonsoft.Json;

namespace TCC2.API.Organizations
{
    public class GetOrganizations : ApiCallBase<GetOrganizationsResult>
    {
        public GetOrganizations(Session session)
            : base(session)
        {
        }

        public GetOrganizations(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(bool includeCurrentMemberOrg, bool partnersOnly, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            AddParameter("returnself", includeCurrentMemberOrg);
            AddParameter("partnersonly", partnersOnly);
            BeginCall(callback, state);
        }

        public GetOrganizationsResult Call(bool includeCurrentMemberOrg, bool partnersOnly)
        {
            BeginCall(includeCurrentMemberOrg, partnersOnly, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getorganizations"; }
        }
    }
}