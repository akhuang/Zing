using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Security;

namespace Zing.Core.Security
{
    public class MembershipService : IMembershipService
    {
        public MembershipSettings GetSettings()
        {
            throw new NotImplementedException();
        }

        public IUser CreateUser(CreateUserParams createUserParams)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public IUser ValidateUser(string userNameOrEmail, string password)
        {
             
        }

        public void SetPassword(IUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
