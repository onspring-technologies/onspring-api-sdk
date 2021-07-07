using System;

namespace Onspring.API.SDK.Models
{
    public class GuidFieldValue : RecordFieldValue
    {
        public Guid? Value { get; set; }

        public GuidFieldValue()
        {
            Type = Enums.ResultValueType.Guid;
        }

        public GuidFieldValue(int fieldId, Guid? value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
