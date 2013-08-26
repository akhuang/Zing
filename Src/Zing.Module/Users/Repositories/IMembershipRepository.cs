using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Data;
using Zing.Framework.Security;
using Zing.Modules.Users.Models;


namespace Zing.Modules.Users.Repositories
{
    public interface IMembershipRepository : IRepository<UserEntity>
    {
        IUser Add(IUser model);
    }
}
