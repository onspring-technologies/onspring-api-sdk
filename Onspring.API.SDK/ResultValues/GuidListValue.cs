using System;
using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class GuidListValue: ResultValue
    {
        public GuidListValue(IReadOnlyList<Guid> value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.GuidList;

        public IReadOnlyList<Guid> Value { get; private set; }

    }

}