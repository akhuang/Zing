using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.Filter
{
    public class DescribeFilterContext
    {
        private readonly Dictionary<string, DescribeFilterFor> _describes = new Dictionary<string, DescribeFilterFor>();

        public IEnumerable<FilterDescriptor> Describe()
        {
            return _describes.Select(kp => kp.Value.Types).SelectMany(x => x);
        }

        public DescribeFilterFor For(string category)
        {
            return For(category, null, null);
        }

        public DescribeFilterFor For(string category, string name, string description)
        {
            DescribeFilterFor describeFor;
            if (!_describes.TryGetValue(category, out describeFor))
            {
                describeFor = new DescribeFilterFor(category, name, description);
                _describes[category] = describeFor;
            }
            return describeFor;
        }
    }
}
