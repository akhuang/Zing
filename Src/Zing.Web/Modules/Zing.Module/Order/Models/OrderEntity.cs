using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Data.Conventions;

namespace Zing.Modules.Order.Models
{
    public class OrderEntity
    {
        public OrderEntity()
        {
            OrderDetails = new List<OrderDetailEntity>();
        }
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        [CascadeAllDeleteOrphan]
        public virtual IList<OrderDetailEntity> OrderDetails { get; set; }

    }
}
