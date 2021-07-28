using FluentValidation.Results;
using System;
using System.Collections.Generic;
using TodoApp.Domain.Interfaces;
using TodoApp.Domain.Notificacoes;

namespace TodoApp.Domain.Entidades
{
    public abstract class Entidade
    {
        private readonly INotificador _notificador;

        protected bool PossuiErros => _notificador.PossuiErros;

        public List<Notificacao> Notificacoes => _notificador.Notificacoes;

        public Guid Id { get; set; }

        public DateTime? Criacao { get; set; }

        public DateTime? Alteracao { get; set; }

        public Guid? UsuarioCriacao { get; set; }

        public Guid? UsuarioAlteracao { get; set; }

        public Entidade()
        {
            Id = Guid.NewGuid();

            _notificador = new Notificador();
        }

        protected void Notificar(ValidationResult validationResult)
        {
            validationResult.Errors?
                .ForEach(error => Notificar(TipoNotificacao.Erro, error.ErrorMessage));
        }

        protected void Notificar(TipoNotificacao tipo, string mensagem)
        {
            _notificador.Adicionar(new Notificacao(tipo, mensagem));
        }

        public abstract bool Validar();
    }
}
