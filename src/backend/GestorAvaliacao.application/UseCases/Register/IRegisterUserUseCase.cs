using GestorAvaliacao.Communication.Request;
using GestorAvaliacao.Communication.Responses;

namespace GestorAvaliacao.Application.UseCases.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
