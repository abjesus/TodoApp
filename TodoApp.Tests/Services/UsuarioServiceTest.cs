using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TodoApp.Data.Contexto;
using TodoApp.Data.Repositorios;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Notificacoes;
using TodoApp.Domain.Services;

namespace TodoApp.Tests.Services
{
    [TestClass]
    public class UsuarioServiceTest
    {
        private readonly INotificador _notificador;
        private readonly IUsuarioService _service;

        public UsuarioServiceTest()
        {
            var contexto = new DbContexto();
            var repositorio = new UsuarioRepositorio(contexto);

            _notificador = new Notificador();
            _service = new UsuarioService(repositorio, _notificador);
        }

        [TestMethod]
        public async Task Usuario_DeveCriarUsuario()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Incluir(usuario);

            Assert.IsTrue(usuario.Criacao != null);
        }

        [TestMethod]
        public async Task Usuario_DeveAlterarUsuario()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Incluir(usuario);
            Assert.IsTrue(usuario.Criacao != null);

            await _service.Alterar(usuario);
            Assert.IsTrue(usuario.Alteracao != null);
        }

        [TestMethod]
        public async Task Usuario_DeveObterUsuarioPorId()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Incluir(usuario);
            Assert.IsTrue(usuario.Criacao != null);

            usuario = await _service.ObterPorId(usuario.Id);
            Assert.IsTrue(usuario != null);
        }

        [TestMethod]
        public async Task Usuario_DeveObterUsuarios()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Incluir(usuario);
            Assert.IsTrue(usuario.Criacao != null);

            var usuarios = await _service.ObterTodos(usuario.Id);
            Assert.IsTrue(usuarios.Count > 0);
        }

        [TestMethod]
        public async Task Usuario_DeveExcluirUsuario()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Incluir(usuario);
            Assert.IsTrue(usuario.Criacao != null);

            await _service.Excluir(usuario);

            usuario = await _service.ObterPorId(usuario.Id);
            Assert.IsTrue(usuario == null);
        }

        [TestMethod]
        public async Task Usuario_DeveAutenticar()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@gmail.com",
                Senha = "12345",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Incluir(usuario);
            Assert.IsTrue(usuario.Criacao != null);

            var usuarioAuth = _service.Autenticar(usuario.Email, usuario.Senha);
            Assert.IsTrue(usuarioAuth != null);
        }

        [TestMethod]
        public async Task Usuario_DeveNotificarErroIncluir()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@.com",
                Senha = "",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Incluir(usuario);

            Assert.IsTrue(_notificador.PossuiErros);
        }

        [TestMethod]
        public async Task Usuario_DeveNotificarErroAlterar()
        {
            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@.com",
                Senha = "",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await _service.Alterar(usuario);

            Assert.IsTrue(_notificador.PossuiErros);
        }

    }
}
