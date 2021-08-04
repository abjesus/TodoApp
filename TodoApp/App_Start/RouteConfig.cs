using System.Web.Mvc;
using System.Web.Routing;

namespace TodoApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Entrar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "todo",
                url: "todo/index"
            );

            routes.MapRoute(
                name: "entrar",
                url: "usuario/entrar"
            );

            routes.MapRoute(
                name: "erro500",
                url: "erros/500"
            );

            routes.MapRoute(
                name: "erro404",
                url: "erros/404"
            );
        }
    }
}
