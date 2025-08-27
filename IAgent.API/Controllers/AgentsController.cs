using IAgent.Application.Abstractions.Bus;
using IAgent.Domain.Entities;
using IAgent.Domain.Events.Agents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IAgent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly IEventPublisher _publisher;
        public AgentController(IEventPublisher publisher) 
        {
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agent>>> Get()
          => Ok(new List<Agent>());

        [HttpPost]
        public async Task<ActionResult<Agent>> Create([FromBody] Agent agent)
        {
            var result =  CreatedAtAction(nameof(GetById), new { id = agent.Id }, agent);

            await _publisher.PublishAsync("agent-created", new AgentCreatedEvent(agent.Id, agent.Name, DateTime.UtcNow), new CancellationToken());
            return result;
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
