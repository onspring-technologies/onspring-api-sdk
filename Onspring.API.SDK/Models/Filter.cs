using System;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models
{
    public class Filter
    {
        public int FieldId { get; private set; }
        public FilterOperator Operator { get; private set; }
        public object Value { get; private set; }

        internal Filter() { }

        public Filter(int fieldId, FilterOperator filterOperator, object value)
        {
            if (value == null && filterOperator != FilterOperator.IsNull && filterOperator != FilterOperator.NotNull)
            {
                throw new ArgumentException("Value cannot be null for this operator");
            }

            FieldId = fieldId;
            Operator = filterOperator;
            Value = value;
        }

        public override string ToString()
        {
            if (Value == null)
            {
                return $"{FieldId} {Operator}";
            }

            if (Value is DateTime dateTime)
            {
                return $"{FieldId} {Operator} datetime'{dateTime:yyyy-MM-ddTHH:mm:ss.fff}'";
            }

            if (Value is string stringValue)
            {
                return $"{FieldId} {Operator} '{stringValue}'";
            }

            return $"{FieldId} {Operator} {Value}";
        }
    }
}