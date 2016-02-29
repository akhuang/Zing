using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zing.Modules.Order.Models
{
    public class OrderDetailEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        public virtual OrderEntity OrderEntity { get; set; }
    }
}
