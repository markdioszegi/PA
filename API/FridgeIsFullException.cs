using System;
using System.Runtime.Serialization;

namespace Refrigerator
{
    [Serializable]
    internal class FridgeIsFullException : Exception
    {
        public FridgeIsFullException()
        {
        }

        public FridgeIsFullException(string message) : base(message)
        {
        }

        public FridgeIsFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FridgeIsFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}