using System.Web.Mvc;
using TodoApp.Data.Contexto;
using TodoApp.Data.Repositorios;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Notificacoes;
using TodoApp.Domain.Services;
using Unity;
using Unity.Mvc5;

namespace TodoApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterInstance(new DbContexto());

            container.RegisterType<INotificador, Notificador>();

            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>();
            container.RegisterType<ITodoRepositorio, TodoRepositorio>();

            container.RegisterType<IUsuarioService, UsuarioService>();
            container.RegisterType<ITodoService, TodoService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}