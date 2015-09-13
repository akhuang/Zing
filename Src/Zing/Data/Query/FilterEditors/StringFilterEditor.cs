using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Data.Query.FilterEditors.Forms;

namespace Zing.Data.Query.FilterEditors
{
    public class StringFilterEditor : IFilterEditor
    {
        public StringFilterEditor()
        {
          
        } 

        public bool CanHandle(Type type)
        {
            return new[] {
                typeof(char), 
                typeof(string),
            }.Contains(type);
        }

        public string FormName
        {
            get { return StringFilterForm.FormName; }
        }

        public Action<IHqlExpressionFactory> Filter(string property, dynamic formState)
        {
            return StringFilterForm.GetFilterPredicate(formState, property);
        }
         
    }
}
