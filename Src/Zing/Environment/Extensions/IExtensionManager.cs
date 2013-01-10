﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Extensions.Models;
using Zing.Environment.Descriptor.Models;

namespace Zing.Environment.Extensions
{
    public interface IExtensionManager
    {
        IEnumerable<ExtensionDescriptor> AvailableExtensions();
        IEnumerable<FeatureDescriptor> AvailableFeatures();

        ExtensionDescriptor GetExtension(string id);

        IEnumerable<Feature> LoadFeatures(IEnumerable<FeatureDescriptor> featureDescriptors);
    }

    public static class ExtensionManagerExtensions
    {
        public static IEnumerable<FeatureDescriptor> EnabledFeatures(this IExtensionManager extensionManager, ShellDescriptor descriptor)
        {
            return extensionManager.AvailableFeatures().Where(fd => descriptor.Features.Any(sf => sf.Name == fd.Id));
        }
    }
}