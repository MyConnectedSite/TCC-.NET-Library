
namespace TCC2.API.CloudTracker
{
    public class GetCloudTrackerItem : CloudTrackerItemOperation<GetCloudTrackerItemResult>
    {
        public GetCloudTrackerItem(Session session)
            : base(session)
        {
        }

        public GetCloudTrackerItem(Session session, IRequest request)
            : base(session, request)
        {
        }

        public GetCloudTrackerItemResult Call(string itemId)
        {
            BeginCall(itemId, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "getcloudtrackeritem"; }
        }
    }
}