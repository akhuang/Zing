﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Environment.Descriptor.Models;
using Zing.Environment.ShellBuilders.Models;
using Autofac;

namespace Zing.Environment.ShellBuilders
{
    public class ShellContext
    {
        public ShellSettings Settings { get; set; }
        public ShellDescriptor Descriptor { get; set; }
        public ShellBlueprint Blueprint { get; set; }
        public ILifetimeScope LifetimeScope { get; set; }
        public IZingShell Shell { get; set; }
    }
}