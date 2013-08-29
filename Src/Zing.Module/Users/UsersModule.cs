using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module = Autofac.Module;
using Autofac;
using Zing.Framework.Security;
using Zing.Modules.Users.Services;
using Zing.Modules.Users.Repositories;

namespace Zing.Modules.Users
{
    public class UsersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MembershipService>().As<IMembershipServiceInModule>();
            builder.RegisterType<MembershipService>().As<IMembershipService>();
            builder.RegisterType<MembershipRepository>().As<IMembershipRepository>();
        }
    }
}
