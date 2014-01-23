using System;

namespace TCC2.API.CloudTracker
{
    public abstract class CloudTrackerItemOperation<T> : ApiCallBase<T> where T : IApiCallResult
    {
        protected CloudTrackerItemOperation(Session session)
            : base(session)
        {
        }

        protected CloudTrackerItemOperation(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string itemId, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(itemId))
                throw new ArgumentException("Item ID is not specified", "itemId");

            AddParameter("itemId", itemId);
            BeginCall(callback, state);
        }
    }
}