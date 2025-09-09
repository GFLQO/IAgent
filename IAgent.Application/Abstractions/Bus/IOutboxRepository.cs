using IAgent.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.Abstractions.Bus
{
    public interface IOutboxRepository
    {
        Task AddAsync(OutboxMessageDto message, CancellationToken cancellationToken);
        Task<List<OutboxMessageDto>> GetUnprocessedMessagesAsync(CancellationToken cancellationToken);
    }
}
