using IAgent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Domain.Interfaces.Services
{
    public interface IAgentService
    {
        public Agent GetByIdAsync(int id);
        public List<Agent> GetAsync();
        public Agent GetByIdString(string id);
        public Task<Agent> UpdateAsync(Agent agent);
        public Task<bool> DeleteByIdAsync(int id);
    }
}
