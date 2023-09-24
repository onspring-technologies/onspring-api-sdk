using System;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a filter used for querying data.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Gets or sets the identifier of the field to filter on.
        /// </summary>
        public int FieldId { get; set; }

        /// <summary>
        /// Gets or sets the filter operator to apply to the field.
        /// </summary>
        public FilterOperator Operator { get; set; }

        private object filterValue;

        /// <summary>
        /// Gets or sets the value to filter against.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// </summary>
        internal Filter() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class with specified values.
        /// </summary>
        /// <param name="fieldId">The identifier of the field to filter on.</param>
        /// <param name="filterOperator">The filter operator to apply to the field.</param>
        /// <param name="value">The value to filter against.</param>
        public Filter(int fieldId, FilterOperator filterOperator, object value)
        {
            FieldId = fieldId;
            Operator = filterOperator;
            Value = value;
        }

        /// <summary>
        /// Returns a string representation of the filter.
        /// </summary>
        /// <returns>A string representing the filter.</returns>
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