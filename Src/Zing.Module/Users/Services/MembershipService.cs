using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using Zing.Framework.Security;
using Zing.Logging;
using Zing.Modules.Users.Models;
using Zing.Modules.Users.Repositories;

namespace Zing.Modules.Users.Services
{
    public class MembershipService : ServiceBase<UserEntity>, IMembershipServiceInModule
    {
        private IMembershipRepository _userRep;
        public new ILogger Logger { get; set; }

        public MembershipService(IMembershipRepository userRep)
            : base(userRep)
        {
            _userRep = userRep;
            Logger = NullLogger.Instance;
        }

        public MembershipSettings GetSettings()
        {
            throw new NotImplementedException();
        }

        public IUser CreateUser(CreateUserParams createUserParams)
        {
            UserEntity model = new UserEntity();

            model.NormalizedUserName = createUserParams.NormalizedUserName;
            model.UserName = createUserParams.Username;
            model.Email = createUserParams.Email;
            model.HashAlgorithm = "SHA1";
            SetPassword(model, createUserParams.Password);
            return _userRep.Add(model);
        }

        public IEnumerable<UserEntity> Get()
        {
            var userList = base.Fetch(x => x.Email == "hf.com");
            return userList;
        }

        private void SetPassword(UserEntity model, string password)
        {
            SetPasswordHashed(model, password);
        }

        private void SetPasswordHashed(UserEntity model, string password)
        {
            var saltBytes = new byte[0x10];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetBytes(saltBytes);
            }

            var passwordBytes = Encoding.Unicode.GetBytes(password);

            var combinedBytes = saltBytes.Concat(passwordBytes).ToArray();

            byte[] hashBytes;
            using (var hashAlgorithm = HashAlgorithm.Create(model.HashAlgorithm))
            {
                hashBytes = hashAlgorithm.ComputeHash(combinedBytes);
            }

            model.PasswordFormat = MembershipPasswordFormat.Hashed;
            model.Password = Convert.ToBase64String(hashBytes);
            model.PasswordSalt = Convert.ToBase64String(saltBytes);
        }

        public IUser GetUser(string userName)
        {
            Logger.Debug("get user");
            throw new NotImplementedException();
        }

        public IUser ValidateUser(string userNameOrEmail, string password)
        {
            throw new NotImplementedException();
        }

        public void SetPassword(IUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
