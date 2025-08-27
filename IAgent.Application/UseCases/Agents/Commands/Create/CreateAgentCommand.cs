using IAgent.Application.Dtos;
using IAgent.Domain.Enums;
using MediatR;

namespace IAgent.Application.UseCases.Agents.Commands.Create;

public sealed record CreateAgentCommand(string Name, AgentProvider provider, string description) : IRequest<AgentDto>;
