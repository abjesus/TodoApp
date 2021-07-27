using System;
using System.Collections.Generic;

namespace TodoApp.Domain.Interfaces
{
    public interface IRepositorio<T>
    {
        T Incluir(T entidade);
        T Alterar(T entidade);
        T Excluir(T entidade);
        T ObterPorId(Guid id);
        IEnumerable<T> ObterTodos(Guid idUsuario);
    }
}
