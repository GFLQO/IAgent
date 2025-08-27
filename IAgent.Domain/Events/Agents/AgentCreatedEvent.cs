using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Domain.Events.Agents
{
    public sealed record AgentCreatedEvent(string AgentId, string Name, DateTime CreatedAt);
}
