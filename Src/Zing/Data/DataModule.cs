using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SessionLocator>().As<ISessionLocator>();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            //builder.RegisterType<Repository>().As<IRepository>();

            builder.RegisterType<SessionFactoryHolder>().As<ISessionFactoryHolder>();
        }
    }
}
