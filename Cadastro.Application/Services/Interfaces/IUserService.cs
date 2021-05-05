using Cadastro.Application.InputModels;
using Cadastro.Application.ViewModels;
using Cadastro.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task Add(UserInputModel userInputModel);
    }
}
