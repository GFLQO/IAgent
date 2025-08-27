using IAgent.Application.Dtos;
using IAgent.Domain.Entities;
using IAgent.Domain.Enums;
using IAgent.Domain.Interfaces.Repository;
using IAgent.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.UseCases.Agents.Commands.Create
{
    public sealed class CreateAgentHandler : IRequestHandler<CreateAgentCommand, AgentDto>
    {
        private readonly IAgentRepository _agentRepository;
        public CreateAgentHandler(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<AgentDto> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            Agent agent = new Agent(
                name: request.Name,
                experience: Experience.Junior,
                provider: request.provider,
                skills: new List<string>(),
                job: new Job(),
                pricePerHour: new Money(10, "Euros")
            );

            await _agentRepository.AddAsync(agent);

            return new AgentDto
            {
                Id = agent.Id,
                Job = agent.Job,
                Description = agent.Configuration.Background,
                Name = agent.Name,
                DateOfBirth = DateTime.UtcNow 
            };
        }
    }
}
