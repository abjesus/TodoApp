using System.Threading.Tasks;
using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<bool> Autenticar(Usuario usuario);
    }
}
