using Microsoft.AspNetCore.Mvc;
using ownbank.Communication.Request;
using ownbank.Communication.Responses;
using ownbank.Application.UseCases.Register;

namespace ownbank.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody]RequestRegisterUserJson request
            )
        {
           

            var result = await useCase.Execute(request);   

            return Created(string.Empty, result);
        }
    }
}
