using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Domain.Interfaces
{
    public interface IRepositorio<T>
    {
        Task Incluir(T entidade);
        Task Alterar(T entidade);
        Task Excluir(T entidade);
        Task<T> ObterPorId(Guid id);
        Task<List<T>> ObterTodos(Guid idUsuario);
    }
}
