
using IAgent.Application.Abstractions.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Infra.EventBus
{
    public class KafkaEventBus : IEventBus
    {
        public KafkaEventBus() { }
        public Task PublishAsync<T>(T @event, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
