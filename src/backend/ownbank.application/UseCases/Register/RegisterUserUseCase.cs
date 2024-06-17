using AutoMapper;
using ownbank.Application.Services.AutoMapper;
using ownbank.Application.Services.Cryptography;
using ownbank.Communication.Request;
using ownbank.Domain.Repositories.User;
using ownbank.Exceptions.ExceptionBase;


namespace ownbank.Application.UseCases.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IMapper _mapper;
        public RegisterUserUseCase(
            IUserReadOnlyRepository userReadOnlyRepository, 
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IMapper mapper
            )
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _mapper = mapper;
        }
        public async Task<RequestRegisterUserJson> Execute(RequestRegisterUserJson request)
        {

            Validate(request);

            var passwordAPI = new PasswordEncripter();
            

            var user =  _mapper.Map<Domain.Entities.User>(request);

            user.Password =  passwordAPI.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user);
           
            return new RequestRegisterUserJson { Name = request.Name };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

    }
}
