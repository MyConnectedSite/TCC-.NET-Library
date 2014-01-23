using System;

namespace TCC2.API.CloudTracker
{
    public class GetCloudTrackerItemFilters : ApiCallBase<GetCloudTrackerItemFiltersResult>
    {
        public GetCloudTrackerItemFilters(Session session)
            : base(session)
        {
        }

        public GetCloudTrackerItemFilters(Session session, IRequest request)
            : base(session, request)
        {
        }

        public new void BeginCall(AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();
            base.BeginCall(callback, state);
        }

        public GetCloudTrackerItemFiltersResult Call()
        {
            BeginCall(null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getcloudtrackeritemfilters"; }
        }
    }
}