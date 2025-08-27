using IAgent.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAgent.Application.UseCases.Agents.Queries
{
    public sealed record GetAgentByIdQuery : IRequest<AgentDto>
    {
        public string Id { get; set; }
        public GetAgentByIdQuery(string id)
        {
            Id = id;
        }
    }
}
