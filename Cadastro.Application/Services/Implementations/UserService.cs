using Cadastro.Application.InputModels;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Core.Entities;
using Cadastro.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserViewModel
            {
                Name = u.Name
            }).ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task Add(UserInputModel userInputModel)
        {
            var user = new User(userInputModel.Name, userInputModel.Email);

            await _userRepository.AddAsync(user);
        }
    }
}
