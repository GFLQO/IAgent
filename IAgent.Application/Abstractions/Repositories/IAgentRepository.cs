using IAgent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Domain.Interfaces.Repository
{
    public interface IAgentRepository
    {
        public Task<Agent> GetByIdAsync(string id);
        public Task<bool> AddAsync(Agent agent);
        public Task<Agent> UpdateAsync(Agent agent);
        public Task<bool> DeleteByIdAsync(string id);
    }
}
