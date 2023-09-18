using System;

namespace Onspring.API.SDK.Enums
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

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

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }

    public class FilterOperator : Enumeration
    {
        public static FilterOperator Equal { get; } = new FilterOperator(1, "eq");
        public static FilterOperator NotEqual { get; } = new FilterOperator(2, "ne");
        public static FilterOperator Contains { get; } = new FilterOperator(3, "contains");
        public static FilterOperator IsNull { get; } = new FilterOperator(4, "isnull");
        public static FilterOperator NotNull { get; } = new FilterOperator(5, "notnull");
        public static FilterOperator GreaterThan { get; } = new FilterOperator(6, "gt");
        public static FilterOperator LessThan { get; } = new FilterOperator(7, "lt");
        public static FilterOperator And { get; } = new FilterOperator(8, "and");
        public static FilterOperator Or { get; } = new FilterOperator(9, "or");
        public static FilterOperator Not { get; } = new FilterOperator(10, "not");

        private FilterOperator(int id, string name) : base(id, name)
        {
        }
    }

}