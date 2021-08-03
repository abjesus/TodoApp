using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Controllers;
using TodoApp.Data.Contexto;
using TodoApp.Data.Repositorios;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Notificacoes;
using TodoApp.Domain.Services;
using TodoApp.ViewModels;

namespace TodoApp.Tests.Controllers
{
    [TestClass]
    public class TodoControllerTest
    {
        private readonly ITodoService _todoService;
        private readonly IUsuarioService _usuarioService;
        private readonly TodoController _controller;

        public TodoControllerTest()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();

            var repositorio = new TodoRepositorio(contexto);
            var usuarioRepositorio = new UsuarioRepositorio(contexto);

            _todoService = new TodoService(repositorio, notificador);
            _usuarioService = new UsuarioService(usuarioRepositorio, notificador);

            _controller = new TodoController(_todoService);
        }

        [TestMethod]
        public async Task Todo_DeveCriar()
        {
            var usuarioId = await CriarUsuario();

            var todoViewModel = new TodoViewModel
            {
                Nome = "todo controller teste",
                Descricao = "todo controller descrição",
                Status = Enumeradores.TodoStatus.Pendente,
                Vencimento = DateTime.Now,
                UsuarioId = usuarioId
            };

            var retorno = await _controller.Incluir(todoViewModel);

            Assert.IsTrue(retorno != null);
        }

        [TestMethod]
        public async Task Todo_DeveAlterarStatus()
        {
            var usuarioId = await CriarUsuario();

            var todoViewModel = new TodoViewModel
            {
                Nome = "todo controller teste",
                Descricao = "todo controller descrição",
                Status = Enumeradores.TodoStatus.Pendente,
                Vencimento = DateTime.Now,
                UsuarioId = usuarioId
            };

            var retorno = await _controller.Incluir(todoViewModel);

            Assert.IsTrue(retorno != null);

            var alterado = await _controller.AlterarStatus(todoViewModel.Id, Enumeradores.TodoStatus.Concluido);

            Assert.IsTrue(alterado == 1);
        }

        private async Task<Guid> CriarUsuario()
        {
            var usuario = new Usuario
            {
                Email = "usuario@teste.com.br",
                Senha = "1234535",
                Nome = "Usuario",
                Sobrenome = "teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo
            };

            await _usuarioService.Incluir(usuario);

            return usuario.Id;
        }
    }
}
