using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Security;
using Zing.Environment.Configuration;
using Zing.Mvc;
using Zing.Logging;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;

namespace Zing.Security
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private ShellSettings _setting;
        private IUser _signedInUser;
        private bool _isAuthenticated;

        public FormsAuthenticationService()
        {
            ExpirationTimeSpan = TimeSpan.FromDays(30);
        }

        public ILogger Logger { get; set; }

        public TimeSpan ExpirationTimeSpan { get; set; }

        #region IAuthenticationService Members

        public void SignIn(IUser user, bool createPersistentCookie)
        {
            var now = DateTime.Now;
            //var userData = string.Concat(Convert.ToString(user.Id), ";", _setting.Name);
            var userData = user.Id.ToString();
            var ticket = new FormsAuthenticationTicket(
                1,
                user.UserName,
                now,
                now.Add(ExpirationTimeSpan),
                createPersistentCookie,
                userData,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Secure = FormsAuthentication.RequireSSL,
                HttpOnly = true,
                Path = FormsAuthentication.FormsCookiePath
            };

            var httpContext = HttpContext.Current;

            //if (!string.IsNullOrEmpty(_setting.RequestUrlPrefix))
            //{
            //    cookie.Path = GetCookiePath(httpContext);
            //}

            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            if (createPersistentCookie)
            {
                cookie.Expires = ticket.Expiration;
            }

            httpContext.Response.Cookies.Add(cookie);

            _isAuthenticated = true;
            _signedInUser = user;

        }

        private string GetCookiePath(HttpContextBase httpContext)
        {
            var cookiePath = httpContext.Request.ApplicationPath;
            if (cookiePath != null && cookiePath.Length > 1)
            {
                cookiePath += '/';
            }

            //cookiePath += _setting.RequestUrlPrefix;

            return cookiePath;
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }

        public void SetAuthenticatedUserForRequest(IUser user)
        {
            throw new NotImplementedException();
        }

        public IUser GetAuthenticatedUser()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
