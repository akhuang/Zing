using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zing.DomainModel
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }

        bool IsTransient();
    }

    [Serializable]
    public abstract class EntityWithTypedId<TId> : IEntityWithTypedId<TId>
    {
        public virtual TId Id
        {
            get;
            protected set;
        }

        public virtual bool IsTransient()
        {
            return this.Id == null || this.Id.Equals(default(TId));
        }
    }

    [Serializable]
    public abstract class Entity : EntityWithTypedId<int>
    {

    }
}
