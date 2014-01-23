using System;

namespace TCC2.API.Trips
{
    public enum TripEventType
    {
        Text,
        Video,
        Audio,
        Image
    }

    public class TripEvent : TripPoint
    {
        public TripEvent(double latitude, double longitude, DateTime timeStamp, TripEventType type)
            : this(latitude, longitude, timeStamp, null, null, null, null, null, null, type)
        {
        }

        public TripEvent(double latitude, double longitude, DateTime timeStamp, string hardwareMake, string hardwareModel, string provider, string technology, string locationMethod, string signalStrength, TripEventType type)
            : base(latitude, longitude, timeStamp, hardwareMake, hardwareModel, provider, technology, locationMethod, signalStrength)
        {
            if (!Enum.IsDefined(typeof(TripEventType), type))
                throw new ArgumentException("Unknown event type " + type.ToString(), "type");

            EventType = type;
        }

        public string Comment { get; set; }
        public string Path { get; set; }
        public string LocalPath { get; set; }
        public TripEventType EventType { get; private set; }
    }
}
