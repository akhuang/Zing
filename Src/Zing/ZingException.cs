using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Zing
{
    [Serializable]
    public class ZingException : ApplicationException
    {
        private readonly string _localizedMessage;

        public ZingException(string message)
            : base(message)
        {
            _localizedMessage = message;
        }

        public ZingException(string message, Exception innerException)
            : base(message, innerException)
        {
            _localizedMessage = message;
        }

        protected ZingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string LocalizedMessage { get { return _localizedMessage; } }
    }
}
