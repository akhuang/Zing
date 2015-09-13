using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.FilterEditors.Forms
{
    public class StringFilterForm : IFormProvider
    {
        public const string FormName = "StringFilter";

        protected dynamic Shape { get; set; }

        public static Action<IHqlExpressionFactory> GetFilterPredicate(dynamic formState, string property)
        {
            var op = (StringOperator)Enum.Parse(typeof(StringOperator), Convert.ToString(formState.Operator));
            object value = Convert.ToString(formState.Value);

            switch (op)
            {
                case StringOperator.Equals:
                    return x => x.Eq(property, value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum StringOperator
    {
        Equals,
        NotEquals,
        Contains,
        ContainsAny,
        ContainsAll,
        Starts,
        NotStarts,
        Ends,
        NotEnds,
        NotContains,
    }
}
