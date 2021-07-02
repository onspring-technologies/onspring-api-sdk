using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class IntegerListFieldValue : RecordFieldValue
    {
        public List<int> Value { get; set; } = new List<int>();
    }
}
