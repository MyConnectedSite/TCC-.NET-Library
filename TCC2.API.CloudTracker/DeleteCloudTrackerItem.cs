
namespace TCC2.API.CloudTracker
{
    public class DeleteCloudTrackerItem : CloudTrackerItemOperation<ApiCallResult>
    {
        public DeleteCloudTrackerItem(Session session)
            : base(session)
        {
        }

        public DeleteCloudTrackerItem(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void Call(string itemId)
        {
            BeginCall(itemId, null, null);
            EndCall();
        }

        protected override string Url
        {
            get { return "deletecloudtrackeritem"; }
        }
    }
}