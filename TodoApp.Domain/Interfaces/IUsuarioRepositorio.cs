using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario Autenticar(string email, string senha);
    }
}
