using GestorAvaliacao.Domain.Repositories.User;
using Moq;

namespace UtilidadesComumsTestes.Repositories
{
    public class UserWriteOnlyRepositoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            var mock = new Mock<IUserWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
