using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using Zing.Framework;
using Zing.Framework.Security;
using Zing.Data;
using Zing.Modules.Users.Models;

namespace Zing.Modules.Users.Repositories
{
    public class MembershipRepository : RepositoryBase<UserEntity>, IMembershipRepository
    {
        private readonly IRepository<UserEntity> _rep;
        public MembershipRepository(IRepository<UserEntity> rep)
            : base(rep)
        {
            _rep = rep;
        }

        public IUser Add(IUser model)
        {
            //ISessionFactory factory = SessionFactoryHolder.CreateSessionFactory();
            //using (ISession session = factory.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        session.SaveOrUpdate(model);

            //        transaction.Commit();
            //    }
            //}

            _rep.Create(model as UserEntity);

            return model;
        }

    }
}
