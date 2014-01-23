using System;
using System.Globalization;

namespace TCC2.API.Filesystem
{
    public enum FilespacesFilter
    {
        MyOrg,
        OtherOrgs,
        All
    }

    public class GetFilespaces : ApiCallBase<GetFilespacesResult>
    {
        protected override string Url
        {
            get { return "getfilespaces"; }
        }

        public GetFilespaces(Session session)
            : base(session)
        {
        }

        public GetFilespaces(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string filespaceType, string orgIdFilter, FilespacesFilter? filter, bool? showAnonymous, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (filter.HasValue)
                AddParameter("filter", filter.Value.ToString().ToLower(CultureInfo.InvariantCulture));

            AddParameter("filespacetype", filespaceType);
            AddParameter("orgId", orgIdFilter);
            AddParameter("ShowAnonymous", showAnonymous);
            BeginCall(callback, state);
        }

        public GetFilespacesResult Call(string type, string orgIdFilter, FilespacesFilter? filter, bool? showAnonymous)
        {
            BeginCall(type, orgIdFilter, filter, showAnonymous, null, null);
            return EndCall();
        }
    }
}