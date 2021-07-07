using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of <see cref="Guid"/> values.
    /// </summary>
    public class GuidListFieldValue : RecordFieldValue<List<Guid>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GuidListFieldValue"/>.
        /// </summary>
        public GuidListFieldValue()
        {
            Type = Enums.ResultValueType.GuidList;
            Value = new List<Guid>();
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
