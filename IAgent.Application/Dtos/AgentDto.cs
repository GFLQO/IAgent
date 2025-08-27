using IAgent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.Dtos
{
    public class AgentDto
    {
        public AgentDto() { }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Job Job { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
