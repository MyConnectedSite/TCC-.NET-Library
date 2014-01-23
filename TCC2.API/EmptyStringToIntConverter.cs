using System;
using System.Globalization;
using Newtonsoft.Json;

namespace TCC2.API
{
    /// <summary>
    /// Converts empty string to integer.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Workaround for this behavior: we expect integer in JSON but server returns empty string "".
    /// Old versions of Newtonsoft.JSON convert empty strings to <c>null</c> mistakenly but in 
    /// Newtonsoft.JSON 4.0 it was fixed.
    /// </para>
    /// <para>
    /// So now we introduce such converter to properly process this case.
    /// </para>
    /// </remarks>
    public sealed class EmptyStringToIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int) || objectType == typeof(int?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!CanConvert(objectType))
            {
                throw new ArgumentException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Type \"{0}\" is not supported by this converter", objectType));
            }

            if (reader.TokenType == JsonToken.Integer)
                return Convert.ToInt32(reader.Value);

            if (reader.TokenType == JsonToken.String)
            {
                string str = reader.Value.ToString();
                if (str == "")
                    return null;

                return int.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
            }

            throw new InvalidOperationException(
                String.Format(CultureInfo.InvariantCulture,
                "Unexpected token type when parsing {0}: {1}", objectType, reader.TokenType));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}