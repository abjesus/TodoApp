using FluentValidation;
using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(usuario => usuario.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} deve estar no formato de email. (exemplo@email.com)");

            RuleFor(usuario => usuario.Senha)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(usuario => usuario.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(usuario => usuario.Sobrenome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
