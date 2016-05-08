using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Data;
using Zing.Modules.Test.Models;

namespace Zing.Modules.Test.Services
{
    public interface IAteService : IService<AteEntity>, IDependency
    {
        void GetList();
    }

    public class AteService : ServiceBase<AteEntity>, IAteService
    {
        private readonly IRepository<AteEntity> _rep;
        private IUserAteRelService _userAteRelService;
        public AteService(IRepository<AteEntity> rep, IUserAteRelService userAteRelService) : base(rep)
        {
            _rep = rep;
            _userAteRelService = userAteRelService;
        }


        public void GetList()

        {
            var queryable = FetchQueryable(null);

            var userAteRelQueryable = _userAteRelService.Table;

            var items = from c in queryable
                        join u in userAteRelQueryable on c.AteName equals u.AteName
                        select c;
            var list = items.ToList();

            var count = list.Count;

            var c1 = queryable.ToList();

        }

    }
}
