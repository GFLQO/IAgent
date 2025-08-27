using IAgent.Application.Dtos;
using IAgent.Domain.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.UseCases.Agents.Queries
{
    public sealed class GetAgentByIdQueryHandler : IRequestHandler<GetAgentByIdQuery, AgentDto>
    {
        private readonly IAgentRepository _agentRepository;

        public GetAgentByIdQueryHandler(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<AgentDto> Handle(GetAgentByIdQuery request, CancellationToken cancellationToken)
        {
            if(String.IsNullOrWhiteSpace(request.Id))
                throw new ArgumentNullException(nameof(request.Id));

            var agent = await _agentRepository.GetByIdAsync(request.Id);
            var result = new AgentDto
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Configuration.Background,
                Job = agent.Job,
                DateOfBirth = DateTime.UtcNow
            };

            return result;
        }
    }
}
