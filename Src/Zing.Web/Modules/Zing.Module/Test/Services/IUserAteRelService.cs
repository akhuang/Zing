using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Data;
using Zing.Modules.Test.Models;

namespace Zing.Modules.Test.Services
{

    public interface IUserAteRelService : IService<UserAteRelEntity>, IDependency
    {
    }

    public class UserAteRelService : ServiceBase<UserAteRelEntity>, IUserAteRelService
    {
        private readonly IRepository<UserAteRelEntity> _rep;
        public UserAteRelService(IRepository<UserAteRelEntity> rep) : base(rep)
        {
            _rep = rep;
        }
    }
}
