using ownbank.Communication.Request;

namespace ownbank.Application.UseCases.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<RequestRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
