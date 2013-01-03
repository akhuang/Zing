using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.ShellBuilder
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ZingFeatureAttribute : Attribute
    {
        public ZingFeatureAttribute(string text)
        {
            FeatureName = text;
        }

        public string FeatureName { get; set; }
    }
}
