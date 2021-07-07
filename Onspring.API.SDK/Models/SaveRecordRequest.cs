using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a record to save a record.
    /// </summary>
    public class SaveRecordRequest
    {
        /// <summary>
        /// Associated app identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Record identifier, if the request is to update.
        /// </summary>
        public int? RecordId { get; set; }

        /// <summary>
        /// Fields for the record.
        /// </summary>
        public Dictionary<int, object> Fields { get; set; } = new Dictionary<int, object>();
    }
}
