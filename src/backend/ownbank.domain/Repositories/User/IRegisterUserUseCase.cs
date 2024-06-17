using ownbank.Communication.Request;
using ownbank.Communication.Responses;

namespace ownbank.Domain.Repositories.User
{
    internal interface IRegisterUserUseCase
    {
        public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
