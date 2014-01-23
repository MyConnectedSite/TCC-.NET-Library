using System;
using System.Collections.Generic;

namespace TCC2.API.Trips
{
    public static class TripsApi
    {
        #region SetTrip

        public static IAsyncResult BeginSetTrip(this Session session, string tripId, string title, string reference, string tripSpaceId, string software, AsyncCallback callback, object state)
        {
            SetTrip setTrip = new SetTrip(session);
            setTrip.BeginCall(tripId, title, reference, tripSpaceId, software, callback, state);
            return setTrip;
        }

        public static SetTripResult EndSetTrip(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            return ((SetTrip)ar).EndCall();
        }

        public static SetTripResult SetTrip(this Session session, string tripId, string title, string reference, string tripSpaceId, string software)
        {
            return new SetTrip(session).Call(tripId, title, reference, tripSpaceId, software);
        }

        #endregion

        #region AppendTrip

        public static IAsyncResult BeginAppendTrip(this Session session, string tripId, IEnumerable<TripPoint> points, IEnumerable<TripEvent> events, IEnumerable<TripTrack> tracks, AsyncCallback callback, object state)
        {
            AppendTrip appendTrip = new AppendTrip(session);
            appendTrip.BeginCall(tripId, points, events, tracks, callback, state);
            return appendTrip;
        }

        public static void EndAppendTrip(this Session session, IAsyncResult ar)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            if (ar == null)
                throw new ArgumentNullException("ar");

            ((AppendTrip)ar).EndCall();
        }

        public static void AppendTrip(this Session session, string tripId, IEnumerable<TripPoint> points, IEnumerable<TripEvent> events, IEnumerable<TripTrack> tracks)
        {
            new AppendTrip(session).Call(tripId, points, events, tracks);
        }

        #endregion
    }
}
