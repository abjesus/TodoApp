using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TodoApp.Controllers;
using TodoApp.Data.Contexto;
using TodoApp.Data.Repositorios;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Notificacoes;
using TodoApp.Domain.Services;

namespace TodoApp.Tests.Controllers
{
    [TestClass]
    public class UsuarioControllerTest
    {
        private readonly UsuarioController _usuarioController;
        private readonly IUsuarioService _usuarioService;

        public UsuarioControllerTest()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new UsuarioRepositorio(contexto);
            _usuarioService = new UsuarioService(repositorio, notificador);
            _usuarioController = new UsuarioController(_usuarioService);
        }

        [TestMethod]
        public async Task Usuario_DeveAutenticar()
        {
            // arrange

            await IncluirUsuario();

            // Act

            var view = _usuarioController.Autenticar("usuario@teste.com.br", "1234535") as ViewResult;

            // Assert

            Assert.IsNotNull(view);
        }

        private async Task IncluirUsuario()
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
        }
    }
}
