using System;

namespace TCC2.API.CloudTracker
{
    public class SetCloudTrackerSettings : ApiCallBase<ApiCallResult>
    {
        public SetCloudTrackerSettings(Session session)
            : base(session)
        {
        }

        public SetCloudTrackerSettings(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string orgId, string viewGroup, string addEventGroup, string editGroup, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(orgId))
                throw new ArgumentException("Organization ID is not specified", "orgId");

            if (String.IsNullOrEmpty(viewGroup))
                throw new ArgumentException("Viewer group is not specified", "viewGroup");

            if (String.IsNullOrEmpty(addEventGroup))
                throw new ArgumentException("Event depositor group is not specified", "addEventGroup");

            if (String.IsNullOrEmpty(editGroup))
                throw new ArgumentException("Editor group is not specified", "editGroup");

            AddParameter("orgId", orgId);
            AddParameter("viewGroup", viewGroup);
            AddParameter("addEventGroup", addEventGroup);
            AddParameter("editGroup", editGroup);

            BeginCall(callback, state);
        }

        public void Call(string orgId, string viewGroup, string addEventGroup, string editGroup)
        {
            BeginCall(orgId, viewGroup, addEventGroup, editGroup, null, null);
            EndCall();
        }

        protected override string Url
        {
            get { return "setcloudtrackersettings"; }
        }
    }
}