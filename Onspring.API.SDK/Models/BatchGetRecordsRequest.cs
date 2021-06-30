using Onspring.API.SDK.Enums;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to get a batch of records.
    /// </summary>
    public class BatchGetRecordsRequest
    {
        /// <summary>
        /// Associated app identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Collection of record identifiers to get.
        /// Max is 100.
        /// </summary>
        public List<int> RecordIds { get; set; } = new List<int>();

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
