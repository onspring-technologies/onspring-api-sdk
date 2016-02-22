﻿using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class ScoringGroupListValue: ResultValue
    {
        public ScoringGroupListValue(IReadOnlyList<ScoringGroup> value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.ScoringGroupList;

        public IReadOnlyList<ScoringGroup> Value { get; private set; }

    }

}