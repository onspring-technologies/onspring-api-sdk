namespace Onspring.API.SDK.Models
{
    public class DecimalFieldValue : RecordFieldValue
    {
        public decimal? Value { get; set; }

        public DecimalFieldValue()
        {
            Type = Enums.ResultValueType.Decimal;
        }

        public DecimalFieldValue(decimal? value) : this()
        {
            Value = value;
        }
    }
}
