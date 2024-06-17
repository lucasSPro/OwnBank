

using AutoMapper;
using ownbank.Communication.Request;

namespace ownbank.Application.Services.AutoMapper
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
