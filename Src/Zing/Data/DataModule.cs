using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Zing.Data.Providers;
using Zing.Data.Query;
using Zing.Data.Query.Filter;
using Zing.Data.Query.FilterEditors.Forms;
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
            builder.RegisterType<MemberBindingFilter>().As<IFilterProvider>();
            builder.RegisterType<StringFilterForm>().As<IFormProvider>();
            builder.RegisterType<DefaultHqlQuery>().As<IHqlQuery>();
            builder.RegisterType<MemberBindingFilter>().As<IMemberBindingProvider>();
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
