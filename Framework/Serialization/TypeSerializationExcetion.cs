using System;
using System.Runtime.Serialization;

namespace PurrplingCore.Framework.Serialization
{
    [Serializable]
    internal class TypeSerializationExcetion : Exception
    {

        public TypeSerializationExcetion()
        {
        }

        public TypeSerializationExcetion(Type serializedType) 
            : base($"Unresolvable type `{serializedType.FullName}, {serializedType.Assembly.FullName}`: This type is not known in type resolving registry.")
        {
        }

        public TypeSerializationExcetion(string message) : base(message)
        {
        }

        public TypeSerializationExcetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TypeSerializationExcetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}