using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class TimeSpanValue: ResultValue
    {
        public TimeSpanValue(TimeSpanData value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.TimeSpan;

        public TimeSpanData Value { get; private set; }

    }

}