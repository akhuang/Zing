using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Zing.Logging;

namespace Zing.Data
{
    public interface ISessionFactoryHolder : ISingletonDependency
    {
        ISessionFactory GetSessionFactory();
        Configuration GetConfiguration();
        //SessionFactoryParameters GetSessionFactoryParameters();
    }
    public class SessionFactoryHolder : ISessionFactoryHolder
    {
        public ILogger Logger { get; set; }
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        public SessionFactoryHolder()
        {
            Logger = NullLogger.Instance;
        }

        public void Dispose()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Dispose();
                _sessionFactory = null;
            }
        }

        public ISessionFactory GetSessionFactory()
        {
            lock (this)
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = BuildSessionFactory();
                }
            }
            return _sessionFactory;
        }

        public Configuration GetConfiguration()
        {
            lock (this)
            {
                if (_configuration == null)
                {
                    //_configuration = BuildConfiguration();
                }
            }
            return _configuration;
        }

        private ISessionFactory BuildSessionFactory()
        {
            Logger.Debug("Building session factory");

            //if (!_hostEnvironment.IsFullTrust)
            //    NHibernate.Cfg.Environment.UseReflectionOptimizer = false;

            //Configuration config = GetConfiguration();
            //var result = config.BuildSessionFactory();

            var result = Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection")))
              .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("Zing.Modules")))
              .BuildSessionFactory();

            Logger.Debug("Done building session factory");
            return result;
        }

        //private Configuration BuildConfiguration()
        //{
        //    Logger.Debug("Building configuration");
        //    var parameters = GetSessionFactoryParameters();

        //    var config = _sessionConfigurationCache.GetConfiguration(() =>
        //        _dataServicesProviderFactory
        //            .CreateProvider(parameters)
        //            .BuildConfiguration(parameters)
        //        //.Cache(c => _cacheConfiguration.Configure(c))
        //    );

        //    #region NH specific optimization
        //    // cannot be done in fluent config
        //    // the IsSelectable = false prevents unused ContentPartRecord proxies from being created 
        //    // for each ContentItemRecord or ContentItemVersionRecord.
        //    // done for perf reasons - has no other side-effect

        //    foreach (var persistentClass in config.ClassMappings)
        //    {
        //        if (persistentClass.EntityName.StartsWith("Orchard.ContentManagement.Records."))
        //        {
        //            foreach (var property in persistentClass.PropertyIterator)
        //            {
        //                if (property.Name.EndsWith("Record") && !property.IsBasicPropertyAccessor)
        //                {
        //                    property.IsSelectable = false;
        //                }
        //            }
        //        }
        //    }
        //    #endregion

        //    parameters.Configurers.Invoke(c => c.Finished(config), Logger);

        //    Logger.Debug("Done Building configuration");
        //    return config;
        //}
    }
}
