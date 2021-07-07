using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of string values.
    /// </summary>
    public class StringListFieldValue : RecordFieldValue
    {
        /// <summary>
        /// Gets or sets the collection of strings.
        /// </summary>
        public List<string> Value { get; set; } = new List<string>();

        /// <summary>
        /// Initializes a new instance of <see cref="StringListFieldValue"/>.
        /// </summary>
        public StringListFieldValue()
        {
            Type = Enums.ResultValueType.StringList;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="StringListFieldValue"/>.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <param name="value"></param>
        public StringListFieldValue(int fieldId, List<string> value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
