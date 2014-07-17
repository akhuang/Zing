using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Zing.Utility.Extensions
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Returns wether the specified url is local to the host or not
        /// </summary>
        /// <param name="request"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsLocalUrl(this HttpRequestBase request, string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            if (url.StartsWith("~/"))
            {
                return true;
            }

            if (url.StartsWith("//") || url.StartsWith("/\\"))
            {
                return false;
            }

            // at this point is the url starts with "/" it is local
            if (url.StartsWith("/"))
            {
                return true;
            }

            // at this point, check for an fully qualified url
            try
            {
                var uri = new Uri(url);
                if (uri.Authority.Equals(request.Headers["Host"], StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                // finally, check the base url from the settings
                //var workContext = request.RequestContext.GetWorkContext();
                //if (workContext != null)
                //{
                //    var baseUrl = workContext.CurrentSite.BaseUrl;
                //    if (!string.IsNullOrWhiteSpace(baseUrl))
                //    {
                //        if (uri.Authority.Equals(new Uri(baseUrl).Authority, StringComparison.OrdinalIgnoreCase))
                //        {
                //            return true;
                //        }
                //    }
                //}

                return false;
            }
            catch
            {
                // mall-formed url e.g, "abcdef"
                return false;
            }

        }
    }
}
