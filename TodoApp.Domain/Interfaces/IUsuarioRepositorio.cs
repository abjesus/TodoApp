using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        bool Autenticar(string email, string senha);
    }
}
