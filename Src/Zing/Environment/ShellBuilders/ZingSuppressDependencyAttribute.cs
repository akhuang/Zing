using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.ShellBuilders
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ZingSuppressDependencyAttribute : Attribute
    {
        public ZingSuppressDependencyAttribute(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; set; }
    }
}
