using System.Web.Mvc;

namespace TodoApp.Controllers
{
    public class ErrosController : Controller
    {
        [ActionName("500")]
        public ActionResult Erro500()
        {
            return View("500");
        }

        [ActionName("404")]
        public ActionResult Erro404()
        {
            return View("404");
        }
    }
}
