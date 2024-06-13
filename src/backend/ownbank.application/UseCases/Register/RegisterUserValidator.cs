

using FluentValidation;
using ownbank.communication.Request;
using ownbank.exceptions;

namespace ownbank.application.UseCases.Register
{
    public class RegisterUserValidator: AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesExceptions.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesExceptions.EMAIL_EMPTY);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesExceptions.EMAIL_VALID);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesExceptions.PASSWORD_MIN_LENGHT);
        }

    }
}
