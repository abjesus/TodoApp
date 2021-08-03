using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Entidades;

namespace TodoApp.Domain.Interfaces
{
    public interface ITodoService
    {
        Task Incluir(Todo entidade);
        Task Alterar(Todo entidade);
        Task Excluir(Todo entidade);
        Task Excluir(Guid id);
        Task<Todo> ObterPorId(Guid id);
        Task<List<Todo>> ObterTodos(Guid idUsuario);
    }
}
