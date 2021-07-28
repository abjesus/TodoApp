using System.Collections.Generic;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Notificacoes;

namespace TodoApp.Domain.Services
{
    public abstract class ServiceBase
    {
        private readonly INotificador _notificador;

        protected ServiceBase(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(TipoNotificacao tipo, string mensagem)
        {
            _notificador.Adicionar(new Notificacao(tipo, mensagem));
        }

        protected void Notificar(List<Notificacao> notificacoes)
        {
            notificacoes?.ForEach(notificacao => _notificador.Adicionar(notificacao));
        }
    }
}
