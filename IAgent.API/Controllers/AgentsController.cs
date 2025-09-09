using IAgent.Application.Abstractions.Bus;
using IAgent.Application.UseCases.Agents.Commands.Create;
using IAgent.Domain.Entities;
using IAgent.Domain.Events.Agents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IAgent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly IEventPublisher _publisher;
        private readonly IMediator _mediator;
        public AgentController(IEventPublisher publisher, IMediator mediator)
        {
            _publisher = publisher;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agent>>> Get()
          => Ok(new List<Agent>());

        [HttpPost]
        public async Task<ActionResult<Agent>> Create([FromBody] CreateAgentCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetById(int id)
        {

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Agent dto)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
