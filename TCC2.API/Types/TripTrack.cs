using System;

namespace TCC2.API.Trips
{
    public class TripTrack
    {
        TripPoint m_EndPoint;

        public TripTrack(TripPoint startPoint)
        {
            StartPoint = startPoint;
            Tag = String.Empty;
        }

        public string Tag { get; set; }
        public TripPoint StartPoint { get; private set; }

        public TripPoint EndPoint
        {
            get { return m_EndPoint; }

            set
            {
                if (value != null && value.TimeStamp < StartPoint.TimeStamp)
                    throw new ArgumentException("Track end time cannot be less than start time");

                m_EndPoint = value;
            }
        }
    }
}
