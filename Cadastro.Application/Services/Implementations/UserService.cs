using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var userViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return userViewModel.ToList();
            //return users.Select(u => new UserViewModel
            //{
            //    Name = u.Name
            //}).ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task Add(UserInputModel userInputModel)
        {
            var user = _mapper.Map<User>(userInputModel);
            await _userRepository.AddAsync(user);

            //var user1 = new User(userInputModel.Name, userInputModel.Email);
            //await _userRepository.AddAsync(user);
        }
    }
}
