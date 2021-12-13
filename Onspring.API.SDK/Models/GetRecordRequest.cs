using Onspring.API.SDK.Enums;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to get a record by its identifier.
    /// </summary>
    public class GetRecordRequest
    {
        /// <summary>
        /// Gets or sets the app identifier.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Gets or sets the record identifier.
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// Gets or sets the collection of field identifiers.
        /// </summary>
        public List<int> FieldIds { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the format of data.
        /// </summary>
        public DataFormat DataFormat { get; set; } = DataFormat.Raw;

        /// <summary>
        /// Initializes a new instance of <see cref="GetRecordRequest"/>.
        /// </summary>
        public GetRecordRequest()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="GetRecordRequest"/>.
        /// </summary>
        public GetRecordRequest(int appId, int recordId)
        {
            AppId = appId;
            RecordId = recordId;
        }
    }
}
