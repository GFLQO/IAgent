using AutoMapper;
using IAgent.Application.Abstractions.Bus;
using IAgent.Infra.Outbox.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Infra.Outbox.Process
{
    public class OutboxProcessor : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventPublisher _publisher;
        private readonly IOutboxRepository _outboxRepository;
        private readonly IMapper _mapper;

        public OutboxProcessor(IServiceProvider serviceProvider, IEventPublisher publisher, IOutboxRepository outboxRepository, IMapper mapper)
        {
            _outboxRepository = outboxRepository;
            _serviceProvider = serviceProvider;
            _publisher = publisher;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var messages = await _outboxRepository.GetUnprocessedMessagesAsync(stoppingToken);

                foreach (var msg in messages)
                {
                    var message = _mapper.Map<OutboxMessage>(msg);
                    await _publisher.PublishAsync(message.Type, message.Payload, stoppingToken);
                    message.MarkProcessed();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }

}
