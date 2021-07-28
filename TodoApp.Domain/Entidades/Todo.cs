using System;
using TodoApp.Domain.Enumeradores;
using TodoApp.Domain.Validators;

namespace TodoApp.Domain.Entidades
{
    public class Todo : Entidade
    {
        public Guid UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime Vencimento { get; set; }

        public TodoStatus Status { get; set; }

        public override bool Validar()
        {
            Notificar(new TodoValidator().Validate(this));
            return !PossuiErros;
        }
    }
}
