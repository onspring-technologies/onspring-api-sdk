using System.Collections.Generic;
using System.Linq;
using Onspring.API.SDK.ResultValues;

namespace Onspring.API.SDK.Models
{
    public class FieldValueContainer
    {
        private readonly Dictionary<int, ResultValue> _values = new Dictionary<int, ResultValue>();

        public ResultValue this[int fieldId]
        {
            get
            {
                ResultValue result;
                return _values.TryGetValue(fieldId, out result) ? result : null;
            }
            set
            {
                _values[fieldId] = value;
            }
        }

        public IEnumerable<FieldValueWrapper> WithFieldId()
        {
            return _values.Select(v => new FieldValueWrapper(v.Key, v.Value));
        }

    }
}