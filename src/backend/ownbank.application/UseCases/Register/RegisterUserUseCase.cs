using ownbank.communication.Request;
using ownbank.exceptions.ExceptionBase;


namespace ownbank.application.UseCases.Register
{
    public class RegisterUserUseCase
    {
        public RequestRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            Validate(request);
           
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
