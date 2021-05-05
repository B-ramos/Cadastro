using AutoMapper;
using Cadastro.Application.InputModels;
using Cadastro.Application.ViewModels;
using Cadastro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Helpers
{
    public class CadastroProfile : Profile
    {
        public CadastroProfile()
        {
            CreateMap<UserInputModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
