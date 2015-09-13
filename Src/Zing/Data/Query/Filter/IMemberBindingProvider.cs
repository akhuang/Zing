using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Zing.Data.Query.Filter
{
    public interface IMemberBindingProvider
    {
        void GetMemberBindings(BindingBuilder builder);
    }

    public class BindingBuilder
    {
        private readonly IList<BindingItem> _memberBindings;
        public BindingBuilder()
        {
            _memberBindings = new List<BindingItem>();
        }

        public BindingBuilder Add(PropertyInfo property, string display, string description)
        {
            _memberBindings.Add(new BindingItem
            {
                Property = property,
                DisplayName = display,
                Description = description
            });
            return this;
        }

        public IEnumerable<BindingItem> Build()
        {
            return _memberBindings;
        }
    }

    public class BindingItem
    {
        public virtual PropertyInfo Property { get; set; }
        public virtual string Description { get; set; }
        public virtual string DisplayName { get; set; }
    }
}
