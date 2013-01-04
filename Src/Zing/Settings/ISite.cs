﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Settings
{
    /// <summary>
    /// Interface provided by the "settings" model.
    /// </summary>
    public interface ISite
    {
        string PageTitleSeparator { get; }
        string SiteName { get; }
        string SiteSalt { get; }
        string SuperUser { get; }
        string HomePage { get; set; }
        string SiteCulture { get; set; }
        ResourceDebugMode ResourceDebugMode { get; set; }
        int PageSize { get; set; }
        string BaseUrl { get; }
        string SiteTimeZone { get; }
    }
}
