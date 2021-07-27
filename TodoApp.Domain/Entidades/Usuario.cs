using System.Collections.Generic;
using TodoApp.Domain.Enumeradores;
using TodoApp.Domain.Validators;

namespace TodoApp.Domain.Entidades
{
    public class Usuario : Entidade
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public UsuarioStatus Status { get; set; }

        public virtual List<Todo> Todos { get; set; }

        public override bool Validar()
        {
            Notificar(new UsuarioValidator().Validate(this));
            return !PossuiErros;
        }
    }
}
