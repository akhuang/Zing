using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Zing.Events
{
    public interface IEventBus : IDependency
    {
        IEnumerable Notify(string messageName, IDictionary<string, object> eventData);
    }
}
