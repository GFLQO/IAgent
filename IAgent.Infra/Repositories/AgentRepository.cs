using IAgent.Domain.Entities;
using IAgent.Domain.Interfaces.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Infra.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly MongoContext _context;
        public AgentRepository(MongoContext context) { }

        public async Task<bool> AddAsync(Agent agent)
        {
            await _context.Agents.InsertOneAsync(agent);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            var filter = Builders<Agent>.Filter.Eq(a => a.Id, id);
            await _context.Agents.DeleteOneAsync(filter);
            return true;
        }

        public async Task<Agent> GetByIdAsync(string id)
        {
            return await _context.Agents.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<Agent> UpdateAsync(Agent agent)
        {
            _context.Agents.UpdateOne(a => a.Id == agent.Id, Builders<Agent>.Update
                .Set(a => a.Name, agent.Name)
                .Set(a => a.UpdatedAt, DateTime.UtcNow)
            );
            return Task.FromResult(agent);
        }
    }
}
