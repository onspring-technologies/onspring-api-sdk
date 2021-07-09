using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of int values.
    /// </summary>
    public class IntegerListFieldValue : RecordFieldValue<List<int>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IntegerListFieldValue"/>.
        /// </summary>
        public IntegerListFieldValue()
        {
            Type = Enums.ResultValueType.IntegerList;
            Value = new List<int>();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IntegerListFieldValue"/>.
        /// </summary>
        public IntegerListFieldValue(int fieldId, List<int> value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
