using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Data;
using Zing.Data.Conventions;
using Zing.DomainModel;

namespace Zing.Modules.Order.Models
{
    public class OrderEntity : Entity
    {
        public OrderEntity()
        {
            OrderDetails = new List<OrderDetailEntity>();
        }

        public virtual string Name { get; set; }

        [CascadeAllDeleteOrphan]
        public virtual IList<OrderDetailEntity> OrderDetails { get; set; }

        public void AddOrderDetail(OrderDetailEntity model)
        {
            model.OrderEntity = this;
            OrderDetails.Add(model);
        }
    }
}
