using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to delete a batch of records.
    /// </summary>
    public class BatchDeleteRecordsRequest
    {
        /// <summary>
        /// Associated app identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Collection of record identifiers to delete.
        /// Max is 100.
        /// </summary>
        public List<int> RecordIds { get; set; } = new List<int>();
    }
}
