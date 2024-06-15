

using AutoMapper;
using ownbank.communication.Request;

namespace ownbank.application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping() 
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, domain.Entities.User>();
        }
    }
}
