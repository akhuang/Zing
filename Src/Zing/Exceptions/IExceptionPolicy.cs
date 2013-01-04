using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Exceptions
{
    public interface IExceptionPolicy : ISingletonDependency
    {
        /* return false if the exception should be rethrown by the caller */
        bool HandleException(object sender, Exception exception);
    }
}
