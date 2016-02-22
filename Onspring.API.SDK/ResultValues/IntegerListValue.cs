using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class IntegerListValue: ResultValue
    {
        public IntegerListValue(IReadOnlyList<int> value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.IntegerList;

        public IReadOnlyList<int> Value { get; private set; }

    }

}