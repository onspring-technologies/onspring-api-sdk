﻿using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class ScoringGroupListFieldValue : RecordFieldValue
    {
        public List<ScoringGroup> Value { get; set; } = new List<ScoringGroup>();

        public ScoringGroupListFieldValue()
        {
            Type = Enums.ResultValueType.ScoringGroupList;
        }

        public ScoringGroupListFieldValue(List<ScoringGroup> value) : this()
        {
            Value = value;
        }
    }
}