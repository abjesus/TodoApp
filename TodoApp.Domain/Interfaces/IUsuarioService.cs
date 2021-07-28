using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task Incluir(Usuario entidade);
        Task Alterar(Usuario entidade);
        Task Excluir(Usuario entidade);
        Task Excluir(Guid id);
        Task<Usuario> ObterPorId(Guid id);
        Task<IEnumerable<Usuario>> ObterTodos(Guid idUsuario);
        Task<bool> Autenticar(string email, string senha);
    }
}
