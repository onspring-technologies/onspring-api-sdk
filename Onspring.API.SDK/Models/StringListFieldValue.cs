using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class StringListFieldValue : RecordFieldValue
    {
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
        /// <param name="value"></param>
        public StringListFieldValue(List<string> value) : this()
        {
            Value = value;
        }
    }
}
