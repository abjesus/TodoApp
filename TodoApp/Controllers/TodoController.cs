using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TodoApp.Domain.Interfaces;
using TodoApp.Enumeradores;
using TodoApp.Filtros;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService service)
        {
            _todoService = service;
        }

        [Sessao]
        public async Task<ActionResult> Index()
        {
            ViewBag.nomeUsuario = Session["nome"].ToString();
            var usuarioId = Guid.Parse(Session["usuario"].ToString());

            var todos = await _todoService.ObterTodos(usuarioId);
            var viewmodels = TodoViewModel.FromDomain(todos);
            
            return View(new TodosViewModel
            {
                Pendentes = viewmodels.Where(todo => todo.Status == Enumeradores.TodoStatus.Pendente).ToList(),
                EmAndamento = viewmodels.Where(todo => todo.Status == Enumeradores.TodoStatus.EmAndamento).ToList(),
                Finalizado = viewmodels.Where(todo => todo.Status == Enumeradores.TodoStatus.Concluido).ToList(),
            });
        }

        [Sessao]
        public async Task<ActionResult> Incluir(TodoViewModel todo)
        {
            todo.UsuarioId = Guid.Parse(Session["usuario"].ToString());
            await _todoService.Incluir(todo.ToDomain());
            return RedirectToRoute("todo");
        }

        [Sessao]
        public async Task<int> AlterarStatus(Guid todoId, TodoStatus status)
        {
            var todo = await _todoService.ObterPorId(todoId);
            todo.Status = (Domain.Enumeradores.TodoStatus) status;
            
            await _todoService.Alterar(todo);        

            return 1;
        }
    }
}
