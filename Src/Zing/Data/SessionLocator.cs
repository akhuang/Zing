using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Logging;

namespace Zing.Data
{
    public class SessionLocator : ISessionLocator
    {
        private readonly ISessionFactoryHolder _sessionFactoryHolder;
        private ISession _session;

        public SessionLocator(ISessionFactoryHolder sessionFactoryHolder)
        {
            _sessionFactoryHolder = sessionFactoryHolder;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public ISession For(Type entityType)
        {
            Logger.Debug("Acquiring session for {0}", entityType);
            Demand();

            return _session;
        }

        public void Demand()
        {
            EnsureSession();

            //if (_transaction == null)
            //{
            //    Logger.Debug("Creating transaction on Demand");
            //    _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
            //}
        }

        private void EnsureSession()
        {
            if (_session != null)
            {
                return;
            }

            var sessionFactory = _sessionFactoryHolder.GetSessionFactory();
            Logger.Information("Opening database session");
            _session = sessionFactory.OpenSession();
        }
    }
}
