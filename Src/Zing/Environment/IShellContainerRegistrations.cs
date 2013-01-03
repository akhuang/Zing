using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Zing.Environment
{
    public interface IShellContainerRegistrations
    {
        Action<ContainerBuilder> Registrations { get; }
    }

    public class ShellContainerRegistrations : IShellContainerRegistrations
    {
        public ShellContainerRegistrations()
        {
            Registrations = builder => { return; };
        }

        public Action<ContainerBuilder> Registrations { get; private set; }
    }
}
