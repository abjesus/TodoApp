using System.Collections.Generic;
using TodoApp.Domain.Notificacoes;

namespace TodoApp.Domain.Interfaces
{
    public interface INotificador
    {
        List<Notificacao> Notificacoes { get; }
        bool PossuiErros { get; }
        void Adicionar(Notificacao notificacao);
    }
}
