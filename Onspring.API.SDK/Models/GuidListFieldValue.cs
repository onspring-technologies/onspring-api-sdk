using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class GuidListFieldValue : RecordFieldValue
    {
        public List<Guid> Value { get; set; } = new List<Guid>();

        /// <summary>
        /// Initializes a new instance of <see cref="GuidListFieldValue"/>.
        /// </summary>
        public GuidListFieldValue()
        {
            Type = Enums.ResultValueType.GuidList;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GuidListFieldValue"/>.
        /// </summary>
        public GuidListFieldValue(int fieldId, List<Guid> value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
