using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.Extensions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OrchardFeatureAttribute : Attribute
    {
        public OrchardFeatureAttribute(string text)
        {
            FeatureName = text;
        }

        public string FeatureName { get; set; }
    }
}
