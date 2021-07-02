using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class GuidListFieldValue : RecordFieldValue
    {
        public List<Guid> Value { get; set; } = new List<Guid>();
    }
}
