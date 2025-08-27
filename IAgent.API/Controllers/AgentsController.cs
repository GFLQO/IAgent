using IAgent.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IAgent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        public AgentController() { }

        [HttpGet]
        public async Task<ActionResult<List<Agent>>> Get()
          => Ok(new List<Agent>());

        [HttpPost]
        public async Task<ActionResult<Agent>> Create([FromBody] Agent agent)
        {
            return CreatedAtAction(nameof(GetById), new { id = agent.Id }, agent);
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
