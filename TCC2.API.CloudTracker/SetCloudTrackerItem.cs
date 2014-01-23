using System;

namespace TCC2.API.CloudTracker
{
    public class SetCloudTrackerItem : ApiCallBase<SetCloudTrackerItemResult>
    {
        public SetCloudTrackerItem(Session session)
            : base(session)
        {
        }

        public SetCloudTrackerItem(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string itemId, string orgId, string activeEPC, string assetIcon, string category, string type, string manufacturer, string model, string serialNumber, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(activeEPC))
                throw new ArgumentException("Active EPC is not specified", "activeEPC");

            if (String.IsNullOrEmpty(category))
                throw new ArgumentException("Item category is not specified", "category");

            if (String.IsNullOrEmpty(type))
                throw new ArgumentException("Item type is not specified", "type");

            if (String.IsNullOrEmpty(manufacturer))
                throw new ArgumentException("Item manufacturer is not specified", "manufacturer");

            if (String.IsNullOrEmpty(model))
                throw new ArgumentException("Item model is not specified", "model");

            if (String.IsNullOrEmpty(serialNumber))
                throw new ArgumentException("Item serial number is not specified", "serialNumber");

            AddParameter("itemId", itemId);
            AddParameter("orgId", orgId);
            AddParameter("activeEPC", activeEPC);
            AddParameter("assetIcon", assetIcon);
            AddParameter("category", category);
            AddParameter("type", type);
            AddParameter("manufacturer", manufacturer);
            AddParameter("model", model);
            AddParameter("serialnumber", serialNumber);

            BeginCall(callback, state);
        }

        public SetCloudTrackerItemResult Call(string itemId, string orgId, string activeEPC, string assetIcon, string category, string type, string manufacturer, string model, string serialNumber)
        {
            BeginCall(itemId, orgId, activeEPC, assetIcon, category, type, manufacturer, model, serialNumber, null, null);
            return EndCall();
        }

        protected override string Url
        {
            get { return "setcloudtrackeritem"; }
        }
    }
}