using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zing.Data
{
    public abstract class Entity : EntityWithTypeId<long>
    {
    }

    public abstract class EntityWithTypeId<TId>
    {
        public virtual TId Id { get; protected set; }

        public virtual bool IsTransient()
        {
            return this.Id == null || this.Id.Equals(default(TId));
        }
    }
}
