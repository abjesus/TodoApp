using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data.Contexto;
using TodoApp.Data.Repositorios;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Notificacoes;
using TodoApp.Domain.Services;

namespace TodoApp.Tests.Services
{
    [TestClass]
    public class TodoServiceTest
    {
        [TestMethod]
        public async Task Todo_DeveCriar()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new TodoRepositorio(contexto);
            var service = new TodoService(repositorio, notificador);

            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await service.Incluir(todo);

            Assert.IsTrue(todo.Criacao != null);
        }

        [TestMethod]
        public async Task Todo_DeveAlterar()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new TodoRepositorio(contexto);
            var service = new TodoService(repositorio, notificador);

            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await service.Incluir(todo);

            Assert.IsTrue(todo.Criacao != null);

            await service.Alterar(todo);

            Assert.IsTrue(todo.Alteracao != null);
        }

        [TestMethod]
        public async Task Todo_DeveObterPorId()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new TodoRepositorio(contexto);
            var service = new TodoService(repositorio, notificador);

            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await service.Incluir(todo);

            Assert.IsTrue(todo.Criacao != null);

            var todoObtido = await service.ObterPorId(todo.Id);

            Assert.IsTrue(todoObtido != null);
        }

        [TestMethod]
        public async Task Todo_DeveObterTodos()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new TodoRepositorio(contexto);
            var service = new TodoService(repositorio, notificador);

            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await service.Incluir(todo);

            Assert.IsTrue(todo.Criacao != null);

            var todoObtido = await service.ObterTodos(usuarioId);

            Assert.IsTrue(todoObtido.Count > 0);
        }

        [TestMethod]
        public async Task Todo_DeveExcluir()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new TodoRepositorio(contexto);
            var service = new TodoService(repositorio, notificador);

            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await service.Incluir(todo);
            Assert.IsTrue(todo.Criacao != null);

            await service.Excluir(todo);

            todo = await service.ObterPorId(todo.Id);
            Assert.IsTrue(todo == null);
        }

        private async Task<Guid> CriarUsuario()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new UsuarioRepositorio(contexto);
            var service = new UsuarioService(repositorio, notificador);

            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await service.Incluir(usuario);

            return usuario.Id;
        }
    }
}
