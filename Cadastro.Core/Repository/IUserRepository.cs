using Cadastro.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Core.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
    }
}
