using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using Zing.Framework;
using Zing.Framework.Security;
using Zing.Data;
using Zing.Modules.Users.Models;
using Zing.Data.Query.Services;

namespace Zing.Modules.Users.Repositories
{
    public class MembershipRepository : Repository<UserEntity>, IMembershipRepository
    {
        public MembershipRepository(ISessionLocator sessionLocator, IHqlQueryManager hqlQueryManager)
            : base(sessionLocator, hqlQueryManager)
        {

        }
        public IUser Add(IUser model)
        {
            base.Create(model as UserEntity);

            return model;
        }

    }
}
