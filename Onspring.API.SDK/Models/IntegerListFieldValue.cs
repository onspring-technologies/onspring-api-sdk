using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class IntegerListFieldValue : RecordFieldValue
    {
        public List<int> Value { get; set; } = new List<int>();

        public IntegerListFieldValue()
        {
            Type = Enums.ResultValueType.IntegerList;
        }

        public IntegerListFieldValue(List<int> value) : this()
        {
            Value = value;
        }
    }
}
