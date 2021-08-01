using System.Web.Mvc;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService service)
        {
            _todoService = service;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
