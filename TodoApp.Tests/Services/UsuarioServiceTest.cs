using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data.Contexto;
using TodoApp.Data.Repositorios;
using TodoApp.Domain.Notificacoes;
using TodoApp.Domain.Services;

namespace TodoApp.Tests.Services
{
    [TestClass]
    public class UsuarioServiceTest
    {
        [TestMethod]
        public async Task Usuario_DeveCriarUsuario()
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

            Assert.IsTrue(usuario.Criacao != null);
        }

        [TestMethod]
        public async Task Usuario_DeveAlterarUsuario()
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
            Assert.IsTrue(usuario.Criacao != null);

            await service.Alterar(usuario);
            Assert.IsTrue(usuario.Alteracao != null);
        }

        [TestMethod]
        public async Task Usuario_DeveObterUsuarioPorId()
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
            Assert.IsTrue(usuario.Criacao != null);

            usuario = await service.ObterPorId(usuario.Id);
            Assert.IsTrue(usuario != null);
        }

        [TestMethod]
        public async Task Usuario_DeveObterUsuarios()
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
            Assert.IsTrue(usuario.Criacao != null);

            var usuarios = await service.ObterTodos(usuario.Id);
            Assert.IsTrue(usuarios.Count > 0);
        }

        [TestMethod]
        public async Task Usuario_DeveExcluirUsuario()
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
            Assert.IsTrue(usuario.Criacao != null);

            await service.Excluir(usuario);

            usuario = await service.ObterPorId(usuario.Id);
            Assert.IsTrue(usuario == null);
        }

        [TestMethod]
        public async Task Usuario_DeveAutenticar()
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
            Assert.IsTrue(usuario.Criacao != null);

            var usuarioAuth = service.Autenticar(usuario.Email, usuario.Senha);
            Assert.IsTrue(usuarioAuth != null);
        }

        [TestMethod]
        public async Task Usuario_DeveNotificarErroIncluir()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new UsuarioRepositorio(contexto);
            var service = new UsuarioService(repositorio, notificador);

            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@.com",
                Senha = "",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await service.Incluir(usuario);

            Assert.IsTrue(notificador.PossuiErros);
        }

        [TestMethod]
        public async Task Usuario_DeveNotificarErroAlterar()
        {
            var notificador = new Notificador();
            var contexto = new DbContexto();
            var repositorio = new UsuarioRepositorio(contexto);
            var service = new UsuarioService(repositorio, notificador);

            var usuario = new Domain.Entidades.Usuario
            {
                Email = "exemplo@.com",
                Senha = "",
                Nome = "Abel",
                Sobrenome = "Teste",
                Status = Domain.Enumeradores.UsuarioStatus.Ativo,
            };

            await service.Alterar(usuario);

            Assert.IsTrue(notificador.PossuiErros);
        }

    }
}
