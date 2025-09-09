using IAgent.Application.Dtos;
using IAgent.Infra.Outbox.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Infra.Repositories
{
    public class OutboxRepository
    {
        private readonly MongoContext _context;
        public OutboxRepository(MongoContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(OutboxMessageDto message, CancellationToken cancellationToken)
        {
            var result = OutboxMessage.From(message);
            await _context.OutboxMessages.InsertOneAsync(result, null, cancellationToken);
        }

        public async Task<List<OutboxMessage>> GetUnprocessedMessagesAsync(CancellationToken cancellationToken)
        {
            return await _context.OutboxMessages.Find(m => !m.Processed).ToListAsync(cancellationToken);
        }

        public async Task MarkAsProcessedAsync(Guid messageId, CancellationToken cancellationToken) 
        {
            var filter = Builders<OutboxMessage>.Filter.Eq(m => m.Id, messageId);
            var update = Builders<OutboxMessage>.Update.Set(m => m.Processed, true);
            await _context.OutboxMessages.UpdateOneAsync(filter, update, null, cancellationToken);
        }
    }
}
