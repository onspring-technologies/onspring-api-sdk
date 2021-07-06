using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class GuidListFieldValue : RecordFieldValue
    {
        public List<Guid> Value { get; set; } = new List<Guid>();

        public GuidListFieldValue()
        {
            Type = Enums.ResultValueType.GuidList;
        }

        public GuidListFieldValue(List<Guid> value) : this()
        {
            Value = value;
        }
    }
}
