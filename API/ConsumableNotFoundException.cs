using System;
using System.Runtime.Serialization;

namespace Refrigerator
{
    [Serializable]
    internal class ConsumableNotFoundException : Exception
    {
        public ConsumableNotFoundException()
        {
        }

        public ConsumableNotFoundException(string message) : base(message)
        {
        }

        public ConsumableNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConsumableNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}