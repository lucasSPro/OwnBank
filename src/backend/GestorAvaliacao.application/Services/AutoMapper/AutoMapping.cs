

using AutoMapper;
using GestorAvaliacao.Communication.Request;

namespace GestorAvaliacao.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping() 
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, Domain.Entities.User>();
        }
    }
}
