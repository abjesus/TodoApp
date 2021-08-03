using System.Linq;
using TodoApp.Data.Contexto;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Data.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContexto contexto) : base(contexto)
        {}

        public Usuario Autenticar(string email, string senha)
        {
            return Contexto
                .Usuarios
                .Where(usuario => usuario.Email.Equals(email) && usuario.Senha.Equals(senha))
                .FirstOrDefault();
        }
    }
}
