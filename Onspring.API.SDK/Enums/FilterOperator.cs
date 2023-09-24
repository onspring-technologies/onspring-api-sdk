using System;

namespace Onspring.API.SDK.Enums
{
    /// <summary>
    /// Represents a base class for enumerations with common properties.
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Gets the name of the enumeration.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the enumeration.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the enumeration.</param>
        /// <param name="name">The name of the enumeration.</param>
        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        /// <summary>
        /// Converts the enumeration to its string representation (the name).
        /// </summary>
        /// <returns>The name of the enumeration.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Determines whether the current object is equal to another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Enumeration otherValue)
            {
                var typeMatches = GetType().Equals(obj.GetType());
                var valueMatches = Id.Equals(otherValue.Id);

                return typeMatches && valueMatches;
            }

            return false;
        }

        /// <summary>
        /// Gets a hash code for the enumeration.
        /// </summary>
        /// <returns>A hash code for the enumeration.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Compares the current instance with another object and returns an integer
        /// that indicates whether the current instance precedes, follows, or is equivalent
        /// to the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared.
        /// </returns>
        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }

    /// <summary>
    /// Represents a filter operator enumeration with predefined values.
    /// </summary>
    public class FilterOperator : Enumeration
    {
        /// <summary>
        /// Represents the "eq" filter operator.
        /// </summary>
        public static FilterOperator Equal { get; } = new FilterOperator(1, "eq");

        /// <summary>
        /// Represents the "ne" filter operator.
        /// </summary>
        public static FilterOperator NotEqual { get; } = new FilterOperator(2, "ne");

        /// <summary>
        /// Represents the "contains" filter operator.
        /// </summary>
        public static FilterOperator Contains { get; } = new FilterOperator(3, "contains");

        /// <summary>
        /// Represents the "isnull" filter operator.
        /// </summary>
        public static FilterOperator IsNull { get; } = new FilterOperator(4, "isnull");

        /// <summary>
        /// Represents the "notnull" filter operator.
        /// </summary>
        public static FilterOperator NotNull { get; } = new FilterOperator(5, "notnull");

        /// <summary>
        /// Represents the "gt" filter operator.
        /// </summary>
        public static FilterOperator GreaterThan { get; } = new FilterOperator(6, "gt");

        /// <summary>
        /// Represents the "lt" filter operator.
        /// </summary>
        public static FilterOperator LessThan { get; } = new FilterOperator(7, "lt");

        /// <summary>
        /// Represents the "and" filter operator.
        /// </summary>
        public static FilterOperator And { get; } = new FilterOperator(8, "and");

        /// <summary>
        /// Represents the "or" filter operator.
        /// </summary>
        public static FilterOperator Or { get; } = new FilterOperator(9, "or");

        /// <summary>
        /// Represents the "not" filter operator.
        /// </summary>
        public static FilterOperator Not { get; } = new FilterOperator(10, "not");

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterOperator"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the filter operator.</param>
        /// <param name="name">The name of the filter operator.</param>
        private FilterOperator(int id, string name) : base(id, name)
        {
        }
    }

}