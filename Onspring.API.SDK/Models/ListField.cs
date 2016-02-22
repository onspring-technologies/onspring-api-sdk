using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models
{
    public class ListField: Field
    {
        public Multiplicity Multiplicity { get; set; }
        public IReadOnlyList<ListValue> Values { get; set; }
    }
}