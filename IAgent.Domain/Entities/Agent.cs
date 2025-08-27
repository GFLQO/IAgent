using IAgent.Domain.Enums;
using IAgent.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Domain.Entities
{
    public class Agent
    {

        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string Name { get; private set; }

        public AgentProvider Provider { get; private set; }

        public AgentStatus Status { get; private set; }

        public AgentConfiguration Configuration { get; private set; }

        public Experience Experience { get; private set; }

        public List<string> Skills { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public virtual Job Job { get; private set; }

        public Money PricePerHour { get; private set; }

        public Agent(string name, AgentProvider provider, Experience experience, List<string> skills, Job job, Money pricePerHour)
        {
            Name = name;
            Provider = provider;
            Experience = experience;
            Skills = skills;
            Job = job;
        }

        public void UpdateStatus(AgentStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateJob(Job job)
        {
            Job = job;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddSkill(string skill)
        {
            if (!string.IsNullOrWhiteSpace(skill) && !Skills.Contains(skill))
                Skills.Add(skill);
        }
    }
}
