using FluentValidation;
using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Validators
{
    public class TodoValidator : AbstractValidator<Todo>
    {
        public TodoValidator()
        {
            RuleFor(todo => todo.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(todo => todo.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(todo => todo.Vencimento)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
