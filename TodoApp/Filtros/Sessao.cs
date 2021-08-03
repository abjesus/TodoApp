using System.Web;
using System.Web.Mvc;

namespace TodoApp.Filtros
{
    public class SessaoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult(HttpContext.Current.Request.ApplicationPath);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
