
using GestorAvaliacao.Domain.Repositories.User;
using Moq;

namespace UtilidadesComumsTestes.Repositories
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;

        public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();

        public void ExistActiveUserWhitEmail(string email)
        {
            _repository.Setup(repository => repository.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
        }

        public  IUserReadOnlyRepository Build() => _repository.Object;
    }
}
