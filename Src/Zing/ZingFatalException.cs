using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Zing
{
    [Serializable]
    public class ZingFatalException : Exception
    {
        private readonly string _localizedMessage;

        public ZingFatalException(string message)
            : base(message)
        {
            _localizedMessage = message;
        }

        public ZingFatalException(string message, Exception innerException)
            : base(message, innerException)
        {
            _localizedMessage = message;
        }

        protected ZingFatalException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string LocalizedMessage { get { return _localizedMessage; } }
    }
}
