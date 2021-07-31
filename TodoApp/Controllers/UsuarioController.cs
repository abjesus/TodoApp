using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ActionResult Autenticar(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.retornoLogin = "Usuário ou senha inválidos!";
                return View();
            }

            var resultado = _service.Autenticar(email, senha);

            if (!resultado)
            {
                ViewBag.retornoLogin = "Usuário ou senha inválidos!";
                return View();
            }

            return RedirectToRoute("todo");
        }

        public ActionResult Sair()
        {
            return View();
        }
    }
}
