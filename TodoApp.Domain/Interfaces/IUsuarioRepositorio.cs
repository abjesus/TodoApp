using System.Threading.Tasks;
using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<bool> Autenticar(string email, string senha);
    }
}
