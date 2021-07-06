using System;

namespace Onspring.API.SDK.Models
{
    public class DateFieldValue : RecordFieldValue
    {
        public DateTime? Value { get; set; }

        public DateFieldValue()
        {
            Type = Enums.ResultValueType.Date;
        }

        public DateFieldValue(DateTime? value) : this()
        {
            Value = value;
        }
    }
}
