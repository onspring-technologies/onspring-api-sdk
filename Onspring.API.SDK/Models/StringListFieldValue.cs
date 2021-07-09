using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of string values.
    /// </summary>
    public class StringListFieldValue : RecordFieldValue<List<string>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="StringListFieldValue"/>.
        /// </summary>
        public StringListFieldValue()
        {
            Type = Enums.ResultValueType.StringList;
            Value = new List<string>();
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
