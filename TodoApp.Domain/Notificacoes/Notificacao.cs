namespace TodoApp.Domain.Notificacoes
{
    public class Notificacao
    {
        public TipoNotificacao Tipo { get; }

        public string Mensagem { get; }

        public Notificacao(TipoNotificacao tipo, string mensagem)
        {
            Tipo = tipo;
            Mensagem = mensagem;
        }
    }

    public enum TipoNotificacao
    {
        Informacao = 1,
        Erro = 2
    }

}
