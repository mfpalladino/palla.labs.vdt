using System;

namespace Palla.Labs.Vdt.App.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException()
        {
        }

        protected BaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BaseException(string message, string messageForApiClient, Exception innerException)
            : base(message, innerException)
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