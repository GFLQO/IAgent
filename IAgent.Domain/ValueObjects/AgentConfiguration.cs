using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Domain.ValueObjects
{
    public sealed class AgentConfiguration : IEquatable<AgentConfiguration>
    {
        public double Temperature { get; }
        public int MaxTokens { get; }
        public string Background { get; }

        public AgentConfiguration(double temperature, int maxTokens, string background)
        {
            if (temperature < 0 || temperature > 1)
                throw new ArgumentException("Temperature must be between 0 and 1");
            if (maxTokens <= 0)
                throw new ArgumentException("MaxTokens must be greater than 0");
            if (string.IsNullOrWhiteSpace(background))
                throw new ArgumentException("Background required");

            Temperature = temperature;
            MaxTokens = maxTokens;
            Background = background;
        }
        
        public bool Equals(AgentConfiguration? other) =>
            other is not null &&
            Temperature.Equals(other.Temperature) &&
            MaxTokens == other.MaxTokens &&
            Background == other.Background;

        public override bool Equals(object? obj) => Equals(obj as AgentConfiguration);
        public override int GetHashCode() => HashCode.Combine(Temperature, MaxTokens, Background);
    }

}
