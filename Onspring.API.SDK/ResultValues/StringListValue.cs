using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class StringListValue: ResultValue
    {
        public StringListValue(IReadOnlyList<string> value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.StringList;

        public IReadOnlyList<string> Value { get; private set; }

    }

}