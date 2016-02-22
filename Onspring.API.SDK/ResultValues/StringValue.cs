using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class StringValue: ResultValue
    {
        public StringValue(string value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.String;

        public string Value { get; private set; }

    }

}