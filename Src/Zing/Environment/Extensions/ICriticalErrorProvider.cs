using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.Extensions
{
    public interface ICriticalErrorProvider
    {
        IEnumerable<string> GetErrors();

        /// <summary>
        /// Called by any to notice the system of a critical issue at the system level, e.g. incorrect extensions
        /// </summary>
        void RegisterErrorMessage(string message);

        /// <summary>
        /// Removes all error message
        /// </summary>
        void Clear();

    }

}
