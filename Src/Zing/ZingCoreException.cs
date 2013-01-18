using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Zing
{
    [Serializable]
    public class ZingCoreException : Exception
    {
        private readonly string _localizedMessage;

        public ZingCoreException(string message)
            : base(message)
        {
            _localizedMessage = message;
        }

        public ZingCoreException(string message, Exception innerException)
            : base(message, innerException)
        {
            _localizedMessage = message;
        }

        protected ZingCoreException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string LocalizedMessage { get { return _localizedMessage; } }
    }
}
