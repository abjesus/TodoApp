using System;
using TodoApp.Domain.Entidades;
using TodoApp.Enumeradores;

namespace TodoApp.ViewModels
{
    public class TodoViewModel
    {
        public Guid UsuarioId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime Vencimento { get; set; }

        public TodoStatus Status { get; set; }

        public Todo ToDomain()
        {
            return new Todo
            {
                UsuarioId = this.UsuarioId,
                Nome = this.Nome,
                Descricao = this.Descricao,
                Vencimento = this.Vencimento,
                Status = (Domain.Enumeradores.TodoStatus) this.Status
            };
        }

        public static TodoViewModel FromDomain(Todo todo)
        {
            return new TodoViewModel
            {
                UsuarioId = todo.UsuarioId,
                Nome = todo.Nome,
                Descricao = todo.Descricao,
                Vencimento = todo.Vencimento,
                Status = (TodoStatus) todo.Status
            };
        }
    }
}
