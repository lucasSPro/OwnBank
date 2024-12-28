using GestorAvaliacao.Domain.Repositories;

namespace GestorAvaliacao.Infrastructure.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestorAvaliacaoDBContext _dbContext;

        public UnitOfWork(GestorAvaliacaoDBContext dbContext) => _dbContext = dbContext;

        public async Task Commit()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
