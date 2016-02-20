using System;

namespace Palla.Labs.Vdt.App.Dominio.Excecoes
{
    public abstract class ExcecaoBase : Exception
    {
        protected ExcecaoBase()
        {
        }

        protected ExcecaoBase(string mensagem)
            : base(mensagem, null)
        {
        }

        protected ExcecaoBase(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {
        }

        protected ExcecaoBase(string mensagem, string messageForApiClient)
            : this(mensagem, messageForApiClient, null)
        {
        }

        protected ExcecaoBase(string mensagem, string messageForApiClient, Exception innerException)
            : base(mensagem, innerException)
        {
            MessageForApiClient = messageForApiClient;
        }

        public bool ContainsMessageForApiClient
        {
            get { return !String.IsNullOrWhiteSpace(MessageForApiClient); }
        }

        public string MessageForApiClient { get; protected set; }
    }
}