using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Events;

namespace Zing.Tasks
{
    public interface IBackgroundTask : IEventHandler
    {
        void Sweep();
    }
}
