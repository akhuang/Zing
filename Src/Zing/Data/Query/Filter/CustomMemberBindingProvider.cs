using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Zing.Data.Query.Filter
{
    public class CustomMemberBindingProvider : IMemberBindingProvider
    {
        private readonly ISessionFactoryHolder _sessionFactoryHolder;

        public CustomMemberBindingProvider(
            ISessionFactoryHolder sessionFactoryHolder)
        {
            _sessionFactoryHolder = sessionFactoryHolder;
        }

        public void GetMemberBindings(BindingBuilder builder)
        { 
            var recordBluePrints = _sessionFactoryHolder.GetSessionFactoryParameters().RecordDescriptors;

            foreach (var record in recordBluePrints)
            {
                var properties = record.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (properties == null)
                {
                    continue;
                }

                foreach (var property in properties)
                {
                    builder.Add(property, property.Name, property.Name);
                }
            }
        }
    }
}
