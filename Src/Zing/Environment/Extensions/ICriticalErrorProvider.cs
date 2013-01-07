﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Localization;

namespace Zing.Environment.Extensions
{
    public interface ICriticalErrorProvider
    {
        IEnumerable<LocalizedString> GetErrors();

        /// <summary>
        /// Called by any to notice the system of a critical issue at the system level, e.g. incorrect extensions
        /// </summary>
        void RegisterErrorMessage(LocalizedString message);

        /// <summary>
        /// Removes all error message
        /// </summary>
        void Clear();

    }
}
