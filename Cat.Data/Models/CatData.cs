using System;

namespace Cat.Data.Models
{
    public class CatData : IEquatable<CatData>
    {
        private readonly string _name;
        private readonly int _age;
        private readonly Classification _classification;

        public CatData(string name, int age, Classification classification)
        {
            _name = name;
            _age = age;
            _classification = classification;
        }

        public bool Equals(CatData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _name == other._name && _age == other._age && _classification == other._classification;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CatData)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _age;
                hashCode = (hashCode * 397) ^ (int)_classification;
                return hashCode;
            }
        }
    }
}