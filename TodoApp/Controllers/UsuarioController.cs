using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TodoApp.Domain.Interfaces;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;
        private readonly INotificador _notificador;

        public UsuarioController(IUsuarioService service, INotificador notificador)
        {
            _service = service;
            _notificador = notificador;
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
            var usuario = _service.Autenticar(email, senha);

            if (usuario == null)
                return RedirectToRoute("entrar", new { fail = "s" });

            Session["usuario"] = usuario.Id;
            Session["nome"] = usuario.Nome;

            return RedirectToRoute("todo");
        }

        public ActionResult Sair()
        {
            Session.Abandon();
            return RedirectToRoute("entrar");
        }

        public async Task<string> Inscrever(UsuarioViewModel usuario)
        {
            await _service.Incluir(usuario.ToDomain());

            return "";
        }
    }
}
