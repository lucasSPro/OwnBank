using Microsoft.AspNetCore.Mvc;
using ownbank.communication.Request;
using ownbank.communication.Responses;
using ownbank.application.UseCases.Register;

namespace ownbank.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
        public IActionResult Register( RequestRegisterUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var result = useCase.Execute(request);   

            return Created(string.Empty, result);
        }
    }
}
