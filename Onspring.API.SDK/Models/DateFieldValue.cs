using System;

namespace Onspring.API.SDK.Models
{
    public class DateFieldValue : RecordFieldValue<DateTime?>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DateFieldValue"/>.
        /// </summary>
        public DateFieldValue()
        {
            Type = Enums.ResultValueType.Date;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DateFieldValue"/>.
        /// </summary>
        public DateFieldValue(int fieldId, DateTime? value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
