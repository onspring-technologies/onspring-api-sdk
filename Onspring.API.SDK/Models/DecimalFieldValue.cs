namespace Onspring.API.SDK.Models
{
    public class DecimalFieldValue : RecordFieldValue
    {
        public decimal? Value { get; set; }

        public DecimalFieldValue()
        {
            Type = Enums.ResultValueType.Decimal;
        }

        public DecimalFieldValue(int fieldId, decimal? value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
