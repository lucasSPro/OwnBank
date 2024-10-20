﻿using Microsoft.EntityFrameworkCore;
using GestorAvaliacao.Domain.Entities;
using GestorAvaliacao.Domain.Repositories.User;

namespace GestorAvaliacao.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly GestorAvaliacaoDBContext _dbContext;

        public UserRepository(GestorAvaliacaoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user) => await _dbContext.User.AddAsync(user);

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.User.AnyAsync(user => user.Email.Equals(email) );
        }
    }
}
