using System;
using System.Collections.Generic;
using System.Globalization;
using TCC2.API;

namespace TCC2.API.Trips
{
    public class AppendTrip : ApiCallBase<ApiCallResult>
    {
        protected override string Url
        {
            get { return "appendtrip"; }
        }

        public AppendTrip(Session session)
            : base(session)
        {
        }

        public void BeginCall(string tripId, IEnumerable<TripPoint> points, IEnumerable<TripEvent> events, IEnumerable<TripTrack> tracks, AsyncCallback callback, object state)
        {
            CheckAlreadyCalled();

            if (String.IsNullOrEmpty(tripId))
                throw new ArgumentException("Trip ID value cannot be null or empty", "tripId");

            AddParameter("tripid", tripId);

            if (points != null)
            {
                foreach (TripPoint point in points)
                {
                    AddPointData("point", point);
                }
            }

            if (events != null)
            {
                foreach (TripEvent tripEvent in events)
                {
                    AddPointData("event", tripEvent);
                    AddParameter("eventtype", tripEvent.EventType.ToString().ToLower(CultureInfo.InvariantCulture));
                    AddParameter("comment", (tripEvent.Comment == null) ? String.Empty : tripEvent.Comment);
                    AddParameter("path", (tripEvent.Path == null) ? String.Empty : tripEvent.Path);
                }
            }

            if (tracks != null)
            {
                foreach (TripTrack track in tracks)
                {
                    AddParameter("trackstarttime", track.StartPoint.TimeStamp);
                    AddParameter("trackendtime", track.EndPoint.TimeStamp);
                    AddParameter("tag", track.Tag);
                }
            }

            BeginCall(callback, state);
        }

        public void Call(string tripId, IEnumerable<TripPoint> points, IEnumerable<TripEvent> events, IEnumerable<TripTrack> tracks)
        {
            BeginCall(tripId, points, events, tracks, null, null);
            EndCall();
        }

        protected override IRequest GetDefaultRequest()
        {
            return Session.CreatePostRequest();
        }

        void AddPointData(string prefix, TripPoint point)
        {
            AddParameter(prefix + "time", point.TimeStamp);
            AddParameter(prefix + "latitude", point.Latitude);
            AddParameter(prefix + "longitude", point.Longitude);
            AddParameterOrEmptyPlaceholder(prefix + "hardwaremake", point.HardwareMake);
            AddParameterOrEmptyPlaceholder(prefix + "hardwaremodel", point.HardwareModel);
            AddParameterOrEmptyPlaceholder(prefix + "provider", point.Provider);
            AddParameterOrEmptyPlaceholder(prefix + "technology", point.Technology);
            AddParameterOrEmptyPlaceholder(prefix + "locationmethod", point.LocationMethod);
            AddParameterOrEmptyPlaceholder(prefix + "signalstrength", point.SignalStrength);
        }
    }
}