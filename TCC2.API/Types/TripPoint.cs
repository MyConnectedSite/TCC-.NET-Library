using System;

namespace TCC2.API.Trips
{
    public class TripPoint
    {
        public TripPoint(double latitude, double longitude, DateTime timeStamp)
        {
            ValidateDouble(latitude, -90.0, 90.0, "latitude");
            ValidateDouble(longitude, -180.0, 180.0, "longitude");

            TimeStamp = timeStamp;
            Latitude = latitude;
            Longitude = longitude;
        }

        public TripPoint(double latitude, double longitude, DateTime timeStamp, string hardwareMake, string hardwareModel, string provider, string technology, string locationMethod, string signalStrength)
            : this(latitude, longitude, timeStamp)
        {
            HardwareMake = hardwareMake;
            HardwareModel = hardwareModel;
            Provider = provider;
            Technology = technology;
            LocationMethod = locationMethod;
            SignalStrength = signalStrength;
        }

        public DateTime TimeStamp { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string HardwareMake { get; private set; }
        public string HardwareModel { get; private set; }
        public string Provider { get; private set; }
        public string Technology { get; private set; }
        public string LocationMethod { get; private set; }
        public string SignalStrength { get; private set; }

        static void ValidateDouble(double value, double min, double max, string argName)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(argName);
        }
    }
}