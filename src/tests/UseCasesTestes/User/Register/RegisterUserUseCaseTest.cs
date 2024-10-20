
using GestorAvaliacao.Application.UseCases.Register;
using FluentAssertions;
using UtilidadesComumsTestes.Cryptograpy;
using UtilidadesComumsTestes.Mapper;
using UtilidadesComumsTestes.Repositories;
using UtilidadesComunsTestes.Requests;
using AutoMapper.Configuration.Annotations;
using GestorAvaliacao.Exceptions.ExceptionBase;
using GestorAvaliacao.Exceptions;

namespace UseCasesTestes.User.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task RegisterUser_Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase();

            var result = await useCase.Execute(request);


            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
        }
        [Fact]
        public async Task Error_email_Alreay_Registered()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase(request.Email);

            Func<Task> act = async () => await useCase.Execute(request);

            (await act.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(e => e.ErrorMessages.Count == 1 && e.ErrorMessages.Contains(ResourceMessagesException.EMAIL_EXISTING));

        }

        private RegisterUserUseCase CreateUseCase(string? email = null)
        {
            var readRepositoryBilder = new UserReadOnlyRepositoryBuilder();
            var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var passwordEncrypter = PasswordEncripterBuilder.Build();
            var mapper = MapperBuilder.Build();

            if (string.IsNullOrEmpty(email) == false)
                readRepositoryBilder.ExistActiveUserWhitEmail(email);

            return new RegisterUserUseCase(readRepositoryBilder.Build(), writeRepository, unitOfWork, passwordEncrypter, mapper);
        }
    }
}
