using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing;
using Zing.Data;
using Zing.Modules.Order.Models;

namespace Zing.Modules.Order.Services
{
    public class OrderService : ServiceBase<OrderEntity>, IOrderService
    {
        private IRepository<OrderEntity> _repo;
        public OrderService(IRepository<OrderEntity> repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
