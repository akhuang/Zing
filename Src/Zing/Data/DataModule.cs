﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Zing.Data.Providers;
using Zing.Data.Query.Services;
using Module = Autofac.Module;

namespace Zing.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            builder.RegisterType<HqlQueryManager>().As<IHqlQueryManager>();
            //builder.RegisterType<HqlQueryManager>().As<Ifilter>();

        }
        protected override void AttachToComponentRegistration(Autofac.Core.IComponentRegistry componentRegistry, Autofac.Core.IComponentRegistration registration)
        {
            if (typeof(IDataServicesProvider).IsAssignableFrom(registration.Activator.LimitType))
            {
                var propertyInfo = registration.Activator.LimitType.GetProperty("ProviderName", BindingFlags.Static | BindingFlags.Public);
                if (propertyInfo != null)
                {
                    registration.Metadata["ProviderName"] = propertyInfo.GetValue(null, null);
                }
            }
        }
    }
}
