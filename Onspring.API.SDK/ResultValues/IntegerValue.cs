using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class IntegerValue: ResultValue
    {
        public IntegerValue(int? value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.Integer;

        public int? Value { get; private set; }

    }

}