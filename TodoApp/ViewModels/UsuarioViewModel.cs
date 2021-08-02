using System.Collections.Generic;
using TodoApp.Domain.Entidades;
using TodoApp.Enumeradores;

namespace TodoApp.ViewModels
{
    public class UsuarioViewModel
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public UsuarioStatus Status { get; set; }

        public virtual List<TodoViewModel> Todos { get; set; }

        public Usuario ToDomain()
        {
            return new Usuario
            {
                Email = this.Email,
                Senha = this.Senha,
                Nome = this.Nome,
                Sobrenome = this.Sobrenome,
                Status = (Domain.Enumeradores.UsuarioStatus) this.Status,
            };
        }

        public static UsuarioViewModel FromDomain(Usuario usuario)
        {
            return new UsuarioViewModel
            {
                Email = usuario.Email,
                Senha = usuario.Senha,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Status = (UsuarioStatus) usuario.Status,
            };
        }
    }
}
