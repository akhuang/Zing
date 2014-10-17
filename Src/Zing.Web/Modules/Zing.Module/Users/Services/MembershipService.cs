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
            var userList = base.Fetch(null);
            return userList;
        }

        public void SetPassword(IUser model, string password)
        {
            SetPasswordHashed(model as UserEntity, password);
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
            //throw new NotImplementedException();

            return base.Get(x => x.UserName == userName);
        }

        public IUser ValidateUser(string userNameOrEmail, string password)
        {
            IUser user = null;
            user = _userRep.Fetch(x => x.UserName == userNameOrEmail).FirstOrDefault();

            if (user == null)
                return null;

            if (!ValidatePassword(user, password))
            {
                return null;
            }

            return user;
        }

        private bool ValidatePassword(IUser user, string password)
        {
            var userPart = user as UserEntity;
            if (userPart == null)
            {
                return false;
            }

            // Note - the password format stored with the record is used
            // otherwise changing the password format on the site would invalidate
            // all logins
            switch (userPart.PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    return ValidatePasswordClear(userPart, password);
                case MembershipPasswordFormat.Hashed:
                    return ValidatePasswordHashed(userPart, password);
                //case MembershipPasswordFormat.Encrypted:
                //    return ValidatePasswordEncrypted(userPart, password);
                default:
                    throw new ApplicationException("Unexpected password format value");
            }
        }

        private static bool ValidatePasswordClear(UserEntity userPart, string password)
        {
            return userPart.Password == password;
        }

        private static bool ValidatePasswordHashed(UserEntity userPart, string password)
        {

            var saltBytes = Convert.FromBase64String(userPart.PasswordSalt);

            var passwordBytes = Encoding.Unicode.GetBytes(password);

            var combinedBytes = saltBytes.Concat(passwordBytes).ToArray();

            byte[] hashBytes;
            using (var hashAlgorithm = HashAlgorithm.Create(userPart.HashAlgorithm))
            {
                hashBytes = hashAlgorithm.ComputeHash(combinedBytes);
            }

            return userPart.Password == Convert.ToBase64String(hashBytes);
        }

        //private bool ValidatePasswordEncrypted(UserPart userPart, string password)
        //{
        //    return String.Equals(password, Encoding.UTF8.GetString(_encryptionService.Decode(Convert.FromBase64String(userPart.Password))), StringComparison.Ordinal);
        //}

    }
}
