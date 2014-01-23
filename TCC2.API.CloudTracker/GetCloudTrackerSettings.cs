using System;

namespace TCC2.API.CloudTracker
{
    public class GetCloudTrackerSettings : ApiCallBase<GetCloudTrackerSettingsResult>
    {
        public GetCloudTrackerSettings(Session session)
            : base(session)
        {
        }

        public GetCloudTrackerSettings(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string orgId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(orgId))
                throw new ArgumentException("Organization ID is not specified", "orgId");

            AddParameter("orgId", orgId);
            BeginCall(callback, state);
        }

        public GetCloudTrackerSettingsResult Call(string orgId)
        {
            BeginCall(orgId, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getcloudtrackersettings"; }
        }
    }
}