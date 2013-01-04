using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Localization;
using System.Runtime.Serialization;

namespace Zing
{
    [Serializable]
    public class ZingCoreException : Exception
    {
        private readonly LocalizedString _localizedMessage;

        public ZingCoreException(LocalizedString message)
            : base(message.Text)
        {
            _localizedMessage = message;
        }

        public ZingCoreException(LocalizedString message, Exception innerException)
            : base(message.Text, innerException)
        {
            _localizedMessage = message;
        }

        protected ZingCoreException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public LocalizedString LocalizedMessage { get { return _localizedMessage; } }
    }
}
