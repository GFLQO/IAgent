using IAgent.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAgent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegistrationDto dto)
        {
            return CreatedAtAction(nameof(Register), new { }, null);
        }

    }
}
