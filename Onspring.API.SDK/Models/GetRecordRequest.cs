using Onspring.API.SDK.Enums;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to get a record by its identifier.
    /// </summary>
    public class GetRecordRequest
    {
        public int AppId { get; set; }
        public int RecordId { get; set; }
        public List<int> FieldIds { get; set; } = new List<int>();
        public DataFormat DataFormat { get; set; } = DataFormat.Raw;
    }
}
