using System;
using System.Runtime.Serialization;

namespace PurrplingCore
{
    [Serializable]
    internal class ParseDateException : Exception
    {
        public ParseDateException()
        {
        }

        public ParseDateException(string message) : base(message)
        {
        }

        public ParseDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParseDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}