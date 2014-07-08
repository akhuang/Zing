using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Security;
using Zing.Environment.Configuration;
using Zing.Mvc;
using Zing.Logging;

namespace Zing.Security
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private readonly ShellSettings _setting;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IUser _signedInUser;
        private bool _isAuthenticated;

        public FormsAuthenticationService(ShellSettings settings, IHttpContextAccessor httpContextAccessor)
        {
            _setting = settings;
            _httpContextAccessor = httpContextAccessor;
            ExpirationTimeSpan = TimeSpan.FromDays(30);
        }

        public ILogger Logger { get; set; }

        public TimeSpan ExpirationTimeSpan { get; set; }

        #region IAuthenticationService Members

        public void SignIn(IUser user, bool createPersistentCookie)
        {
            var now = DateTime.Now;
            var userData = string.Concat(Convert.ToString(user.Id), ";", _setting.Name);

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
