using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class DecimalValue: ResultValue
    {
        public DecimalValue(decimal? value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.Decimal;

        public decimal? Value { get; private set; }

    }

}