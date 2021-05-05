using Cadastro.Application.InputModels;
using FluentValidation;

namespace Cadastro.Application.Validators
{
    public class UserValidator : AbstractValidator<UserInputModel>
    {

        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório.");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido.");
        }
    }
}
