using System;

namespace Bookings.Engine.Domain.Bookings.Resource
{
    public class ResourceName : IEquatable<ResourceName>
    {
        private const int ResourceNameMinLen = 4;
        private readonly string _name;

        public ResourceName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (name.Length < ResourceNameMinLen)
                throw new DomainException("Resource name too short (min len = " + ResourceNameMinLen + ")");

            _name = name;
        }

        public bool Equals(ResourceName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ResourceName) obj);
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        public static bool operator ==(ResourceName left, ResourceName right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResourceName left, ResourceName right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}