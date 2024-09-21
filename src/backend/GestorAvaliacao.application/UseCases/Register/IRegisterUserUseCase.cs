using GestorAvaliacao.Communication.Request;

namespace GestorAvaliacao.Application.UseCases.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<RequestRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
