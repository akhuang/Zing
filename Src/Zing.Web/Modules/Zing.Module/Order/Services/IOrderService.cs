using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Modules.Order.Models;

namespace Zing.Modules.Order.Services
{
    public interface IOrderService : IService<OrderEntity>, IDependency
    {
    }
}
