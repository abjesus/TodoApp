using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Domain.Notificacoes
{
    public class Notificador : INotificador
    {
        public List<Notificacao> Notificacoes { get; }

        public bool PossuiErros => Notificacoes.Where(n => n.Tipo != TipoNotificacao.Informacao).Any();

        public Notificador()
        {
            Notificacoes = new List<Notificacao>();
        }

        public void Adicionar(Notificacao notificacao)
        {
            Notificacoes.Add(notificacao);
        }
    }
}
