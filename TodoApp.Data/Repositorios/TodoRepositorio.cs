using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Data.Contexto;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Data.Repositorios
{
    public class TodoRepositorio : RepositorioBase<Todo>, ITodoRepositorio
    {
        public TodoRepositorio(DbContexto contexto) : base(contexto)
        {}

        public async override Task<List<Todo>> ObterTodos(Guid idUsuario)
        {
            return await Contexto.Todos.Where(todo => todo.UsuarioId == idUsuario).ToListAsync();
        }
    }
}
