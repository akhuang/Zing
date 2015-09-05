using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public interface IHqlCriterion
    {
        string ToSql(IAlias alias);
    }

    public abstract class HqlCriterion : IHqlCriterion
    {
        public abstract string ToSql(IAlias alias);
    }

    public class BinaryExpression : HqlCriterion
    {
        public BinaryExpression(string op, string propertyName, string value, Func<string, string> processPropertyName = null)
        {
            this.Op = op;
            this.PropertyName = propertyName;
            this.Value = value;
            this.ProcessPropertyName = processPropertyName;
        }

        public string Op { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public Func<string, string> ProcessPropertyName { get; set; }

        public override string ToSql(IAlias alias)
        {
            var processed = string.Concat(alias.Name, ",", PropertyName);
            if (ProcessPropertyName != null)
            {
                processed = ProcessPropertyName(processed);
            }

            return string.Concat(processed, " ", Op, Value);
        }
    }

    public static class HqlRestrictions
    {
        public static IHqlCriterion Eq(string propertyName, object value)
        {
            return new BinaryExpression("=", propertyName, FormatValue(value));
        }

        private static string FormatValue(object value)
        {
            var typeCode = Type.GetTypeCode(value.GetType());

            switch (typeCode)
            {
                case TypeCode.Boolean:
                    break;
                case TypeCode.Byte:
                    break;
                case TypeCode.Char:
                    break;
                case TypeCode.DBNull:
                    break;
                case TypeCode.DateTime:
                    break;
                case TypeCode.Decimal:
                    break;
                case TypeCode.Double:
                    break;
                case TypeCode.Empty:
                    break;
                case TypeCode.Int16:
                    break;
                case TypeCode.Int32:
                    break;
                case TypeCode.Int64:
                    break;
                case TypeCode.Object:
                    break;
                case TypeCode.SByte:
                    break;
                case TypeCode.Single:
                    break;
                case TypeCode.String:
                    {
                        return EncodeQuotes(Convert.ToString(value, CultureInfo.InvariantCulture));
                    }
                case TypeCode.UInt16:
                    break;
                case TypeCode.UInt32:
                    break;
                case TypeCode.UInt64:
                    break;
                default:
                    break;
            }

            return EncodeQuotes(Convert.ToString(value, CultureInfo.InvariantCulture));
        }

        private static string EncodeQuotes(string value)
        {
            return value.Replace("'", "''");
        }

    }
}
