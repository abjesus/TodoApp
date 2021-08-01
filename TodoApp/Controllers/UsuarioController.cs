using System.Web.Mvc;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrar(string fail)
        {
            if (!string.IsNullOrEmpty(fail))
                ViewBag.retornoLogin = "Usuário ou senha inválidos!"; RedirectToRoute("entrar");

            return View("login");
        }

        public ActionResult Autenticar(string email, string senha)
        {
            var resultado = _service.Autenticar(email, senha);

            if (resultado)
                return RedirectToRoute("todo");
            
            
            return RedirectToRoute("entrar", new { fail = "s" });
        }

        public ActionResult Sair()
        {
            return RedirectToRoute("entrar");
        }
    }
}
