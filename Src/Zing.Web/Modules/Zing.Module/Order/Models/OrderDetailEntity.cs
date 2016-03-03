using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.Data;

namespace Zing.Modules.Order.Models
{
    public class OrderDetailEntity : Entity
    { 
        public virtual string Name { get; set; }

        public virtual OrderEntity OrderEntity { get; set; }
    }
}
