using System;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class GuidValue: ResultValue
    {
        public GuidValue(Guid? value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.Guid;

        public Guid? Value { get; private set; }

    }

}