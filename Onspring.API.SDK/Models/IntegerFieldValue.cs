namespace Onspring.API.SDK.Models
{
    public class IntegerFieldValue : RecordFieldValue
    {
        public int? Value { get; set; }

        public IntegerFieldValue()
        {
            Type = Enums.ResultValueType.Integer;
        }

        public IntegerFieldValue(int? value) : this()
        {
            Value = value;
        }
    }
}
