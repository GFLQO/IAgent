using IAgent.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Infra.Outbox.Models
{
    public class OutboxMessage
    {
        public Guid Id { get; private set; }
        public DateTime OccurredOn { get; private set; }
        public string Type { get; private set; }
        public string Payload { get; private set; }
        public bool Processed { get; private set; }

        public OutboxMessage(Guid id, DateTime occurredOn, string type, string payload)
        {
            Id = id;
            OccurredOn = occurredOn;
            Type = type;
            Payload = payload;
            Processed = false;
        }

        public OutboxMessage(DateTime occurredOn, string type, string payload)
        {
            OccurredOn = occurredOn;
            Type = type;
            Payload = payload;
            Processed = false;
        }

        public void MarkProcessed() => Processed = true;

        public bool IsProcessed() => Processed;
        public static OutboxMessage From(OutboxMessageDto input)
        {
            return new OutboxMessage(input.OccurredOn, input.Type, input.Payload);
        }
    }

}
