using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class IntegerListFieldValue : RecordFieldValue
    {
        public List<int> Value { get; set; } = new List<int>();

        /// <summary>
        /// Initializes a new instance of <see cref="IntegerListFieldValue"/>.
        /// </summary>
        public IntegerListFieldValue()
        {
            Type = Enums.ResultValueType.IntegerList;
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
