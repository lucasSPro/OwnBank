using Microsoft.EntityFrameworkCore;
using ownbank.Domain.Entities;
using ownbank.Domain.Repositories.User;

namespace ownbank.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly OwnbankDBContext _dbContext;

        public UserRepository(OwnbankDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user) 
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) );
        }
    }
}
