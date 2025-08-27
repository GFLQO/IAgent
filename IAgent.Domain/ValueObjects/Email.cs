using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Domain.ValueObjects
{
    public sealed class Email : IEquatable<Email>
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email");
            Value = value;
        }

        public bool Equals(Email? other) => Value == other?.Value;
        public override bool Equals(object? obj) => Equals(obj as Email);
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }

}
