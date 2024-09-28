using FluentAssertions;
using GestorAvaliacao.Application.UseCases.Register;
using GestorAvaliacao.Exceptions;
using UtilidadesComunsTestes.Requests;


namespace Validador.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        
    }
}
