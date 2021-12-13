using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to delete a batch of records.
    /// </summary>
    public class DeleteRecordsRequest
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

        /// <summary>
        /// Initializes a new instance of <see cref="DeleteRecordsRequest"/>.
        /// </summary>
        public DeleteRecordsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DeleteRecordsRequest"/>.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"><paramref name="recordIds"/> was null.</exception>
        public DeleteRecordsRequest(int appId, IEnumerable<int> recordIds)
        {
            AppId = appId;
            RecordIds.AddRange(recordIds);
        }
    }
}
