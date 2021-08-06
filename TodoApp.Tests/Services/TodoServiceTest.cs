using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TodoApp.Data.Contexto;
using TodoApp.Data.Repositorios;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Notificacoes;
using TodoApp.Domain.Services;

namespace TodoApp.Tests.Services
{
    [TestClass]
    public class TodoServiceTest
    {
        private readonly INotificador _notificador;
        private readonly ITodoService _service;
        private readonly IUsuarioService _usuarioService;

        public TodoServiceTest()
        {
            var contexto = new DbContexto();
            var repositorio = new TodoRepositorio(contexto);
            var usuarioRepositorio = new UsuarioRepositorio(contexto);

            _notificador = new Notificador();
            _service = new TodoService(repositorio, _notificador);
            _usuarioService = new UsuarioService(usuarioRepositorio, _notificador);
        }

        [TestMethod]
        public async Task Todo_DeveCriar()
        {
            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await _service.Incluir(todo);

            Assert.IsTrue(todo.Criacao != null);
        }

        [TestMethod]
        public async Task Todo_DeveAlterar()
        {
            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await _service.Incluir(todo);
            Assert.IsTrue(todo.Criacao != null);

            await _service.Alterar(todo);
            Assert.IsTrue(todo.Alteracao != null);
        }

        [TestMethod]
        public async Task Todo_DeveObterPorId()
        {
            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await _service.Incluir(todo);
            Assert.IsTrue(todo.Criacao != null);

            var todoObtido = await _service.ObterPorId(todo.Id);
            Assert.IsTrue(todoObtido != null);
        }

        [TestMethod]
        public async Task Todo_DeveObterTodos()
        {
            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await _service.Incluir(todo);
            Assert.IsTrue(todo.Criacao != null);

            var todoObtido = await _service.ObterTodos(usuarioId);
            Assert.IsTrue(todoObtido.Count > 0);
        }

        [TestMethod]
        public async Task Todo_DeveExcluir()
        {
            var usuarioId = await CriarUsuario();

            var todo = new Todo
            {
                Nome = "todo de teste",
                Descricao = "descricao do todo",
                Vencimento = DateTime.Now,
                Status = Domain.Enumeradores.TodoStatus.Pendente,
                UsuarioId = usuarioId
            };

            await _service.Incluir(todo);

            Assert.IsTrue(todo.Criacao != null);

            await _service.Excluir(todo);

            todo = await _service.ObterPorId(todo.Id);
            Assert.IsTrue(todo == null);
        }

        private async Task<Guid> CriarUsuario()
        {
            var usuario = new Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _usuarioService.Incluir(usuario);

            return usuario.Id;
        }
    }
}
