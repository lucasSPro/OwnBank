using Microsoft.AspNetCore.Mvc;
using ownbank.communication.Request;
using ownbank.communication.Responses;

namespace ownbank.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseRegisteredUserJson))]
        public IActionResult Register([FromBody] RequestRegisterUserJson request)
        {
            
            return Created("", new ResponseRegisteredUserJson { Nome = request.Nome });
        }
    }
}
