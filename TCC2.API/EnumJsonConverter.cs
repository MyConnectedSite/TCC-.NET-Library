using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TCC2.API
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumFieldAliasAttribute : Attribute
    {
        public EnumFieldAliasAttribute(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
    public sealed class EnumAliasesComparisonAttribute : Attribute
    {
        public EnumAliasesComparisonAttribute(StringComparison aliasComparison)
        {
            AliasComparison = aliasComparison;
        }

        public StringComparison AliasComparison { get; private set; }
    }

    public class EnumTypeConverter<T> : JsonConverter where T : struct, IConvertible, IComparable, IFormattable
    {
        List<KeyValuePair<string, T>> m_MappingCache = new List<KeyValuePair<string, T>>();
        StringComparison m_Comparison;

        public EnumTypeConverter()
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException(
                    String.Format(CultureInfo.InvariantCulture,
                    "Generic parameter of the class was not defined properly: type {0} is not enum", typeof(T)));
            }

            EnumAliasesComparisonAttribute comparisonAttr = typeof(T).GetCustomAttributes(typeof(EnumAliasesComparisonAttribute), false).Cast<EnumAliasesComparisonAttribute>().SingleOrDefault();
            if (comparisonAttr != null)
                m_Comparison = comparisonAttr.AliasComparison;

            foreach (FieldInfo fieldInfo in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                EnumFieldAliasAttribute attribute = fieldInfo.GetCustomAttributes(typeof(EnumFieldAliasAttribute), false).Cast<EnumFieldAliasAttribute>().SingleOrDefault();
                if (attribute == null || String.IsNullOrEmpty(attribute.Alias))
                    continue;

                m_MappingCache.Add(new KeyValuePair<string, T>(attribute.Alias, (T)fieldInfo.GetValue(null)));
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T) || objectType == typeof(T?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(T?))
                return ReadJsonAsNullableEnum(reader, objectType, existingValue, serializer);

            if (objectType == typeof(T))
                return ReadJsonAsEnum(reader, objectType, existingValue, serializer);

            throw new ArgumentException(
                String.Format(CultureInfo.InvariantCulture,
                "Type \"{0}\" is not supported by this converter", objectType));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
                writer.WriteValue(ConvertEnumToString((T)value));
            else
                writer.WriteNull();
        }

        object ReadJsonAsNullableEnum(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            return ReadJsonAsEnum(reader, objectType, existingValue, serializer);
        }

        object ReadJsonAsEnum(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                return ConvertStringToEnum(reader.Value.ToString());

            throw new InvalidOperationException(
                String.Format(CultureInfo.InvariantCulture,
                "Unexpected token type when parsing {0}: {1}", objectType, reader.TokenType));
        }

        T ConvertStringToEnum(string value)
        {
            int index = m_MappingCache.FindIndex(item => String.Equals(value, item.Key, m_Comparison));
            if (index < 0)
                throw CreateUnknownValueException(value);

            return m_MappingCache[index].Value;
        }

        string ConvertEnumToString(T value)
        {
            int index = m_MappingCache.FindIndex(item => item.Value.CompareTo(value) == 0);
            if (index < 0)
                throw CreateUnknownValueException(value);

            return m_MappingCache[index].Key;
        }

        static Exception CreateUnknownValueException(object value)
        {
            return new ArgumentException(String.Format(CultureInfo.InvariantCulture, "Value '{0}' is not defined for enum type {1}", value, typeof(T)));
        }
    }
}