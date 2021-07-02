using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class StringListFieldValue : RecordFieldValue
    {
        public List<string> Value { get; set; } = new List<string>();
    }
}
