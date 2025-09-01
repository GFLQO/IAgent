using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.Abstractions.Bus
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(string topic, T @event, CancellationToken ct);
    }

    public interface IEventConsumer
    {
        Task ConsumeAsync<T>(string topic, Func<T, Task> handler, CancellationToken ct);
    }
}
