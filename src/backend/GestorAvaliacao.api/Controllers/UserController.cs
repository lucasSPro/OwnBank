using Microsoft.AspNetCore.Mvc;
using GestorAvaliacao.Communication.Request;
using GestorAvaliacao.Communication.Responses;
using GestorAvaliacao.Application.UseCases.Register;

namespace GestorAvaliacao.Api.Controllers
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
