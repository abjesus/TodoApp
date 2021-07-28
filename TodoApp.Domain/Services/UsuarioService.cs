using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Domain.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioService(IUsuarioRepositorio repositorio, INotificador notificador) : base(notificador)
        {
            _repositorio = repositorio;
        }

        public async Task Incluir(Usuario entidade)
        {
            if (!entidade.Validar())
            {
                Notificar(entidade.Notificacoes);
                return;
            }

            await _repositorio.Incluir(entidade);
        }

        public async Task Alterar(Usuario entidade)
        {
            if (!entidade.Validar())
            {
                Notificar(entidade.Notificacoes);
                return;
            }

            await _repositorio.Alterar(entidade);
        }

        public async Task Excluir(Usuario entidade)
        {
            await _repositorio.Excluir(entidade);
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _repositorio.ObterPorId(id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodos(Guid idUsuario)
        {
            return await _repositorio.ObterTodos(idUsuario);
        }

        public async Task<bool> Autenticar(string email, string senha)
        {
            return await _repositorio.Autenticar(email, senha);
        }

        public async Task Excluir(Guid id)
        {
            var entidade = await ObterPorId(id);
            await Excluir(entidade);
        }
    }
}
