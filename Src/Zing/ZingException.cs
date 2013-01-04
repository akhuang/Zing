using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard.Localization;
using System.Runtime.Serialization;

namespace Zing
{
    [Serializable]
    public class ZingException : ApplicationException
    {
        private readonly LocalizedString _localizedMessage;

        public ZingException(LocalizedString message)
            : base(message.Text)
        {
            _localizedMessage = message;
        }

        public ZingException(LocalizedString message, Exception innerException)
            : base(message.Text, innerException)
        {
            _localizedMessage = message;
        }

        protected ZingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public LocalizedString LocalizedMessage { get { return _localizedMessage; } }
    }
}
