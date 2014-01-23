using System;

namespace TCC2.API
{
    public struct ApiParameter : IEquatable<ApiParameter>
    {
        public ApiParameter(string name, string value)
            : this()
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }

        public bool Equals(ApiParameter other)
        {
            return Name == other.Name && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is ApiParameter)
                return Equals((ApiParameter)obj);

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            unchecked
            {
                if (Name != null)
                    hash = Name.GetHashCode();

                hash *= 53;

                if (Value != null)
                    hash += Value.GetHashCode();
            }
            return hash;
        }

        public static bool operator ==(ApiParameter first, ApiParameter second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(ApiParameter first, ApiParameter second)
        {
            return !(first == second);
        }
    }
}