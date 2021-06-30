using Onspring.API.SDK.Enums;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to query records.
    /// </summary>
    public class QueryRecordsRequest
    {
        /// <summary>
        /// App identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Filter text.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Collection of field identifiers.
        /// </summary>
        public List<int> FieldIds { get; set; } = new List<int>();

        /// <summary>
        /// Format of the record data. Default value is <see cref="DataFormat.Raw"/>.
        /// </summary>
        public DataFormat DataFormat { get; set; } = DataFormat.Raw;
    }
}
