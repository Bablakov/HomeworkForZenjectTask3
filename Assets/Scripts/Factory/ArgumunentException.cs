using System;
using System.Runtime.Serialization;

namespace Scripts.Factory
{
    [Serializable]
    internal class ArgumunentException : Exception
    {
        public ArgumunentException()
        {
        }

        public ArgumunentException(string message) : base(message)
        {
        }

        public ArgumunentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumunentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}