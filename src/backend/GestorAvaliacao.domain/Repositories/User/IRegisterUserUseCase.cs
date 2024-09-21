using GestorAvaliacao.Communication.Request;
using GestorAvaliacao.Communication.Responses;

namespace GestorAvaliacao.Domain.Repositories.User
{
    internal interface IRegisterUserUseCase
    {
        public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
