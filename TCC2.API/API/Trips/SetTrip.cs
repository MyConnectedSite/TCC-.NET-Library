using System;
using TCC2.API;

namespace TCC2.API.Trips
{
    public class SetTrip : ApiCallBase<SetTripResult>
    {
        protected override string Url
        {
            get { return "settrip"; }
        }

        public SetTrip(Session session)
            : base(session)
        {
        }

        public SetTrip(Session session, IRequest request)
            : base(session, request)
        {
        }

        public void BeginCall(string tripId, string title, string reference, string tripSpaceId, string software, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(tripSpaceId))
                throw new ArgumentException("Tripspace ID value cannot be null or empty", "tripSpaceId");

            AddParameter("tripid", tripId);
            AddParameter("title", title);
            AddParameter("reference", reference);
            AddParameter("tripSpaceId", tripSpaceId);
            AddParameter("software", software);
            BeginCall(callback, state);
        }

        public SetTripResult Call(string tripId, string title, string reference, string tripSpaceId, string software)
        {
            BeginCall(tripId, title, reference, tripSpaceId, software, null, null);
            return EndCall();
        }
    }
}