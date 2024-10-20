
using Moq;
using GestorAvaliacao.Domain.Repositories;

namespace UtilidadesComumsTestes.Repositories
{
    public static class UnitOfWorkBuilder
    {
        public static IUnitOfWork Build()
        {
            var mock = new Mock<IUnitOfWork>();

            return mock.Object;
        }

    }
}
