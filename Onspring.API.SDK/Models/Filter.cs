using System;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models
{
    public class Filter
    {
        public int FieldId { get; set; }
        public FilterOperator Operator { get; set; }

        private object filterValue;

        public object Value
        {
            get { return filterValue; }
            set
            {
                if (value == null && Operator != null && Operator != FilterOperator.IsNull && Operator != FilterOperator.NotNull)
                {
                    throw new ArgumentException("Value cannot be null for this operator");
                }

                filterValue = value;
            }
        }

        internal Filter() { }

        public Filter(int fieldId, FilterOperator filterOperator, object value)
        {
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
                return $"{FieldId} {Operator} datetime'{dateTime:O}'";
            }

            if (Value is string stringValue)
            {
                return $"{FieldId} {Operator} '{stringValue}'";
            }

            return $"{FieldId} {Operator} {Value}";
        }
    }
}