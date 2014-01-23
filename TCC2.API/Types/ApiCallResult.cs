using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TCC2.API
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApiCallResult : IApiCallResult
    {
        [JsonProperty(PropertyName = "success", Required = Required.Always)]
        protected bool Success { get; private set; }

        [JsonProperty(PropertyName = "errorid")]
        protected string ErrorId { get; private set; }

        [JsonProperty(PropertyName = "message")]
        protected string Message { get; private set; }

        public static void Validate(IRequestDataProvider provider, bool success, string errorId, string message)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!success)
                throw new TccException(message, errorId);
        }

        public static void ValidateHasValue(string value, string displayName)
        {
            if (String.IsNullOrEmpty(value))
                ThrowInvalidMemberValueException(displayName);
        }

        public static void ValidateHasValue(object value, string displayName)
        {
            if (value == null)
                ThrowInvalidMemberValueException(displayName);
        }

        public static void ValidateValueMatchesInputParam<T>(T value, IRequestDataProvider provider, string paramName, string displayName) where T : IConvertible
        {
            bool paramExists = provider.GetParameterValues<T>(paramName).Any();
            if (paramExists)
            {
                T originalValue = provider.GetParameterValue<T>(paramName);
                if (!originalValue.Equals(value))
                    throw new TccException(String.Format(CultureInfo.InvariantCulture, "Invalid {0} value returned in response (expected value {1}, but was {2})", displayName, originalValue, value), true);
            }
        }

        protected virtual void ValidateInstance(IRequestDataProvider provider)
        {
            Validate(provider, Success, ErrorId, Message);
        }

        void IApiCallResult.Validate(IRequestDataProvider provider)
        {
            ValidateInstance(provider);
        }

        static void ThrowInvalidMemberValueException(string displayName)
        {
            if (String.IsNullOrEmpty(displayName))
                throw new TccException("Invalid property value of result returned in response", true);

            throw new TccException(
                String.Format(CultureInfo.InvariantCulture,
                "Invalid {0} returned in response", displayName), true);
        }
    }
}
