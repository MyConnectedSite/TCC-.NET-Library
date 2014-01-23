using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TCC2.API
{
    public static class IRequestDataProviderExtensions
    {
        public static IEnumerable<T> GetParameterValues<T>(this IRequestDataProvider provider, string parameter) where T : IConvertible
        {
            ValidateParameterName(parameter);
            return provider.Parameters.Where(item => item.Name == parameter).Select(item => (T)Convert.ChangeType(item.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        public static T GetParameterValue<T>(this IRequestDataProvider provider, string parameter) where T : IConvertible
        {
            return provider.GetParameterValues<T>(parameter).Single();
        }

        public static IEnumerable<DateTime> GetDateTimeParameterValues(this IRequestDataProvider provider, string parameter)
        {
            ValidateParameterName(parameter);
            return provider.Parameters.Where(item => item.Name == parameter).Select((item) => DateTime.ParseExact(item.Value, ApiCallBase.TccDateTimeFormat, CultureInfo.InvariantCulture));
        }

        public static DateTime GetDateTimeParameterValue(this IRequestDataProvider provider, string parameter)
        {
            return provider.GetDateTimeParameterValues(parameter).Single();
        }

        public static int GetParametersCount(this IRequestDataProvider provider, string parameter)
        {
            ValidateParameterName(parameter);
            return provider.Parameters.Count(item => item.Name == parameter);
        }

        static void ValidateParameterName(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Parameter name cannot be null or empty");
        }
    }
}