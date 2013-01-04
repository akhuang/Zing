using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Logging;
using Zing.Events;
using Zing.Validation;
using System.Transactions;

namespace Zing.Tasks
{
    public interface IBackgroundService : IDependency
    {
        void Sweep();
    }

    [UsedImplicitly]
    public class BackgroundService : IBackgroundService
    {
        private readonly IEnumerable<IEventHandler> _tasks;

        public BackgroundService(IEnumerable<IEventHandler> tasks)
        {
            _tasks = tasks;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Sweep()
        {
            foreach (var task in _tasks.OfType<IBackgroundTask>())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        task.Sweep();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e, "Error while processing background task");
                    }
                }
            }
        }
    }
}
