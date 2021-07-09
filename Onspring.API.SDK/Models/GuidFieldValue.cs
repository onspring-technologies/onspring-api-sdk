using System;

namespace Onspring.API.SDK.Models
{
    public class GuidFieldValue : RecordFieldValue<Guid?>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GuidFieldValue"/>.
        /// </summary>
        public GuidFieldValue()
        {
            Type = Enums.ResultValueType.Guid;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GuidFieldValue"/>.
        /// </summary>
        public GuidFieldValue(int fieldId, Guid? value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
