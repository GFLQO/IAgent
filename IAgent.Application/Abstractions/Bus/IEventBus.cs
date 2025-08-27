using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.Abstractions.Bus
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event, CancellationToken ct);
    }
}
