﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.Extensions.Models
{
    public class Feature
    {
        public FeatureDescriptor Descriptor { get; set; }
        public IEnumerable<Type> ExportedTypes { get; set; }
    }
}
