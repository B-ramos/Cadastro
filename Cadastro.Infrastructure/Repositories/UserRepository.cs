using Cadastro.Core.Entities;
using Cadastro.Core.Repository;
using Cadastro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CadastroDbContext _dbContext;

        public UserRepository(CadastroDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<User>> GetAllAsync()
        {
           return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
