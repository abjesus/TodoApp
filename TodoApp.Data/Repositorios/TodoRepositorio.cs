using TodoApp.Data.Contexto;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Data.Repositorios
{
    public class TodoRepositorio : RepositorioBase<Todo>, ITodoRepositorio
    {
        public TodoRepositorio(DbContexto contexto) : base(contexto)
        {}
    }
}
