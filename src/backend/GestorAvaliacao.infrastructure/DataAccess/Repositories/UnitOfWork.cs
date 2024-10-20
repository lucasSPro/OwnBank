using GestorAvaliacao.Domain.Repositories;

namespace GestorAvaliacao.Infrastructure.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestorAvaliacaoDBContext _dbContext;

        public UnitOfWork(GestorAvaliacaoDBContext dbContext) => _dbContext = dbContext;

        public async Task Commit()
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

    }
}
