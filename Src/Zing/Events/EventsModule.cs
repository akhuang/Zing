using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Zing.Events
{
    internal class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new EventsRegistrationSource());
            base.Load(builder);
        }
    }
}
