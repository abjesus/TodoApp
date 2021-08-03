using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Domain.Services
{
    public class TodoService : ServiceBase, ITodoService
    {
        private readonly ITodoRepositorio _repositorio;

        public TodoService(ITodoRepositorio repositorio, INotificador notificador) : base(notificador)
        {
            _repositorio = repositorio;
        }

        public async Task Incluir(Todo entidade)
        {
            if (!entidade.Validar())
            {
                Notificar(entidade.Notificacoes);
                return;
            }

            await _repositorio.Incluir(entidade);
        }

        public async Task Alterar(Todo entidade)
        {
            if (!entidade.Validar())
            {
                Notificar(entidade.Notificacoes);
                return;
            }

            await _repositorio.Alterar(entidade);
        }

        public async Task Excluir(Todo entidade)
        {
            await _repositorio.Excluir(entidade);
        }

        public async Task<Todo> ObterPorId(Guid id)
        {
            return await _repositorio.ObterPorId(id);
        }

        public async Task<List<Todo>> ObterTodos(Guid idUsuario)
        {
            return await _repositorio.ObterTodos(idUsuario);
        }

        public async Task Excluir(Guid id)
        {
            var entidade = await ObterPorId(id);
            await Excluir(entidade);
        }
    }
}
