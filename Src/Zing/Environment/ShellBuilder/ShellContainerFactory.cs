using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Mvc;
using Zing.Mvc.Routes;

namespace Zing.Environment.ShellBuilder
{

    public interface IShellContainerFactory
    {
        ILifetimeScope CreateContainer(ShellSettings settings);
    }

    public class ShellContainerFactory : IShellContainerFactory
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IShellContainerRegistrations _shellContainerRegistrations;

        public ShellContainerFactory(ILifetimeScope lifetimeScope, IShellContainerRegistrations shellContainerRegistrations)
        {
            _lifetimeScope = lifetimeScope;
            _shellContainerRegistrations = shellContainerRegistrations;
        }

        public ILifetimeScope CreateContainer(ShellSettings settings)
        {
            var intermediateScope = _lifetimeScope.BeginLifetimeScope(
                builder =>
                {
                    //foreach (var item in blueprint.Dependencies.Where(t => typeof(IModule).IsAssignableFrom(t.Type)))
                    //{
                    //    var registration = RegisterType(builder, item)
                    //        .Keyed<IModule>(item.Type)
                    //        .InstancePerDependency();

                    //    foreach (var parameter in item.Parameters)
                    //    {
                    //        registration = registration
                    //            .WithParameter(parameter.Name, parameter.Value)
                    //            .WithProperty(parameter.Name, parameter.Value);
                    //    }
                    //}
                    //var registration = builder.RegisterModule(new MvcModule());
                    //.WithProperty("Feature", item.Feature)
                    //.WithMetadata("Feature", item.Feature);
                });

            return intermediateScope.BeginLifetimeScope(
                "shell",
                builder =>
                {
                    //var dynamicProxyContext = new DynamicProxyContext();

                    //builder.Register(ctx => dynamicProxyContext);
                    builder.Register(ctx => settings);
                    //builder.Register(ctx => blueprint.Descriptor);
                    //builder.Register(ctx => blueprint);

                    //var moduleIndex = intermediateScope.Resolve<IIndex<Type, IModule>>();
                    //foreach (var item in blueprint.Dependencies.Where(t => typeof(IModule).IsAssignableFrom(t.Type)))
                    //{
                    //    builder.RegisterModule(moduleIndex[item.Type]);
                    //}

                    builder.RegisterModule(new MvcModule());
                    //builder.RegisterType<RoutePublisher>().As<IRoutePublisher>();

                    //foreach (var item in blueprint.Dependencies.Where(t => typeof(IDependency).IsAssignableFrom(t.Type)))
                    //{
                    //    var registration = RegisterType(builder, item)
                    //        .EnableDynamicProxy(dynamicProxyContext)
                    //        .InstancePerLifetimeScope();

                    //    foreach (var interfaceType in item.Type.GetInterfaces()
                    //        .Where(itf => typeof(IDependency).IsAssignableFrom(itf)
                    //                  && !typeof(IEventHandler).IsAssignableFrom(itf)))
                    //    {
                    //        registration = registration.As(interfaceType);
                    //        if (typeof(ISingletonDependency).IsAssignableFrom(interfaceType))
                    //        {
                    //            registration = registration.InstancePerMatchingLifetimeScope("shell");
                    //        }
                    //        else if (typeof(IUnitOfWorkDependency).IsAssignableFrom(interfaceType))
                    //        {
                    //            registration = registration.InstancePerMatchingLifetimeScope("work");
                    //        }
                    //        else if (typeof(ITransientDependency).IsAssignableFrom(interfaceType))
                    //        {
                    //            registration = registration.InstancePerDependency();
                    //        }
                    //    }

                    //    if (typeof(IEventHandler).IsAssignableFrom(item.Type))
                    //    {
                    //        registration = registration.As(typeof(IEventHandler));
                    //    }

                    //    foreach (var parameter in item.Parameters)
                    //    {
                    //        registration = registration
                    //            .WithParameter(parameter.Name, parameter.Value)
                    //            .WithProperty(parameter.Name, parameter.Value);
                    //    }
                    //}

                    //foreach (var item in blueprint.Controllers)
                    //{
                    //    var serviceKeyName = (item.AreaName + "/" + item.ControllerName).ToLowerInvariant();
                    //    var serviceKeyType = item.Type;
                    //    RegisterType(builder, item)
                    //        .EnableDynamicProxy(dynamicProxyContext)
                    //        .Keyed<IController>(serviceKeyName)
                    //        .Keyed<IController>(serviceKeyType)
                    //        .WithMetadata("ControllerType", item.Type)
                    //        .InstancePerDependency()
                    //        .OnActivating(e =>
                    //        {
                    //            // necessary to inject custom filters dynamically
                    //            // see FilterResolvingActionInvoker
                    //            var controller = e.Instance as Controller;
                    //            if (controller != null)
                    //                controller.ActionInvoker = (IActionInvoker)e.Context.ResolveService(new TypedService(typeof(IActionInvoker)));
                    //        });
                    //}

                    //foreach (var item in blueprint.HttpControllers)
                    //{
                    //    var serviceKeyName = (item.AreaName + "/" + item.ControllerName).ToLowerInvariant();
                    //    var serviceKeyType = item.Type;
                    //    RegisterType(builder, item)
                    //        .EnableDynamicProxy(dynamicProxyContext)
                    //        .Keyed<IHttpController>(serviceKeyName)
                    //        .Keyed<IHttpController>(serviceKeyType)
                    //        .WithMetadata("ControllerType", item.Type)
                    //        .InstancePerDependency();
                    //}

                    // Register code-only registrations specific to a shell
                    _shellContainerRegistrations.Registrations(builder);

                    //var optionalShellConfig = HostingEnvironment.MapPath("~/Config/Sites.config");
                    //if (File.Exists(optionalShellConfig))
                    //    builder.RegisterModule(new ConfigurationSettingsReader(ConfigurationSettingsReader.DefaultSectionName, optionalShellConfig));

                    //var optionalShellByNameConfig = HostingEnvironment.MapPath("~/Config/Sites." + settings.Name + ".config");
                    //if (File.Exists(optionalShellByNameConfig))
                    //    builder.RegisterModule(new ConfigurationSettingsReader(ConfigurationSettingsReader.DefaultSectionName, optionalShellByNameConfig));
                });
        }

        //private IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType(ContainerBuilder builder, ShellBlueprintItem item)
        //{
        //    return builder.RegisterType(item.Type)
        //        .WithProperty("Feature", item.Feature)
        //        .WithMetadata("Feature", item.Feature);
        //}
    }
}
