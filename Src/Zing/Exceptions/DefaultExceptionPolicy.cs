using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.UI.Notify;
using Zing.Logging;

namespace Zing.Exceptions
{
    public class DefaultExceptionPolicy : IExceptionPolicy
    {

        public bool HandleException(object sender, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
