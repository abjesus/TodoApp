using System.Web.Mvc;

namespace TodoApp.Filtros
{
    public class ErroAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectToRouteResult("erro500", null);
            }
        }
    }
}
