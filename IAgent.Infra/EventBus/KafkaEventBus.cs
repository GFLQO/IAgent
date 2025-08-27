
using Confluent.Kafka;
using IAgent.Application.Abstractions.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IAgent.Infra.EventBus
{
    public class KafkaEventPublisher : IEventPublisher
    {
        private readonly IProducer<string, string> _producer;

        public KafkaEventPublisher(string bootstrapServers)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task PublishAsync<T>(string topic, T @event, CancellationToken ct)
        {
            var json = JsonSerializer.Serialize(@event);
            await _producer.ProduceAsync(topic,
                new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json }, ct);
        }
    }

    public class KafkaEventConsumer : IEventConsumer
    {
        private readonly ConsumerConfig _config;

        public KafkaEventConsumer(string bootstrapServers, string groupId)
        {
            _config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        public async Task ConsumeAsync<T>(string topic, Func<T, Task> handler, CancellationToken ct)
        {
            using var consumer = new ConsumerBuilder<string, string>(_config).Build();
            consumer.Subscribe(topic);

            try
            {
                while (!ct.IsCancellationRequested)
                {
                    var result = consumer.Consume(ct);
                    var obj = JsonSerializer.Deserialize<T>(result.Message.Value);
                    if (obj is not null)
                        await handler(obj);
                }
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
