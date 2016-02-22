using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Onspring.API.SDK.Models
{
    public class FieldAddEditContainer
    {
        private readonly Dictionary<int, object> _values = new Dictionary<int, object>();

        public void Add(int fieldId, object value)
        {
            _values.Add(fieldId, value);
        }

        public bool Any() => _values.Any();

        public IEnumerable<int> FieldIds => _values.Keys;

        public object this[int fieldId]
        {
            get
            {
                object result;
                return _values.TryGetValue(fieldId, out result) ? result : null;
            }
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(new { FieldData = _values });
        }

    }
}